using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputMouse : MonoBehaviour
{

    public static InputMouse MousePos;
    public Vector3 mousePosition;
    private void Awake()
    {
        MousePos = this;
    }
    void Update()
    {
        mousePosition = Input.mousePosition;
     //   Debug.Log("Mouse position: " + mousePosition);
    }
}
