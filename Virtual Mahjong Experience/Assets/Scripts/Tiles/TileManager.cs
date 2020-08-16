using System.Collections;
using System.Collections.Generic;
using System.Net;
//using System.Numerics;
using UnityEditor;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public static TileManager instance;

    public List<Tile> tilePool = new List<Tile>();


    //public float moveDuration = 3f;

    public void Awake()
    {
        instance = this;
    }

    public void AddTileToPool(Tile newTile)
    {
        tilePool.Add(newTile);

    }

    public void RemoveTileFromPool(Tile oldTile)
    {
        if (tilePool.Contains(oldTile))
        {
            tilePool.Remove(oldTile);
        }
    }

    public Tile GetRandomPoolTile()
    {
        return tilePool[Random.Range(0, tilePool.Count)];
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
