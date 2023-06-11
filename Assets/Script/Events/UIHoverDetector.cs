using UnityEngine;
using UnityEngine.EventSystems;

public class UIHoverDetector : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public GameObject externalUIObject;
    public float hoverTimeThreshold = 0.5f; // tempo em segundos

    private float hoverTime = 0.0f;
    public  bool isHovering = false;

    private void Start()
    {
        externalUIObject.SetActive(false); // começa desativado
    }

    private void Update()
    {
        if (isHovering)
        {
            hoverTime += Time.deltaTime;

            if (hoverTime >= hoverTimeThreshold)
            {
                externalUIObject.SetActive(true); // exibe o objeto externo
            }
        }
    }
    public void onclick()
    {
        isHovering = false;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isHovering = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isHovering = false;
        hoverTime = 0.0f;
        externalUIObject.SetActive(false); // desativa o objeto externo
    }
}

