using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TImer : MonoBehaviour
{
    Image timer;
    public bool stop = false;
    public float maxtime = 365f;
    public static TImer Timer;
    float timeleft;
    private void Awake()
    {
        Timer = this;

    }
    void Start()
    {
        timer = GetComponent<Image>();
        timeleft = maxtime;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeleft > 0 && stop == false)
        {
            timeleft -= Time.deltaTime;
            timer.fillAmount = timeleft / maxtime;
        }
        else if (timeleft <= 0)
        {
            timeleft = 365f;
        }

    }
}
