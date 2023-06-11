using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class SpawnObj : MonoBehaviour
{

    [Header("Preencher")]

    [SerializeField] GameObject[] objects;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private Toggle gridToggle;
    [SerializeField] private float gridSize;
    [SerializeField] private float rotateAmount;
    [SerializeField] private float PlaceY;

    [Header("Somente Debug")]
    [SerializeField] GameObject pendingObj;
    public static SpawnObj spaw;
    private Vector3 pos;
    private RaycastHit hit;
    private bool gridOn = true;
    public bool activeplace = false;

    private void Start()
    {

    }

    public void Awake()
    {
        spaw = this;
    }
    private void FixedUpdate()
    {

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 1000, layerMask))
        {
            pos = hit.point;
        }
    }

    private void Update()
    {

        if (pendingObj != null)
        {

            if (gridOn)
            {
                pendingObj.transform.position = new Vector3(
                RoundToNearestGrid(pos.x),
                RoundToNearestGrid(pos.y),
                RoundToNearestGrid(pos.z));

            }
            else
            {
                pendingObj.transform.position = pos;
            }

            if (Input.GetMouseButtonDown(0) && activeplace == false)
            {

                PlaceObject();
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                RotateObject();
            }


        }
    }

    public void PlaceObject()
    {

        pendingObj = null;
    }

    public void SelectObject(int indice)
    {


        pendingObj = Instantiate(ResourceManager.RManager.Builds[indice].prefabBuild);

        print(pendingObj);
        //pendingObj.transform.Rotate(90f, 0f, 0f, Space.World);
        //0f0f0f
    }


    public void ToggleGrid()
    {
        if (gridToggle.isOn)
        {
            gridOn = true;
        }
        else
        {
            gridOn = false;
        }
    }

    float RoundToNearestGrid(float pos)
    {

        float xDiff = pos % gridSize;

        pos -= xDiff;

        if (xDiff > (gridSize / 2))
        {
            pos += gridSize;
        }

        return pos;

    }

    public void RotateObject()
    {
        pendingObj.transform.Rotate(0.0f, rotateAmount, 0.0f, Space.World);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (pendingObj.gameObject.tag != "Build")
        {
            print("colidindo");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (pendingObj.gameObject.tag != "Build")
        {
            print("colidindo");
        }
    }
}
