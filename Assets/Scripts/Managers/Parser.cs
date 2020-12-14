using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parser : MonoBehaviour
{
    // fichero de texto text asset para arrastrar
    public TextAsset[] songsTxts;
    

    public Queue<int> ParseTxtCurrentSong()
    {
        GameManager gm = FindObjectOfType<GameManager>();
        int cancion = 0;
        if (gm)
            cancion = gm.GetNumCancion();
        string file = songsTxts[cancion].text;

        Queue<int> tileQueue = new Queue<int>();

        foreach (char c in file)
        {
            if (c != '\n' && c != ' ')
            {
                int num = c - '0'; // restamos caracter 0 para poder tener el numero que es como un int
                tileQueue.Enqueue(num);
            }
        }
        return tileQueue;
    }
}
