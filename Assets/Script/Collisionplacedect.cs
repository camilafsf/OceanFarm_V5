using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collisionplacedect : MonoBehaviour
{
    public float raycastDistance = 100f; // Comprimento máximo do raio

    private void Update()
    {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, raycastDistance))
            {
                if (hit.collider.CompareTag("Madeira"))
                {
                    Debug.Log("Objeto sobreposto!");
                   SpawnObj.spaw.activeplace = true;
                }
            }
            else
            {
                Debug.Log("Nenhum objeto colidido!");
                SpawnObj.spaw.activeplace = false;
            }
        
    }
}
