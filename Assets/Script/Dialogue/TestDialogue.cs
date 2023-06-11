using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDialogue : MonoBehaviour
{
    DialogueScript dialogue;
    void Start()
    {
        dialogue = DialogueScript.instance;
    }
    public string[] s = new string[]
    {
        "ola, esse e um dialogo de teste:bot",
        "sirvo apenas para verificar a funcionalidade dessa mecanica"

    };
    int index = 0;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!dialogue.isSaying || dialogue.isWaitingForUserrInput)
            {
                if (index >= s.Length)
                {
                    return;
                }
                Say(s[index]);
                index++;
            }
        }
    }
    void Say(string s)
    {
        string[] parts = s.Split(':');
        string speech = parts[0];
        string speaker = (parts.Length >= 2) ? parts[1] : "";

        dialogue.say(speech, speaker);
    }
}
