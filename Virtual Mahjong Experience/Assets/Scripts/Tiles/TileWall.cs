using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TileWall : MonoBehaviour
{
    public Transform wallStartReference;

    public List<Tile> wallTiles = new List<Tile>();

    public float moveDuration = 1.5f; 

    public void InsertTile(Tile newTile)
    {
        if (wallTiles.Count >= 34) return;

        StartCoroutine(MoveSmoothly(newTile.transform));  


        wallTiles.Add(newTile);

        // next: when wall is complete, need to parent together so that player can push all forward 
        // Tile.transform.parent = newParent.transform;

    }

    IEnumerator MoveSmoothly(Transform tile)
    {
        float t = 0.0f;
        Vector3 startPos = tile.position;
        float horzoffset = 0.2f * (wallTiles.Count % 17);
        float vertoffset = .09f * Mathf.FloorToInt(wallTiles.Count / 17);
        Vector3 endPos = wallStartReference.position + (-wallStartReference.right * horzoffset) + (Vector3.up * vertoffset); 

        Quaternion startRot = tile.rotation;
        Quaternion endRot = wallStartReference.rotation; 


        while (t < 1)
        {
            tile.position = Vector3.Lerp(startPos, endPos, t);
            tile.rotation = Quaternion.Slerp(startRot, endRot, t);
            yield return null;
            t += Time.deltaTime/moveDuration;
        }

        tile.position = endPos; 

    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
