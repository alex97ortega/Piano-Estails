using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public Sprite tilePressed;
    protected bool tapped = false;
    protected int id;
    protected TileGenerator tileGenerator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (tileGenerator.IsGameOver())
            return;
        TileFrame();
    }

    // virtuales
    protected virtual void TileFrame() { }
    public virtual void SetProperties(float posX, int idTecla, int tam, TileGenerator tileG) { }
    public virtual bool CanCreateNewTile() { return false; }
    public virtual bool TilePressFinished() { return tapped; } // esto es para ver si puede pasar a la siguiente tecla presionable
    public virtual void Tap() { }
    // checkea si la coordenada x,y está dentro del tile
    public virtual bool Inside(float x, float y) { return false; }

    // comunes
    public int GetId() { return id; }
    public bool IsTapped() { return tapped; }
}
