using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static DialogueScript;

public class DialogueScript : MonoBehaviour
{
    public static DialogueScript instance;
    public ELEMENTS elements;
    void Awake()
    {
        instance = this;   
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame

    public void say(string speech, string speaker)
    {
        stopSaying();
        StartCoroutine(Saying(speech, speaker));
    }
    public void stopSaying()
    {
        if (isSaying)
        {
            StopCoroutine(saying);
            
        }
        saying = null;
    }
    public bool isSaying { get { return saying != null; } }
    [HideInInspector]public bool isWaitingForUserrInput = false;
    Coroutine saying = null;
    IEnumerator Saying(string targetSpeech, string Speaker)
    {
        speech.SetActive(true);
        spkTXT.text = "";
        spkNameTXT.text = Speaker;
        isWaitingForUserrInput = false;
        while(spkTXT.text != targetSpeech)
        {
            spkTXT.text += targetSpeech[spkTXT.text.Length];
            yield return new WaitForEndOfFrame();
        }
        isWaitingForUserrInput = true;
        while (isWaitingForUserrInput)
        {
            yield return new WaitForEndOfFrame();  
        }
        stopSaying();
    }
    [System.Serializable]
    public class ELEMENTS
    {
        public GameObject speech;
        public Text spkNameTXT;
        public Text spkTXT;
    }
    public GameObject speech { get { return elements.speech; } }
    public Text spkNameTXT{ get { return elements.spkNameTXT; } }
    public Text spkTXT{ get { return elements.spkTXT; } }
}
