using UnityEngine;

public class SoundObject : MonoBehaviour, IAudioObserver
{
    public AudioSource audioSource;
    public bool isMuted = false;

    private void Start()
    {
        // Carregar estado mutado se já foi salvo
        if (PlayerPrefs.HasKey("soundMuted"))
        {
            isMuted = PlayerPrefs.GetInt("soundMuted") == 1;
        }
        else
        {
            isMuted = false;
        }

        // Registrar como um observador de áudio
        AudioManager.instance.RegisterObserver(this);

        // Atualizar o estado mutado
        OnAudioStateChanged(isMuted);
    }
    private void Update()
    {
       
    }

    private void OnDestroy()
    {
        // Remover o registro como observador de áudio
        AudioManager.instance.UnregisterObserver(this);
    }

    public void OnAudioStateChanged(bool isMuted)
    {
        this.isMuted = isMuted;

        if (isMuted)
        {
            audioSource.Pause();
        }
        else
        {
            audioSource.UnPause();
        }
    }
}