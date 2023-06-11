using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timminggame : MonoBehaviour
{
    public float timecount = 0, time;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timecount = Time.time;
        print(timecount);
        if(timecount > time){
            timecount = 0;
            
        }
       
    }
}
