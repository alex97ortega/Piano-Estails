using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalTile : Tile
{
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

    public override void SetProperties(float posX, int idTecla, TileGenerator tileG)
    {
        transform.position = new Vector3(posX, transform.position.y, 0);
        id = idTecla;
        tileGenerator = tileG;
    }

    public override bool CanCreateNewTile()
    {
        return (transform.position.y <= 3.9f);
    }
    public override void Tap()
    {
        if (!tapped)
        {
            tapped = true;
            GetComponent<SpriteRenderer>().sprite = tilePressed;
            tileGenerator.PlayTeclaSound();
        }
    }
}
