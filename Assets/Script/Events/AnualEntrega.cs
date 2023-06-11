using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnualEntrega : MonoBehaviour
{
    [SerializeField]private int Vida = 2;
    public GameObject QuadrodeEntrega;
    private bool LastChance = false;
    public static AnualEntrega anual;
    float valor =730;
    // Start is called before the first frame update
    private void Awake()
    {
        anual = this;
    }

    public void decisão()
    {
        QuadrodeEntrega.SetActive(true);
        while (QuadrodeEntrega.activeSelf)
        {
            Calendar.date.Paused = true;
            TImer.Timer.stop = true;
        }
    }
    public void Recusar()
    {
       
        if (LastChance == true)
        {
            print("Lose");
        }
        if (Vida==2)
        {
            LastChance = true;
        }
        Calendar.date.Paused = false;
        TImer.Timer.stop = false;
        Vida--;
        print(Vida);
        QuadrodeEntrega.SetActive(false);
        
    }
    public void Enviar()
    {
        valor += valor * (valor / (valor * 0.6f));
        ResourceManager.RManager.Vegetal = (int)valor; 
        ResourceManager.RManager.Animal = (int)valor;
        Calendar.date.Paused = false;
        TImer.Timer.stop = false;
        QuadrodeEntrega.SetActive(false);
        
    }
   
}
