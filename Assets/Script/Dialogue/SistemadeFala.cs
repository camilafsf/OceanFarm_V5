using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class SistemadeFala : MonoBehaviour
{
    [Header("Array de textos")]
    [SerializeField] private string[] textos;
    [Header("Obj para linkar o texto")]
    [SerializeField] private TextMeshProUGUI objdetexto;
    [Header("Array de botões")]
    [SerializeField] private GameObject[] botoes;
    private bool CenaSeg = false;
    private int i = 0;
    void Awake()
    {
        StartCoroutine(EfeitoTypping());
        textos[i] = textos[i++];

        if (i == textos.Length)
        {
            StartCoroutine(mudarbool());
        }

    }

    // Update is called once per frame
    void Update()
    {

        if ((Input.GetKeyDown(KeyCode.Space))&& i < textos.Length)
        {
            //objdetexto.text = textos[i];
            StartCoroutine(EfeitoTypping());
            textos[i] = textos[i++];
      
            if (i == textos.Length)
            {
                StartCoroutine(mudarbool());
            }
        }
        if((Input.GetKeyDown(KeyCode.Space)) && CenaSeg == true)
        {
        
           for(int i =0; i < botoes.Length; i++)
            {
                botoes[i].SetActive(true);
            }
        }
        
    }
    public void click()
    {
        if (i < textos.Length)
        {
            //objdetexto.text = textos[i];
            StartCoroutine(EfeitoTypping());
            textos[i] = textos[i++];

            if (i == textos.Length)
            {
                StartCoroutine(mudarbool());
            }
        }
        if (CenaSeg == true)
        {

            for (int i = 0; i < botoes.Length; i++)
            {
                botoes[i].SetActive(true);
            }
        }
    }
    IEnumerator mudarbool()
    {
        yield return new WaitForSeconds(0.5f);
        CenaSeg = true;
    }
    IEnumerator EfeitoTypping()
    {
        var stringOriginal = textos[i];    
        objdetexto.text = "";
        
        var Charrevelados = 0;
        while (Charrevelados < stringOriginal.Length)
        {
            
            while (stringOriginal[Charrevelados] == ' ')
                ++Charrevelados;
            
            ++Charrevelados;

            objdetexto.text = stringOriginal.Substring(0, Charrevelados);
            
            yield return new WaitForSeconds(0.04f);
        }

    }
}
