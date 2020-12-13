using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleTile : Tile
{
    public DoubleTile doubleTilePrefab;
    DoubleTile partner;

    public void SetPartner(DoubleTile t) { partner = t; }
    public DoubleTile GetPartner() { return partner; }

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
        // crea la segunda tecla
        if(partner == null)
        {
            partner = Instantiate(doubleTilePrefab);
            partner.SetPartner(this);
            float partnerPosX;
            switch(posX)
            {
                case -2.25f:
                    partnerPosX = 0.75f;
                    break;
                case -0.75f:
                    partnerPosX = 2.25f;
                    break;
                case 0.75f:
                    partnerPosX = -2.25f;
                    break;
                default:
                    partnerPosX = -0.75f;
                    break;
            }
            partner.SetProperties(partnerPosX, id, tileGenerator);
        }
    }

    public override bool CanCreateNewTile()
    {
        return (transform.position.y <= 3.9f);
    }
    public override bool TilePressFinished()
    {
        return (tapped && partner.IsTapped());
    }
    public override void Tap()
    {
        if (!tapped)
        {
            tapped = true;
            GetComponent<SpriteRenderer>().sprite = tilePressed;
            if(!partner.IsTapped())
                tileGenerator.PlayTeclaSound();
        }
    }
}
