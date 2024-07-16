using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioLead : MonoBehaviour
{
    [Header("------------ Audio Source --------------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("------------ Audio Clip --------------")]
    public AudioClip background;
    public AudioClip jump;
    public AudioClip running;
    public AudioClip motorcrash;
    public AudioClip motorexplode;

    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }
    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}
