using System.Collections;
using System.Collections.Generic;
using System.Security.Authentication.ExtendedProtection;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GotoScene : MonoBehaviour
{
    [Header("Cena a ser levado")]
    [SerializeField] Object cena;
    // Start is called before the first frame update
    public void Cena()
    {
        SceneManager.LoadScene(cena.name);
    }
}
