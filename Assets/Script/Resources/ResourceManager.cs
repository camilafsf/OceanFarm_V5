using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceManager : MonoBehaviour
{
    public static ResourceManager RManager;
    public int Vegetal, Animal, Pedra, Madeira, Marvita, Pessoas, estrelas;
    public builDefault[] Builds;
    public Button[] construir;
    public int constAtual;
    public GameObject atual;
    public baseBuilds build;
    public bool construindo;
    public Vector3 mousePosition;
    void Awake()
    {
        RManager = this;
    }

    private void Start()
    {
        if (construir.Length != Builds.Length)
        {
            Debug.LogError("Os arrays construir e Builds têm tamanhos diferentes.");
            return;
        }

        for (int i = 0; i < construir.Length; i++)
        {
            int Index = i;
            construir[i].onClick.AddListener(() => ReconheceConstrucao(Index));   
            construir[i].image.sprite = Builds[i].Image;
        }

    }
    public void ReconheceConstrucao(int indice)
    {
        atual = Builds[indice].prefabBuild;
        build = new madeiraBuild();
        build.Construir(Builds[indice], indice);
        build.RecebeParametros(Builds[indice].tempo, indice);
        RManager.construindo = true;

    }

    /*public void Contruindo(GameObject prefab)
    {
        if (RManager.construindo == true)
        {
            grid.Grid.Contruir(atual);
            RManager.construindo = false;
        }
    }*/
    private void Update()
    {
        /* if(atual!= null)
         {
             RManager.Contruindo(atual);
         }*/


    }
}
