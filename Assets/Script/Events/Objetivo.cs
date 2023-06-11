using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class Objetivo : MonoBehaviour
{
    public TextMeshProUGUI obj1;
    public TextMeshProUGUI obj2;
    public TextMeshProUGUI obj3;
    public TextMeshProUGUI obj4;

    private bool isobj1ocup = false;
    private bool isobj2ocup = false;
    private bool isobj3ocup = false;

    public int meta;
    public string tag;

    public int valor;
    public string ver;

    public int pessoascont;

    private void Update()
    {
        obj4.text = ResourceManager.RManager.estrelas.ToString()+" Estrelas conquistadas";
        if(isobj1ocup)
        {
            GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag(tag);
            if (objectsWithTag.Length == meta)
            {
                obj1.text = "";
                somarestrelas();
                isobj1ocup = false;

            }
        }
        else
        {
            int sorte = Random.Range(0, 3);
            print(sorte);
            if (sorte == 0)
            {
                tag = "Casas";
                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag(tag);
                meta = objectsWithTag.Length + 10;
                obj1.text = "Construa mais "+ meta.ToString() + " Casas para bater a Meta";
            }
            else if (sorte == 1)
            {
                tag = "Madeira";
                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag(tag);
                meta = objectsWithTag.Length + 12;
                obj1.text = "Construa mais " +meta.ToString()+" Produtures de madeira para bater a Meta";
            }
            else if (sorte == 2)
            {
                tag = "Pedra";
                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag(tag);
                meta = objectsWithTag.Length + 12;
                obj1.text = "Construa mais "+meta.ToString()+" Produtores de pedra para bater a Meta";
            }
            isobj1ocup = true;
        }

        if (isobj2ocup)
        {
            if(ver == "1")
            {
                if (ResourceManager.RManager.Madeira >= valor)
                {
                    obj2.text = "";
                    somarestrelas();
                    isobj2ocup = false;
                }
            } else if(ver == "2")
            {
                if (ResourceManager.RManager.Pedra >= valor)
                {
                    obj2.text = "";
                    somarestrelas();
                    isobj2ocup = false;
                }
            }
           
        }
        else
        {
            int sorte = Random.Range(0, 2);
            print(sorte);
            if (sorte == 0)
            {
                valor = ResourceManager.RManager.Madeira + 100;
                ver = "1";
                obj2.text = "Consiga mais de " + valor + " em Madeira";
            }
            else if (sorte == 1)
            {
                valor = ResourceManager.RManager.Pedra + 100;
                ver = "2";
                obj2.text = "Consiga mais de " + valor + " em Pedra";
            }
            isobj2ocup = true;
        }
        if (isobj3ocup)
        {
            if(ResourceManager.RManager.Pessoas >= pessoascont)
            {
                obj3.text = "";
                somarestrelas();
                isobj3ocup = false;
            }
        }
        else 
        {
            pessoascont = ResourceManager.RManager.Pessoas + 50;
            obj3.text = "tenha uma população igual de " + pessoascont;
            isobj3ocup = true;
        }
    }
    void somarestrelas()
    {
        ResourceManager.RManager.estrelas += 10;
    }

}
