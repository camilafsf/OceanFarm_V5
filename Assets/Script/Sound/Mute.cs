using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class Mute : MonoBehaviour
{
    [SerializeField] private AudioMixer aMix;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider vfxSlider;
    [SerializeField] private TextMeshProUGUI musicTextMeshPro;
    [SerializeField] private TextMeshProUGUI effectTextMeshPro;

    private const float MinValue = 0f;
    private const float MaxValue = 5f;
    private const float MutedValue = -88f;

    private bool isMutedMusic = false;
    private bool isMutedVFX = false;

    private void Start()
    {
        LoadSliderValues();
        UpdateMusicVolume();
        UpdateVFXVolume();
    }

    public void muteMusic()
    {
        isMutedMusic = !isMutedMusic;

        if (isMutedMusic)
        {
            aMix.SetFloat("Music", MutedValue);
            musicSlider.value = MinValue;
            musicTextMeshPro.color = Color.red;
        }
        else
        {
            float value = RemapSliderValueToVolume(musicSlider.value);
            aMix.SetFloat("Music", value);
            if (value >= MaxValue)
            {
                musicSlider.value = MaxValue;
            }
            musicTextMeshPro.color = Color.black;
        }

        SaveSliderValues();
    }

    public void muteVFX()
    {
        isMutedVFX = !isMutedVFX;

        if (isMutedVFX)
        {
            aMix.SetFloat("SoundEffects", MutedValue);
            vfxSlider.value = MinValue;
            effectTextMeshPro.color = Color.red;
        }
        else
        {
            float value = RemapSliderValueToVolume(vfxSlider.value);
            aMix.SetFloat("SoundEffects", value);
            if (value >= MaxValue)
            {
                vfxSlider.value = MaxValue;
            }
            effectTextMeshPro.color = Color.black;
        }

        SaveSliderValues();
    }

    public void OnMusicSliderChanged()
    {
        if (!isMutedMusic)
        {
            float value = RemapSliderValueToVolume(musicSlider.value);
            aMix.SetFloat("Music", value);
            if (value >= MaxValue)
            {
                musicSlider.value = MaxValue;
            }
        }

        SaveSliderValues();
    }

    public void OnVFXSliderChanged()
    {
        if (!isMutedVFX)
        {
            float value = RemapSliderValueToVolume(vfxSlider.value);
            aMix.SetFloat("SoundEffects", value);
            if (value >= MaxValue)
            {
                vfxSlider.value = MaxValue;
            }
        }

        SaveSliderValues();
    }

    private void LoadSliderValues()
    {
        if (PlayerPrefs.HasKey("MusicSliderValue"))
        {
            musicSlider.value = PlayerPrefs.GetFloat("MusicSliderValue");
        }
        else
        {
            musicSlider.value = MaxValue;
        }

        if (PlayerPrefs.HasKey("VFXSliderValue"))
        {
            vfxSlider.value = PlayerPrefs.GetFloat("VFXSliderValue");
        }
        else
        {
            vfxSlider.value = MaxValue;
        }
    }

    private void SaveSliderValues()
    {
        PlayerPrefs.SetFloat("MusicSliderValue", musicSlider.value);
        PlayerPrefs.SetFloat("VFXSliderValue", vfxSlider.value);
        PlayerPrefs.Save();
    }

    private float RemapSliderValueToVolume(float sliderValue)
    {
        if (sliderValue <= 0f)
        {
            return MutedValue;
        }
        else if (sliderValue == 1f)
        {
            return -60f;
        }
        else if (sliderValue == 2f)
        {
            return -40f;
        }
        else if (sliderValue == 3f)
        {
            return -20f;
        }
        else if (sliderValue == 4f)
        {
            return -5f;
        }
        else // sliderValue == 5f
        {
            return 0f;
        }
    }

    private float RemapVolumeToSliderValue(float volumeValue)
    {
        if (volumeValue <= MutedValue)
        {
            return 0f;
        }
        else if (volumeValue == -60f)
        {
            return 1f;
        }
        else if (volumeValue == -40f)
        {
            return 2f;
        }
        else if (volumeValue == -20f)
        {
            return 3f;
        }
        else if (volumeValue == -5f)
        {
            return 4f;
        }
        else // volumeValue == 0f
        {
            return 5f;
        }
    }

    private void UpdateMusicVolume()
    {
        float musicValue = GetFloatFromVolume(aMix, "Music");
        isMutedMusic = Mathf.Approximately(musicValue, MutedValue);
        musicSlider.value = RemapVolumeToSliderValue(musicValue);
        musicTextMeshPro.color = isMutedMusic ? Color.red : Color.black;
    }

    private void UpdateVFXVolume()
    {
        float vfxValue = GetFloatFromVolume(aMix, "SoundEffects");
        isMutedVFX = Mathf.Approximately(vfxValue, MutedValue);
        vfxSlider.value = RemapVolumeToSliderValue(vfxValue);
        effectTextMeshPro.color = isMutedVFX ? Color.red : Color.black;
    }

    private float GetFloatFromVolume(AudioMixer mixer, string parameterName)
    {
        float value;
        if (mixer.GetFloat(parameterName, out value))
        {
            return value;
        }
        return 0f;
    }
}
