using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongManager : MonoBehaviour
{
    public AudioSource canal1;

    public AudioClip[] song1;

    public void PlayTecla(int tecla)
    {
        canal1.clip = song1[tecla % song1.Length];
        canal1.Play();
    }
}
