using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Calendar : MonoBehaviour
{
    public static Calendar date;
    public bool Paused = false;
    public int day = 1, month = 1, year = 1221;
    [SerializeField] private float dayTime;
    [SerializeField] private Text textComponent;

    private void Awake()
    {
        date = this;
    }
    void Start()
    {
        InvokeRepeating("dayUp", dayTime, dayTime);
    }

    // Update is called once per frame
    void Update()
    {
        textComponent.text = ((int)day + "/" + (int)month + "/" + (int)year).ToString();

        if (month == 1 || month == 3 || month == 5 || month == 6 || month == 7 || month == 9 || month == 12)
        {
            if (day == 32)
            {
                Invoke("monthUp", 0);
                day = 1;
            }

        }
        else if (month == 2)
        {
            if (day == 30)
            {
                Invoke("monthUp", 0);
                day = 1;
            }
        }
        else
        {
            if (day == 31)
            {
                Invoke("monthUp", 0);
                day = 1;
            }
        }
        if (month == 13)
        {
            Invoke("yearUp", 0);
            month = 1;
        }

    }
    public void dayUp()
    {
        if (Paused == false)
        {
            day += 1;
        }

    }
    void monthUp()
    {
        if (Paused == false)
            month += 1;
    }
    void yearUp()
    {
        if (Paused == false)
        {
            year += 1;
            //AnualEntrega.anual.decisão();
        }
    }
}
