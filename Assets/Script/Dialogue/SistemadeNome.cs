using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SistemadeNome : MonoBehaviour
{

    [Header("Array de Nomes")]
    [SerializeField] private string[] textos;
    [Header("Obj para linkar o texto")]
    [SerializeField] private TextMeshProUGUI objdetexto;
    private int i = 0;
    void Awake()
    {
        objdetexto.text = textos[i];
        textos[i] = textos[i++];
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Space)) && i < textos.Length)
        {
            objdetexto.text = textos[i];
            textos[i] = textos[i++];
        }
    }
    public void click()
    {
        if (i < textos.Length)
        {
            objdetexto.text = textos[i];
            textos[i] = textos[i++];
        }
    }
}
