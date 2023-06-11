using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlaylist : MonoBehaviour
{
    private static SoundPlaylist instance;
    public static SoundPlaylist Instance { get { return instance; } }
    public bool playing;
    //Fonte de audio
    public AudioSource source;
    //vetor para as musicas serem indexadas
    [Header("vetor de músicas a serem tocadas")]
    public AudioClip[] musicclips;
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
    void Start()
    {
        //defini que está tocando ao iniciar e inicia o enum que roda a lista de musicas
        playing = true;
        StartCoroutine(Playmusicloop());
    }
    private void Update()
    {
        if(PlayerPrefs.GetString("AudioState")== "muted")
        {
            source.mute= true;
        }
        else
        {
            source.mute= false;
        }
    }

    // Update is called once per frame
    IEnumerator Playmusicloop()
    //play em loop de um vetor de clipes
    {
        yield return null;
        while (playing)
        {
            for (int i = 0; i < musicclips.Length; i++)
            {
                source.clip = musicclips[i];
                source.Play();
                while (source.isPlaying)
                {
                    yield return null;
                }
            }
        }
    }
}
