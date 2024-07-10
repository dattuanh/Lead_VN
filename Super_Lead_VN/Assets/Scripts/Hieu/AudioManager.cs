using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Source")]
    [SerializeField] AudioSource MusicSource;
    [SerializeField] AudioSource SfxSource;

    [Header("Audio Clip")]
    public AudioClip background;

    private void Start()
    {
        MusicSource.clip = background;
        MusicSource.Play();
    }
}
