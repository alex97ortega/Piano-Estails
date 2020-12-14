using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    int numCancion;
    int puntosNivel;

    //singletone
    public static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            return instance;
        }
    }

    private void Awake()
    {
        // destruyo el gamemanager si ya hay uno en la escena. 
        // esto me permite cargar distintas escenas que lo necesiten sin tener que ir a la primera
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        numCancion = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncrPuntos(int ptos)
    {
        puntosNivel += ptos;
    }
    public int GetPuntos() { return puntosNivel; }
    public void RestartPuntos() { puntosNivel = 0; }

    public int GetNumCancion() { return numCancion; }
    public void SetCancion(int cancion) { numCancion = cancion; }
}
