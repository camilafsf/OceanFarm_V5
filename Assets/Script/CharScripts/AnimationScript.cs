using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScript : MonoBehaviour
{
    [SerializeField] private string[] anim;
    [SerializeField] private int falas;
    private int i;
    void Awake()
    {
        print(anim[i]);
        //setTrigger
        anim[i] = anim[i++];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && i < anim.Length)
        {
            print(anim[i]);
            //setTrigger
            anim[i] = anim[i++];
        }
    }
    public void click()
    {
        if (i < anim.Length)
        {
            print(anim[i]);
            //setTrigger
            anim[i] = anim[i++];
        }
    }
}
