using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    GameManager gm;
    private void Start()
    {
        gm = FindObjectOfType<GameManager>();
        if(gm)
            gm.RestartPuntos();
    }
    public void ChangeToGamePlay(int cancion)
    {
        gm.SetCancion(cancion);
        SceneManager.LoadScene("GamePlay");
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene("GamePlay");
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
