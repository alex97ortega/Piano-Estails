using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    int numCancion;
    int puntosNivel;

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
    public int GetNumCancion() { return numCancion; }
}
