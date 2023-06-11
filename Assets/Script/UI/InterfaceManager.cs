using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterfaceManager : MonoBehaviour
{
   
    public Text anim,agro,pop,mana,rock,wood;
    void Start()
    {
        
    }

   
    void Update()
    {
        anim.text = ResourceManager.RManager.Animal.ToString();
        agro.text = ResourceManager.RManager.Vegetal.ToString();
        pop.text = ResourceManager.RManager.Pessoas.ToString();
        mana.text = ResourceManager.RManager.Marvita.ToString();
        rock.text = ResourceManager.RManager.Pedra.ToString();
        wood.text = ResourceManager.RManager.Madeira.ToString();
    }
}

