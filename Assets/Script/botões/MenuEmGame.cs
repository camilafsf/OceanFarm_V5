using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MenuEmGame : MonoBehaviour
{
   //ele salva os dados aqui setados que são chmados via clique por metodos e salva em playerprefs e resgata esses valores em Dadosdetexto
    [SerializeField]private GameObject Menu;
    private bool IsActive=false;
    private bool IsMuted = false;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Menu.SetActive(IsActive = false);
        }
    }
    //tamanho da fonte
    public void fontPEQ()
    {
        //txtFala.fontSize = 18;
        //txtNome.fontSize = 18;
        PlayerPrefs.SetInt("Size", 18);
        PlayerPrefs.Save();
    }
    public void fontMED()
    {
        //txtFala.fontSize = 22;
        //txtNome.fontSize = 22;
        PlayerPrefs.SetInt("Size", 22);
        PlayerPrefs.Save();
    }
    public void fontGRA()
    {
        //txtFala.fontSize = 24;
        //txtNome.fontSize = 24;
        PlayerPrefs.SetInt("Size", 24);
        PlayerPrefs.Save();
    }
    //cor da fonte
    public void corBRA()
    {
        // txtFala.color = Color.white;
        //txtNome.color = Color.white;
        //txtFala.outlineWidth = 0;
        //txtNome.outlineWidth = 0;
        PlayerPrefs.SetString("Color", "white");
        PlayerPrefs.SetFloat("Outline", 0f);
        PlayerPrefs.Save();
    }
    public void corYEL()
    {
        //txtFala.color = Color.yellow;
        //txtNome.color = Color.yellow;
        //txtFala.outlineWidth = 0.2f;
        //txtNome.outlineWidth = 0.2f;
        PlayerPrefs.SetString("Color", "yellow");
        PlayerPrefs.SetFloat("Outline", 0.2f);
        PlayerPrefs.Save();
    }
    //ativa e desativa o menu 
    public void MenuIn()
    {
        IsActive =! IsActive;
        Menu.SetActive(IsActive);
    }
    public void Mute()
    {
        IsMuted = !IsMuted;
        if (IsMuted)
        {
            PlayerPrefs.SetString("AudioState","muted");

        }
       
        else
        {
            PlayerPrefs.SetString("AudioState", "notmuted");
 
        }
           
    }
}
