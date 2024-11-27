using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource soundeffectsAudioSource, musicAudioSource;


    //Creo el Singletons

    public static AudioManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M)) ToggleMusic();
    }

    public void PlaySound (AudioClip clip)
    {
        soundeffectsAudioSource.PlayOneShot(clip);
    }
             
    private void ToggleMusic()
    {
        musicAudioSource.mute = !musicAudioSource.mute;
    }
}
