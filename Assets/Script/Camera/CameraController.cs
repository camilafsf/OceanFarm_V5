using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    /// Descrição 
    /// Controlador d camera tanto com inputs em teclado quanto em mouse
    /// Descrição  <summary>
    /// Descrição 
    // var gerais
    public Transform cameraTransform;
    public float normalSpeed;
    public float FastSpeed;
    public float movementSpeed;
    public float movementTime;
    public float rotationAmount;
    public Vector3 zoomAmount;
    //zoom var
    public Vector3 newPosition;
    public Quaternion newRotation;
    public Vector3 newZoom;
    public float MinZoom = 4f;
    public float MaxZoom = 25f;
    // var de mouse
    public Vector3 dragStartPosition;
    public Vector3 dragCurrentPosition;
    public Vector3 rotateStartPosition;
    public Vector3 RotateCurrentPosition;


    void Start()
    {
       
        newPosition = transform.position;
        newRotation = transform.rotation;
        newZoom = cameraTransform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if(newZoom.y < MinZoom)
        {
            newZoom.y = MinZoom;
        }
        if(newZoom.y > MaxZoom)
        {
            newZoom.y = MaxZoom;
        }
        HandleMouseInput();
        HandleMovementInput();
    }
    void HandleMouseInput()
    {
        if(Input.mouseScrollDelta.y != 0)
            // dá zoom com base no movimento do scrool
        { 
            newZoom += Input.mouseScrollDelta.y * zoomAmount;
        }
        if (Input.GetMouseButtonDown(1))
            //cria um plano para pegar a posição inicial do movimento de arraste
        {
            Plane plane= new Plane(Vector3.up, Vector3.zero);

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            float entry;
            
            if(plane.Raycast(ray, out entry))
            {
                dragStartPosition = ray.GetPoint(entry);
            }
        }
        if (Input.GetMouseButton(1))
        {
            // cria um plano(apenas em vector) e usando raycast verifica o movimento de puxar do mouse para gerar movimento por arraste
            Plane plane = new Plane(Vector3.up, Vector3.zero);

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            float entry;

            if (plane.Raycast(ray, out entry))
            {
                dragCurrentPosition = ray.GetPoint(entry);

                newPosition = transform.position + dragStartPosition - dragCurrentPosition;
            }
        }
        if (Input.GetMouseButtonDown(2))
            //pega a posição inicial de rotação do mouse
        {
            rotateStartPosition = Input.mousePosition;
        }
        if (Input.GetMouseButton(2))
            //realiza o movimento de rotação
        {
            RotateCurrentPosition = Input.mousePosition;

            Vector3 difference = rotateStartPosition - RotateCurrentPosition;

            rotateStartPosition = RotateCurrentPosition;

            newRotation *= Quaternion.Euler(Vector3.up * (-difference.x / 5f));
        }
    }
    void HandleMovementInput()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            movementSpeed = FastSpeed;
        }
        //altera se segurar shift entre o modo rápido e o modo lento
        else
        {
            movementSpeed = normalSpeed;
        }
        if(Input.GetKey(KeyCode.W)|| Input.GetKey(KeyCode.UpArrow))
        //move teclado
        {
            newPosition += (transform.forward * movementSpeed);
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        //move teclado
        {
            newPosition += (transform.forward * -movementSpeed);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        //move teclado
        {
            newPosition += (transform.right * movementSpeed);
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            newPosition += (transform.right * -movementSpeed);
            //move teclado
        }
        if (Input.GetKey(KeyCode.Q))
        {
            newRotation *= Quaternion.Euler(Vector3.up * rotationAmount);
            //rotaciona teclado
        }
        if (Input.GetKey(KeyCode.E))
        {
            newRotation *= Quaternion.Euler(Vector3.up * -rotationAmount);
            //rotaciona teclado
        }
        if (Input.GetKey(KeyCode.KeypadPlus))
        {
            newZoom += zoomAmount;
            //bota zoom teclado
        }
        if (Input.GetKey(KeyCode.KeypadMinus))
        {
            newZoom -= zoomAmount;
            //tira zoom teclado
        }

        transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime*movementTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, Time.deltaTime * movementTime);
        cameraTransform.localPosition = Vector3.Lerp(cameraTransform.localPosition, newZoom, Time.deltaTime * movementTime);

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "BarreiraSul")
        {
            newPosition = new Vector3(0, 0, 50f);
        }
        if (other.gameObject.tag == "BarreiraNorte")
        {
            newPosition = new Vector3(0, 0, 0);
        }
        if (other.gameObject.tag == "BarrieraLeste")
        {
            newPosition = new Vector3(0f, 0, 0f);
        }
        if (other.gameObject.tag == "BarreiraOeste")
        {
            newPosition = new Vector3(280f, 0, 0f);
        }
    }

}

