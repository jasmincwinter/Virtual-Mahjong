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
        Debug.Log(gameObject.name);
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

    public void ResetPool()
    {
        for (int i = tilePool.Count - 1;  i >= 0; i--)
        {
            Destroy(tilePool[i].gameObject);
        }

        tilePool.Clear(); 
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
