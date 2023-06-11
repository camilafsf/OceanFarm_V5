using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Pause : MonoBehaviour
{
    public static Pause pause;
    public Button[] bts;
    public bool resourcePause;
    bool p =false;
    public GameObject canvas;
    // Start is called before the first frame update
    private void Awake()
    {
        pause = this;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (p  == false)
            {
                Paused();
                p = !p;
                canvas.SetActive(false);
            }
            else
            {
                UnPaused();
                p = !p;
                canvas.SetActive(true);
            }
        }
    }
    public void Paused()
    {
        resourcePause= false;
        foreach( var b in bts)
        {
            b.interactable = false;
        }
        TImer.Timer.stop = true;
        Calendar.date.Paused = true;
    }

    // Update is called once per frame
    public void UnPaused()
    {
        resourcePause = true;
        foreach (var b in bts)
        {
            b.interactable = true;
        }
        TImer.Timer.stop = false;
        Calendar.date.Paused = false;
        Calendar.date.day++;
    }
}
