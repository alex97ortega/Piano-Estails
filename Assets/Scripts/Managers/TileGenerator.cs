using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGenerator : MonoBehaviour
{
    public NormalTile normalTilePrefab;
    public DoubleTile doubleTilePrefab;
    public LongTile longTilePrefab;
    public SongManager songManager;
    public Parser parser;
    public GameObject gameOver;
    public float[] velocitis;

    List<Tile> tiles;
    Queue<int> tilesToCreate;
    Tile lastTileCreated;
    Tile tileToPress;
    float lastTileX;
    int currentTecla;
    int tilesCreated;
    bool isGameOver = false;
    float initialVel;
    float startTime;

    enum TileType
    {
        NORMAL,
        DOUBLE,
        LONG
    }

    // Start is called before the first frame update
    void Start()
    {
        GameManager gm = FindObjectOfType<GameManager>();
        if (gm)
            initialVel = velocitis[gm.GetNumCancion()];
        else
            initialVel = 5;
        startTime = Time.time;
        tilesToCreate = parser.ParseTxtCurrentSong();
        
        currentTecla = 0;
        lastTileX = 0;
        tilesCreated = 0;

        tiles = new List<Tile>();
        CreateNewTile();
        tileToPress = lastTileCreated;
    }

    // Update is called once per frame
    void Update()
    {
        if(lastTileCreated.CanCreateNewTile())
        {
            CreateNewTile();
        }
    }

    // comprueba si se ha tapeado alguna tecla de la lista
    public void Tap(float x, float y)
    {
        if (tileToPress.GetComponent<DoubleTile>() != null)
        {
            Tile posibleTileToPress = tileToPress.GetComponent<DoubleTile>().GetPartner();
            if(tileToPress.Inside(x, y))
            {
                TeclaPresionada(tileToPress);
            }
            if (posibleTileToPress.Inside(x, y))
            {
                TeclaPresionada(posibleTileToPress);
            }
        }
        else
        {
            if (tileToPress.Inside(x, y))
            {
                TeclaPresionada(tileToPress);
            }
            else
                GameOver();
        }
    }
    private void TeclaPresionada(Tile tilePresionada)
    {
        tilePresionada.Tap();
        if (tilePresionada.TilePressFinished())
        {
            GameManager gm = FindObjectOfType<GameManager>();
            if(gm)
                gm.IncrPuntos(1);
            currentTecla++;
            //buscar la proxima tecla que se puede tapear
            tileToPress = null; // esto es necesario por si presionamos una tecla sin que haya aparecido la siguiente
            foreach (var t in tiles)
            {
                if (t.GetId() == currentTecla)
                    tileToPress = t;
            }
        }
    }
    public void GameOver()
    {
        gameOver.SetActive(true);
        isGameOver = true;
    }
    public bool IsGameOver() { return isGameOver; }
    private void CreateNewTile()
    {
        int nextTile = tilesToCreate.Dequeue();

        int tam = 1; // tamaño de la tecla por si es de las largas
        float newX;
        do
        {
            newX = -2.25f + 1.5f * Random.Range(0, 4);
        } while (newX == lastTileX);

        switch (nextTile)
        {
            case 0:
                // para que no coincida misma posicion ninguna de las 2 teclas
                if (lastTileX == -2.25f || lastTileX == 0.75f)
                    newX = 2.25f;
                else
                    newX = -2.25f;
                lastTileCreated = Instantiate(doubleTilePrefab);
                break;
            case 1:
                // para que no coincida misma posicion con ninguna de las 2 teclas anteriores
                if (lastTileCreated && lastTileCreated.GetComponent<DoubleTile>()!= null)
                {
                    if (lastTileX == -2.25f || lastTileX == 0.75f)
                        newX = -0.75f + 3 * Random.Range(0, 2);
                    else
                        newX = -2.25f + 3 * Random.Range(0, 2);
                }
                lastTileCreated = Instantiate(normalTilePrefab);
                break;
            default:
                tam = nextTile;
                // para que no coincida misma posicion con ninguna de las 2 teclas anteriores
                if (lastTileCreated && lastTileCreated.GetComponent<DoubleTile>() != null)
                {
                    if (lastTileX == -2.25f || lastTileX == 0.75f)
                        newX = -0.75f + 3 * Random.Range(0, 2);
                    else
                        newX = -2.25f + 3 * Random.Range(0, 2);
                }
                lastTileCreated = Instantiate(longTilePrefab);
                break;
        }

        lastTileX = newX;
        lastTileCreated.SetProperties(newX, tilesCreated, tam, this);
        tiles.Add(lastTileCreated);
        tilesCreated++;

        // esto es necesario por si presionamos una tecla sin que haya aparecido la siguiente
        if (tileToPress == null)
            tileToPress = lastTileCreated;

        // bucle infinito de la cancion
        tilesToCreate.Enqueue(nextTile);
    }

    public void PlayTeclaSound()
    {
        songManager.PlayTecla(currentTecla);
    }
    public float GetVel() { return ((initialVel +(0.1f * (Time.time-startTime))) * Time.deltaTime) ; }
}
