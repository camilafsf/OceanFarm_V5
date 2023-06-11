using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Dadosdetexto : MonoBehaviour
{
    //obj de ui para o texto 
    public TextMeshProUGUI txtFala;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //armazena do dados vindo da interação do menu de opções
        txtFala.fontSize = PlayerPrefs.GetInt("Size");//tamanho da fonte
        txtFala.outlineWidth = PlayerPrefs.GetFloat("Outline");//margem da fonte
        if(PlayerPrefs.GetString("Color")== "yellow")//cor da fonte
        {
            txtFala.color = Color.yellow;
        }
        else
        {
            txtFala.color = Color.white;
        }
    }
}
