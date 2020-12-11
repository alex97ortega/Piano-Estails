using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public Sprite tilePressed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SetPos(float x)
    {
        transform.position = new Vector3(x, transform.position.y, 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= new Vector3(0, 2*Time.deltaTime, 0);
        if (transform.position.y <= -6.25f)
            Destroy(gameObject);
    }

    // checkea si la coordenada x,y está dentro del tile
    public bool Inside(float x, float y)
    {
        float scaleX = transform.localScale.x / 2;
        float scaleY = transform.localScale.y / 2;

        if (x < (transform.position.x - scaleX) || x > (transform.position.x + scaleX))
            return false;
        if (y < (transform.position.y - scaleY) || y > (transform.position.y + scaleY))
            return false;
        return true;
    }

    public void Tap()
    {
        GetComponent<SpriteRenderer>().sprite = tilePressed;
    }

    public bool CanCreateNewTile()
    {
        return (transform.position.y <= 3.9f);
    }
}
