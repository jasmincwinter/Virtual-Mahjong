using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq.Expressions;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.UI;

public class TileSpawner : MonoBehaviour

// to do: grabbing tiles and creating the wall in front of us. grabbing tiles from the wall for our hand. rolling dice. how to create dependencies?



{
    public List<int> mappingIDs = new List<int>();
    public GameObject tilePrefab;
    public Transform gridStartRef;
    public int gridSize = 15;
    public float cellSize = 0.4f;

    public List<List<bool>> tileGrid = new List<List<bool>>();


    float xRange = 3f;
    float zRange = 3f;
    float yPos = 6.7f;

    private Vector3 target = new Vector3(0.0f, 6.7f, 0.0f);

    public int shuffleCount = 10;
    public float shuffleDelay = 0.1f;

    private Vector3 centre = new Vector3(0.0f, 6.7f, 0.0f);

    // public Button shuffleButton;


    void Start()
    {
        SpawnTiles();




    }

    public void SpawnTiles()
    {
        mappingIDs.Clear();
        tileGrid.Clear();

        for (int i = transform.childCount - 1; i >= 0; i--)
        {
            Destroy(transform.GetChild(i).gameObject);
        }

        for (int i = 0; i < 136; i++)
        {
            mappingIDs.Add(i);
        }

        for (int i = 0; i < gridSize; i++)
        {
            List<bool> row = new List<bool>();
            for (int j = 0; j < gridSize; j++)
            {
                row.Add(false);
                //       
            }
            tileGrid.Add(row);
        }

        for (int i = 0; i < 136; i++)
        {
            int row = UnityEngine.Random.Range(0, gridSize);
            int col = UnityEngine.Random.Range(0, gridSize);
            while (tileGrid[row][col] == true)
            {
                row = UnityEngine.Random.Range(0, gridSize);
                col = UnityEngine.Random.Range(0, gridSize);
            }
            tileGrid[row][col] = true;
            Vector3 spawnPos = new Vector3(
                    gridStartRef.position.x + (cellSize * row),
                    gridStartRef.position.y,
                    gridStartRef.position.z + (cellSize * col)
                    );
            GameObject newTile = Instantiate(tilePrefab, spawnPos, Quaternion.Euler(0, UnityEngine.Random.Range(0, 180), 0), transform);
            newTile.GetComponent<Tile>().symbol = GetSymbol(mappingIDs[i]);

            TileManager.instance.AddTileToPool(newTile.GetComponent<Tile>());

            transform.RotateAround(centre, Vector3.up, 70 * Time.deltaTime);
        }
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

        else
        {
            return Symbol.DRAGON;
        }
    }

    void Update()
    {
        //Button button = shuffleButton.GetComponent<Button>();

        //button.onClick.AddListener(ShuffleOnClick);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Hand")
        {
            StartCoroutine(ShuffleTiles());
        }
    }


    private IEnumerator ShuffleTiles()
    {
        int currentShuffleCount = 0;

        while (currentShuffleCount < shuffleCount)
        {
            SpawnTiles();
            yield return new WaitForSeconds(shuffleDelay);
            currentShuffleCount++;
        }

    }

}

