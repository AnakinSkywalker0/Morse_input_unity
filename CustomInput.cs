using UnityEngine;
using System.Collections.Generic;

public class MorseInput : MonoBehaviour
{
    public float dotThreshold = 0.3f;
    public float symbolPause = 0.6f;

    private float pressStartTime;
    private string currentSequence = "";
    private float lastReleaseTime;

    Dictionary<string, char> morseDict = new Dictionary<string, char>()
    {
        {".-", 'A'}, {"-...", 'B'}, {"-.-.", 'C'}, {"-..", 'D'},
        {".", 'E'}, {"..-.", 'F'}, {"--.", 'G'}, {"....", 'H'},
        {"..", 'I'}, {".---", 'J'}, {"-.-", 'K'}, {".-..", 'L'},
        {"--", 'M'}, {"-.", 'N'}, {"---", 'O'}, {".--.", 'P'},
        {"--.-", 'Q'}, {".-.", 'R'}, {"...", 'S'}, {"-", 'T'},
        {"..-", 'U'}, {"...-", 'V'}, {".--", 'W'}, {"-..-", 'X'},
        {"-.--", 'Y'}, {"--..", 'Z'}
    };

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            pressStartTime = Time.time;

        if (Input.GetKeyUp(KeyCode.Space))
        {
            float duration = Time.time - pressStartTime;
            currentSequence += duration < dotThreshold ? "." : "-";
            lastReleaseTime = Time.time;
        }

        if (currentSequence != "" && Time.time - lastReleaseTime > symbolPause)
        {
            if (morseDict.ContainsKey(currentSequence))
            {
                char letter = morseDict[currentSequence];
                Debug.Log("Morse Input: " + letter);
                TriggerAction(letter);
            }
            currentSequence = "";
        }
    }

    void TriggerAction(char c)
    {
        if (c == 'J') // Example
            Debug.Log("JUMP action triggered");
        else if (c == 'S')
            Debug.Log("SHOOT action triggered");
        // Add more
    }
}
