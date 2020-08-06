using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource backgroundMusic;
    public AudioClip[] music;
    private int musicIndex;

    public AudioSource explosionSound;
    public AudioClip[] expSounds;
    private int expSoundIndex;

    public AudioSource lazerSound;
    public AudioClip[] lazSounds;
    private int lazSoundIndex;

    public AudioSource winSound;
    public AudioSource loseSound;

    static public SoundManager instance;
    public void Awake()
    {
        if (SoundManager.instance != null)
        {
            Destroy(gameObject);
            return;
        }
        SoundManager.instance = this;
    }
    public void Start()
    {
        musicIndex = Random.Range(0, music.Length);
        backgroundMusic.clip = music[musicIndex];
        backgroundMusic.Play();

        expSoundIndex = Random.Range(0, expSounds.Length);
        explosionSound.clip = expSounds[expSoundIndex];

        lazSoundIndex = Random.Range(0, lazSounds.Length);
        lazerSound.clip = lazSounds[lazSoundIndex];
    }
}
