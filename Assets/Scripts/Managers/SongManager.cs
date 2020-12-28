using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongManager : MonoBehaviour
{
    public AudioSource canal1, canal2, canal3, canal4;
    
    public AudioClip[] song1;
    public AudioClip[] song2;

    AudioClip[] selectedSong;

    private void Start()
    {
        GameManager gm = FindObjectOfType<GameManager>();
        if (gm == null)
            selectedSong = song2;

        else
        {
            switch(gm.GetNumCancion())
            {
                case 0:
                    selectedSong = song1;
                    break;
                case 1:
                    selectedSong = song2;
                    break;
                default:
                    break;
            }
        }
    }

    public void PlayTecla(int tecla)
    {
        if(!canal1.isPlaying)
        {
            canal1.clip = selectedSong[tecla % selectedSong.Length];
            canal1.Play();
        }
        else if (!canal2.isPlaying)
        {
            canal2.clip = selectedSong[tecla % selectedSong.Length];
            canal2.Play();
        }
        else if (!canal3.isPlaying)
        {
            canal3.clip = selectedSong[tecla % selectedSong.Length];
            canal3.Play();
        }
        else
        {
            canal4.clip = selectedSong[tecla % selectedSong.Length];
            canal4.Play();
        }
    }
}
