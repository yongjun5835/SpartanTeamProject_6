using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    public Texture2D srcTexture;
    Texture2D newTexture;
    SpriteRenderer spriteRenderer;

    float worldWidth, worldHeight;
    int pixelWidth, pixelHeight;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        newTexture = Instantiate(srcTexture);


        newTexture.Apply();
        

        worldWidth = spriteRenderer.bounds.size.x;
        worldHeight = spriteRenderer.bounds.size.y;
        pixelWidth = spriteRenderer.sprite.texture.width;
        pixelHeight = spriteRenderer.sprite.texture.height;

        gameObject.AddComponent<PolygonCollider2D>();
    }

   public void MakeDot(Vector3 pos)
    {
        Vector2Int pixelPosition = WorldToPixel(pos);
             

        newTexture.SetPixel(pixelPosition.x, pixelPosition.y, Color.clear);
        newTexture.SetPixel(pixelPosition.x+1, pixelPosition.y, Color.clear);
        newTexture.SetPixel(pixelPosition.x-1, pixelPosition.y, Color.clear);
        newTexture.SetPixel(pixelPosition.x, pixelPosition.y+1, Color.clear);
        newTexture.SetPixel(pixelPosition.x, pixelPosition.y-1, Color.clear);
        newTexture.Apply();
    }

    void MakeSprite()
    {
        spriteRenderer.sprite = Sprite.Create(newTexture, new Rect(0, 0, newTexture.width, newTexture.height), Vector2.one * 0.5f);
    }

    private Vector2Int WorldToPixel(Vector3 pos)
    {
        Vector2Int pixelPosition = Vector2Int.zero;

        var dx = pos.x - transform.position.x;
        var dy = pos.y - transform.position.y;

        pixelPosition.x = Mathf.RoundToInt(0.5f * pixelWidth + dx * (pixelWidth / worldWidth));
        pixelPosition.y = Mathf.RoundToInt(0.5f * pixelHeight + dy * (pixelHeight/ worldHeight));

        return pixelPosition;
    }
}
