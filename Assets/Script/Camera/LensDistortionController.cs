using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class LensDistortionController : MonoBehaviour
{
    public GameObject externalObject;
    public float speed = 1f;
    public float minValue = -1f;
    public float maxValue = 1f;

    private PostProcessVolume postProcessVolume;
    private LensDistortion lensDistortion;
    private float currentValue;
    private float direction = 1f;

    void Start()
    {
        if (externalObject != null)
        {
            postProcessVolume = externalObject.GetComponent<PostProcessVolume>();

            if (postProcessVolume != null)
            {
                postProcessVolume.profile.TryGetSettings(out lensDistortion);
            }
        }
    }

    void Update()
    {
        currentValue += Time.deltaTime * speed * direction;

        if (currentValue > maxValue)
        {
            currentValue = maxValue;
            direction = -1f;
        }
        else if (currentValue < minValue)
        {
            currentValue = minValue;
            direction = 1f;
        }

        if (lensDistortion != null)
        {
            lensDistortion.centerX.value = currentValue;
        }
    }
}
