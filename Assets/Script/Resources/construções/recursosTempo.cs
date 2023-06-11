using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class recursosTempo : baseBuilds
{
    float tempo;
    public int indice;
    public void Start()
    {
        tempo = ResourceManager.RManager.Builds[indice].tempo;

        StartCoroutine(GastaeGeraRecursos(tempo, indice));
    }
    public IEnumerator GastaeGeraRecursos(float tempo, int indice)
    {

        while (true)
        {
            base.GastarRecursos(ResourceManager.RManager.Builds[indice]);
            base.GerarRecursos(ResourceManager.RManager.Builds[indice]);
            yield return new WaitForSeconds(tempo);
        }
    }
}
