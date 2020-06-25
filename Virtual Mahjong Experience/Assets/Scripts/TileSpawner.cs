using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq.Expressions;
using UnityEngine;

public class TileSpawner : MonoBehaviour

{
    public List<int> mappingIDs = new List<int>();
    public GameObject tilePrefab;
    public Rigidbody rb; 

    float xRange = 3f;
    float zRange = 3f;
    float yPos = 6.7f;


    void Start()
    {
        for (int i = 0; i < 136; i++)
        {
            mappingIDs.Add(i);
        }

        float zPos = 0f;

        for (int i = 0; i < 136; i++)
        {
            GameObject newTile = Instantiate(tilePrefab, GenerateSpawnPosition(), Quaternion.identity);
            newTile.GetComponent<Tile>().symbol = GetSymbol(mappingIDs[i]);
            zPos += 1.1f;
        }

        // need to check position (or collider?) of previous tile so they don't spawn on top of each other 

        //rb = GetComponent<Rigidbody>();
        
        //rb.isKinematic = true;

    }
    
    Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = UnityEngine.Random.Range(-xRange, xRange);
        float spawnPosZ = UnityEngine.Random.Range(-zRange, zRange);
        float spawnPosY = yPos;

        Vector3 randomPos = new Vector3(spawnPosX, spawnPosY, spawnPosZ);
        return randomPos;

    }

    public Symbol GetSymbol(int iD)
    {
        if (iD < 36)
            {
            return Symbol.CIRCLES;
            }

        else if (iD > 36 && iD < 72)
            {
            return Symbol.STICKS;
            }

        else if (iD > 72 && iD < 108)
            {
            return Symbol.NUMBERS;
            }

        else if (iD > 108 && iD < 124)
            {
            return Symbol.WIND;
            }

        else if (iD > 124 && iD < 136)
            {
            return Symbol.DRAGON;
            }

        return 0; // how to finish this off properly? 
    }

    void Update()
    {
        
    }

    // 0 - length of array (random) to remove mappingiDs; 
}
