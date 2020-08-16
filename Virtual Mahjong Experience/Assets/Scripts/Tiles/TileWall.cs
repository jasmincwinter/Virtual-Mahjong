using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileWall : MonoBehaviour
{
    public Transform wallStartReference;

    public List<Tile> wallTiles = new List<Tile>(); 

    public void InsertTile(Tile newTile)
    {
        if (wallTiles.Count >= 34) return;


        newTile.transform.position = wallStartReference.position + new Vector3(0.2f * (wallTiles.Count%17), .09f * Mathf.FloorToInt(wallTiles.Count / 17), 0); 
        newTile.transform.rotation = wallStartReference.rotation;

        wallTiles.Add(newTile);

        // next: when wall is complete, need to parent together so that player can push all forward 
        // Tile.transform.parent = newParent.transform;

    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
