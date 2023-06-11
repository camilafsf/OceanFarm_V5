using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basetrocas : MonoBehaviour
{
    private int perder, ganhar;
    public void trocaanimad()
    {
        ResourceManager.RManager.Animal -= 100;
        ResourceManager.RManager.Madeira += 10;
    }
    public void trocavegped()
    {
        ResourceManager.RManager.Vegetal -= 100;
        ResourceManager.RManager.Pedra += 10;
    }
    public void conq1()
    {
        ResourceManager.RManager.Madeira -= 100;
        ResourceManager.RManager.Pedra -= 100;
        ResourceManager.RManager.estrelas += 1;
    }
    public void conq2()
    {
        ResourceManager.RManager.Madeira -= 200;
        ResourceManager.RManager.Pedra -= 200;
        ResourceManager.RManager.estrelas += 1;
    }
    public void conq3()
    {
        ResourceManager.RManager.Madeira -= 500;
        ResourceManager.RManager.Pedra -= 500;
        ResourceManager.RManager.estrelas += 1;
    }
    public void conq4()
    {
        ResourceManager.RManager.Madeira -= 1000;
        ResourceManager.RManager.Pedra -= 1000;
        ResourceManager.RManager.estrelas += 1;
    }
}

