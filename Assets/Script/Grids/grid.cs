using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grid : MonoBehaviour
{
    public static grid Grid;
    public Camera SceneCamera;
    private Vector3 LastPosition;
    private LayerMask PlacementLayerMask;
    public Vector3 mousePos;
    public GameObject prefab;
    private void Awake()
    {
        Grid = this;
        SceneCamera = Camera.main;
    }
    public Vector3 GetSelectMapPosition()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = SceneCamera.nearClipPlane;
        Ray ray = SceneCamera.ScreenPointToRay(mousePos);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, 1000, PlacementLayerMask))
        {
            LastPosition = hit.point;
        }
        return LastPosition;
    }

    public void Contruir(GameObject prefab)
    {
        if (ResourceManager.RManager.construindo == true)
        {
           
            prefab = Instantiate(ResourceManager.RManager.atual);  
            ResourceManager.RManager.mousePosition = grid.Grid.GetSelectMapPosition();
            ResourceManager.RManager.construindo = false;
        }
    }

    public void FixedUpdate()
    {
       /* Vector3 mousePos = Input.mousePosition;
        mousePos.z = SceneCamera.nearClipPlane;
        Ray ray = SceneCamera.ScreenPointToRay(mousePos);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 1000, PlacementLayerMask))
        {
            LastPosition = hit.point;
        }*/
    }
    private void Update()
    {
        if (prefab != null)
        {
            Vector3 mousePosition = GetSelectMapPosition();
            prefab.transform.position = mousePosition;
        }

      /*  Vector3 mousePos = Input.mousePosition;
        mousePos.z = SceneCamera.nearClipPlane;
        prefab.transform.position = mousePos;
        Debug.Log(mousePos);

        //Contruir(ResourceManager.RManager.atual);
      */
    }


}
