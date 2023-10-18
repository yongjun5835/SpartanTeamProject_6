using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class test : MonoBehaviour
{
    // Start is called before the first frame update
    Tilemap tilemap;
    public TileBase emptyTile;

    void Start()
    {
        tilemap = GetComponent<Tilemap>();
        for (int i = 0; i < 100; i++)
        {
            tilemap.SetTile(new Vector3Int(i, 4, 0), null);
            tilemap.SetTile(new Vector3Int(i, 3, 0), null);
            tilemap.SetTile(new Vector3Int(i, 2, 0), null);
            tilemap.SetTile(new Vector3Int(i, 1, 0), null);
            tilemap.SetTile(new Vector3Int(i, 0, 0), null);
            tilemap.SetTile(new Vector3Int(i, -1, 0), null);
            tilemap.SetTile(new Vector3Int(i, -2, 0), null);
            tilemap.SetTile(new Vector3Int(i, -3, 0), null);
            tilemap.SetTile(new Vector3Int(i, -4, 0), null);
            tilemap.SetTile(new Vector3Int(i, -5, 0), null);
            tilemap.SetTile(new Vector3Int(i, -6, 0), null);
            tilemap.SetTile(new Vector3Int(i, -7, 0), null);
            tilemap.SetTile(new Vector3Int(i, -8, 0), null);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
