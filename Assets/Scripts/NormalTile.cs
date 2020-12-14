using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalTile : Tile
{
    // each frame called from Update
    protected override void TileFrame()
    {
        transform.position -= new Vector3(0, tileGenerator.GetVel(), 0);
        if (transform.position.y <= -6.25f)
        {
            if (tapped)
                Destroy(gameObject);
            else
                tileGenerator.GameOver();
        }
    }

    // set tile properties (position, id, length and parent)
    public override void SetProperties(float posX, int idTecla, int tam, TileGenerator tileG)
    {
        transform.position = new Vector3(posX, transform.position.y, 0);
        id = idTecla;
        tileGenerator = tileG;
    }

    // return true if can create the next tile after this one
    public override bool CanCreateNewTile()
    {
        return (transform.position.y <= 4);
    }

    // actions when the tile is tapped
    public override void Tap()
    {
        if (!tapped && !tileGenerator.IsGameOver())
        {
            tapped = true;
            GetComponent<SpriteRenderer>().sprite = tilePressed;
            tileGenerator.PlayTeclaSound();
        }
    }

    // return true if the point x,y is inside the tile
    public override bool Inside(float x, float y)
    {
        float scaleX = transform.localScale.x / 2;
        float scaleY = transform.localScale.y / 2;

        if (x < (transform.position.x - scaleX) || x > (transform.position.x + scaleX))
            return false;
        if (y < (transform.position.y - scaleY) || y > (transform.position.y + scaleY))
            return false;
        return true;
    }
}
