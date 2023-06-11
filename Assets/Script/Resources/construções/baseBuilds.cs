using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class baseBuilds : MonoBehaviour
{

    public float Tempo;
    public int Indice;

    Vector3 targetPosition;
    bool isFollowing = false;
    //public static GridController grid;
    public virtual void Construir(builDefault prefab, int indice)
    {

        int Gastamadeira = prefab.MadeiraGastoC;
        int Gastapedra = prefab.PedraGastoC;
        int Gastapessoas = prefab.PessoaGastoC;
        int GastaMarvita = prefab.ManaGastoC;
        int restoMadeira, restoPessoas, restoPedra, restoMarvita;

        restoMadeira = ResourceManager.RManager.Madeira - prefab.MadeiraGastoC;
        restoPessoas = ResourceManager.RManager.Pedra - prefab.PedraGastoC;
        restoPedra = ResourceManager.RManager.Pessoas - prefab.PessoaGastoC;
        restoMarvita = ResourceManager.RManager.Marvita - prefab.ManaGastoC;

        if (restoMadeira >= 0 && restoPessoas >= 0 && restoPedra >= 0 && restoMarvita >= 0)
        {
            SpawnObj.spaw.SelectObject(indice);
            ResourceManager.RManager.Madeira -= Gastamadeira;
            ResourceManager.RManager.Pedra -= Gastapedra;
            ResourceManager.RManager.Pessoas -= Gastapessoas;

        }

        else
        {
            Debug.Log("não pode construir");
            //fazer algo aqui para dar um feedback q não é possível construir
        }
    }

    public virtual void GastarRecursos(builDefault prefab)
    {
        if (Pause.pause.resourcePause)
        {
            int madeira = prefab.MadeiraGasta;
            int pedra = prefab.PedraGasta;
            int pessoas = prefab.PessoasGastas;
            int marvita = prefab.marvitaGastas;
            int vegetal = prefab.vegetalGastos;
            int animal = prefab.animalGastos;
            float tempo = prefab.tempo;
            int restoMadeira, restoPessoas, restoPedra, restoMarvita, restoAnimal, restoVegetal;

            restoMadeira = ResourceManager.RManager.Madeira - prefab.MadeiraGasta;
            restoPessoas = ResourceManager.RManager.Pedra - prefab.PedraGasta;
            restoPedra = ResourceManager.RManager.Pessoas - prefab.PessoasGastas;
            restoMarvita = ResourceManager.RManager.Marvita - prefab.marvitaGastas;
            restoAnimal = ResourceManager.RManager.Animal - prefab.animalGastos;
            restoVegetal = ResourceManager.RManager.Vegetal - prefab.vegetalGastos;
            ResourceManager.RManager.Madeira -= madeira;
            ResourceManager.RManager.Pedra -= pedra;
            ResourceManager.RManager.Pessoas -= pessoas;
            ResourceManager.RManager.Marvita -= marvita;
            ResourceManager.RManager.Vegetal -= vegetal;
            ResourceManager.RManager.Animal -= animal;

            if (restoMadeira >= 0 && restoPessoas >= 0 && restoPedra >= 0 && restoMarvita >= 0 && restoAnimal >= 0 && restoVegetal >= 0)
            {
                prefab.PodeGerar = true;

            }
            else
            {
                prefab.PodeGerar = false;
            }
        }
    }


    public virtual void GerarRecursos(builDefault prefab)
    {
        if (Pause.pause.resourcePause)
        {
            int madeira = prefab.Madeira;
            int pedra = prefab.Pedra;
            int pessoas = prefab.Pessoas;
            int marvita = prefab.marvita;
            int vegetal = prefab.vegetal;
            int animal = prefab.animal;
            float tempo = prefab.tempo;
            ResourceManager.RManager.Madeira += madeira;
            ResourceManager.RManager.Pedra += pedra;
            ResourceManager.RManager.Pessoas += pessoas;
            ResourceManager.RManager.Marvita += marvita;
            ResourceManager.RManager.Vegetal += vegetal;
            ResourceManager.RManager.Animal += animal;
            /*if (prefab.PodeGerar == true)
            {

            }
            */
        }
    }

    public IEnumerator GastaeGeraRecursos(float tempo, int indice)
    {

        while (true)
        {
            GastarRecursos(ResourceManager.RManager.Builds[indice]);
            GerarRecursos(ResourceManager.RManager.Builds[indice]);
            yield return new WaitForSeconds(tempo);
        }
    }

    public virtual void RecebeParametros(float tempo, int indice)
    {
        Tempo = tempo;
        Indice = indice;
    }
}

// Instantiate(prefab.prefabBuild);
/*   Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
   RaycastHit hit;
   if (Physics.Raycast(ray, out hit, 10000f))
   {
       Vector3 tilePos = new Vector3(Mathf.RoundToInt(hit.point.x), 0, Mathf.RoundToInt(hit.point.z));
       if(hit.collider != null)
       {
           Instantiate(prefab.prefabBuild, tilePos, Quaternion.identity);
           //prefab.prefabBuild.transform.position = tilePos; 
       }
   }

   /*  Vector3 mousePosition = Input.mousePosition;
     mousePosition.z = Camera.main.nearClipPlane;

     Vector3 pos = Camera.main.ScreenToViewportPoint(mousePosition);
     Instantiate(prefab.prefabBuild, pos, Quaternion.identity);

   if (Input.GetMouseButtonDown(0))
   {
       Vector3 mousePosition = Input.mousePosition;
       mousePosition.z = 10; // Define uma distância do plano da câmera
       Vector3 spawnPosition = Camera.main.ScreenToWorldPoint(mousePosition);
       Instantiate(prefab.prefabBuild, spawnPosition, Quaternion.identity);
   }


if (!isFollowing )
  {
      // Instancia o objeto onde o mouse está
      Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
      mousePosition.y = 1f;
      Instantiate(prefab.prefabBuild);
      prefab.prefabBuild.transform.position = mousePosition;

      // Começa a seguir o mouse
      isFollowing = true;
  }*/

//  transform.position = Vector3.MoveTowards(transform.position, mousePosition, Time.deltaTime * 10f);
//  GridController.grid.SelectObject(prefab.prefabBuild);
//  Instantiate(prefab.prefabBuild);


/* public void Update(builDefault prefab)
    {
        if (isFollowing)
        {
            // Move o objeto em direção ao mouse
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.y = 1f;
            prefab.prefabBuild.transform.position = Vector3.MoveTowards(transform.position, mousePosition, Time.deltaTime * 10f);

            // Checa se o objeto chegou no ponto de destino (onde o usuário clicou)
            if (Input.GetMouseButtonDown(0))
            {
                prefab.prefabBuild.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                //targetPosition.z = 0f;

                // Para de seguir o mouse
                isFollowing = false;
            }
        }
        else
        {
            // Mantém o objeto no ponto de destino
            prefab.prefabBuild.transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * 5f);
        }
    }*/