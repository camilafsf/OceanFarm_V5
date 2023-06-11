using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SistemadeBandeiras : MonoBehaviour
{
    //obj a ter o sprite mudado 
    [Header("Obj com a sprite")]
    Image m_Image;
    //vetor de sprites com as imagens de bandeira da cena
    [Header("vetor de imagens de bandeira")]
    [SerializeField] private Sprite[] Bandeiras;
    private int i;
    void Awake()
    {
        // ao acordar definir o obj a ter o sprite modificado e avançar a bandeira
        m_Image = GetComponent<Image>();
        Bandeiras[i] = Bandeiras[i++];
    }

    
    void Update()
    {
        // a cada espaço pressionado avançar no vetor
        if (Input.GetKeyDown(KeyCode.Space) && i < Bandeiras.Length)
        {
            m_Image.sprite = Bandeiras[i++];
        }
    }
    public void click()
    {
        // a cada click no obj chamando o metodo avançar no vetor
        if (i < Bandeiras.Length)
        {
            m_Image.sprite = Bandeiras[i++];
        }
    }
}
