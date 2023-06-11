using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Listadeefeitos : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Efeito(string mensagem)
    {
       if(mensagem == "Gasta2Pessoa")
        {
            ResourceManager.RManager.Pessoas -= 2;
        }
       else if(mensagem == "ProdNeg")
        {
            ResourceManager.RManager.Vegetal -= 100;
            ResourceManager.RManager.Animal -= 100;
            ResourceManager.RManager.Pedra -= 10;
            ResourceManager.RManager.Madeira -= 10;
        }
    }
}
