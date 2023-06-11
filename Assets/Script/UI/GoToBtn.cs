using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToBtn : MonoBehaviour
{
    [SerializeField]private string scn;
    [SerializeField]private GameObject Fade;
    [SerializeField] private int timer =1;
    public void Goto()
    {
        StartCoroutine(gotoafter());
    }
    IEnumerator gotoafter()
    {
        Fade.SetActive(true);
        yield return new WaitForSeconds(timer);
        SceneManager.LoadScene(scn);
    }
}
