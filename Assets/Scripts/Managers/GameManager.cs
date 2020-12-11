using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    int puntosNivel;

    // Start is called before the first frame update
    void Start()
    {
        
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
}
