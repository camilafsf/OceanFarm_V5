using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOut : MonoBehaviour
{
    [SerializeField] private int timer = 1;
    // Start is called before the first frame update
    private void Awake()
    {
       
        StartCoroutine(FadeDes());
    }
    
    IEnumerator FadeDes()
    {
        yield return new WaitForSeconds(timer);
        this.gameObject.SetActive(false);
        
    }
}
