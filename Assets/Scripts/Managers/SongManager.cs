using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongManager : MonoBehaviour
{
    public AudioSource canal1, canal2, canal3, canal4;

    public AudioClip[] song1;

    public void PlayTecla(int tecla)
    {
        if(!canal1.isPlaying)
        {
            canal1.clip = song1[tecla % song1.Length];
            canal1.Play();
        }
        else if (!canal2.isPlaying)
        {
            canal2.clip = song1[tecla % song1.Length];
            canal2.Play();
        }
        else if (!canal3.isPlaying)
        {
            canal3.clip = song1[tecla % song1.Length];
            canal3.Play();
        }
        else
        {
            canal4.clip = song1[tecla % song1.Length];
            canal4.Play();
        }
    }
}
