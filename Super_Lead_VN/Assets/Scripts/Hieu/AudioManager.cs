using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Source")]
    [SerializeField] AudioSource MusicSource;
    [SerializeField] AudioSource SfxSource;

    [Header("Audio Clip")]
    public AudioClip background;
    public AudioClip jump;
    public AudioClip running;
    public AudioClip motorcrash;
    public AudioClip motorexplode;
    public AudioClip click;

    private void Start()
    {
        MusicSource.clip = background;
        MusicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SfxSource.PlayOneShot(clip);
    }
}
