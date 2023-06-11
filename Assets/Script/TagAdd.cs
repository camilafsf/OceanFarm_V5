using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TagAdd : MonoBehaviour
{
    public string tag;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            gameObject.tag = tag;
            Debug.Log("Objeto recebeu a tag !" + gameObject.tag);
        }
    }
}
