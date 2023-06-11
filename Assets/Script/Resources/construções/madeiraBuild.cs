using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class madeiraBuild : baseBuilds
{

    public override void Construir(builDefault prefab, int indice)
    {
        base.Construir(prefab, indice);

        //  GridController.grid.SelectObject(prefab.prefabBuild);

    }

    public override void GastarRecursos(builDefault prefab)
    {
        base.GastarRecursos(prefab);
    }

    public override void RecebeParametros(float tempo, int indice)
    {
        base.RecebeParametros(tempo, indice);
    }
    public void Start()
    {

        StartCoroutine(GastaeGeraRecursos(Tempo, Indice));
    }




}
