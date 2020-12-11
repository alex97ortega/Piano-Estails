using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGenerator : MonoBehaviour
{
    public Tile tilePrefab;
    public SongManager songManager;

    List<Tile> tiles;
    Tile lastTileCreated;
    float lastTileX;
    int currentTecla;

    // Start is called before the first frame update
    void Start()
    {
        currentTecla = 0;
        tiles = new List<Tile>();
        lastTileCreated = Instantiate(tilePrefab);
        lastTileX = -2.25f + 1.5f * Random.Range(0, 4);
        lastTileCreated.SetPos(lastTileX);
        tiles.Add(lastTileCreated);
    }

    // Update is called once per frame
    void Update()
    {
        if(lastTileCreated.CanCreateNewTile())
        {
            lastTileCreated = Instantiate(tilePrefab);
            float newX;
            do
            {
                newX = -2.25f + 1.5f * Random.Range(0, 4);
            } while (newX == lastTileX);
            lastTileX = newX;
            lastTileCreated.SetPos(lastTileX);
            tiles.Add(lastTileCreated);
        }
    }

    // comprueba si se ha tapeado alguna tecla de la lista
    public void Tap(float x, float y)
    {
        foreach (var t in tiles)
        {
            if (t && t.Inside(x, y))
            {
                if(!t.IsTapped())
                {
                    t.Tap();
                    songManager.PlayTecla(currentTecla);
                    FindObjectOfType<GameManager>().IncrPuntos(1);
                    currentTecla++;
                }
                return;
            }
        }
    }
}
