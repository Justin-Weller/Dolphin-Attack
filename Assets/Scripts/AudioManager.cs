using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    //Singleton script/gameObject persistent across scenes for audio management
    static AudioManager instance;

    // Arrary of AudioSources on gameObject (same order as inspector)
    private static AudioSource[] sounds;

    private void Start()
    {
        MenuMusicCheck();
    }

    void Awake()
    {
                
        if (instance == null)
        {
            instance = this; // In first scene, make us the singleton.
            DontDestroyOnLoad(gameObject);
            sounds = GetComponents<AudioSource>();

        }
        else if (instance != this)
            Destroy(gameObject); // On reload, singleton already set, so destroy duplicate.

        MenuMusicCheck();
        
    }

    private void MenuMusicCheck()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        if (currentScene.name == "Game" && sounds[1].isPlaying)
        {
            StopMenuMusic();
        }
        else if (!sounds[1].isPlaying)
        {
            PlayMenuMusic();
        }
    }

    public void PlayButtonSound()
    {
        sounds[0].Play();
    }

    public void PlayMenuMusic()
    {
        sounds[1].Play();
    }

    public void StopMenuMusic()
    {
        sounds[1].Stop();
    }
}
