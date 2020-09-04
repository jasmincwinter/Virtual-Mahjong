using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
public enum GameState
{
    SHUFFLE = 0,
    WALL = 1,
    DRAW = 2,
    SANDBOX = 3, 

}
public class GameManager : MonoBehaviour
{
    [SerializeField]
    private const float aiPickUpTileDelay = 0.7f;

    public GameState gameState = GameState.SANDBOX;

    public static GameManager instance; 

    public Tile currentHeldTile;

    public List<TileWall> playerTileWalls = new List<TileWall>();

    public float aiPickUpDelay = 0.7f;

    public bool canPickUp = true;

    public Vector3 aiWall;

    public float speed = 3f;



    private void Awake()
    {
        instance = this; 
    }

    public bool CanPickUpTile(Tile tile)
    {
        //if (!canPickUp) return;

        if (gameState == GameState.WALL)
        {
            return !tile.GetIsInTileWall();
        }

        return true;
    }

    public void PickedUpTile(Tile newTile)
    {
        currentHeldTile = newTile;
        TileManager.instance.RemoveTileFromPool(newTile);
    }

    public void DroppedTile()
    {
        Debug.Log("Tile was dropped");
        if (gameState == GameState.WALL)
        {
            playerTileWalls[0].InsertTile(currentHeldTile);
            currentHeldTile.SetIsInTileWall(true);
            StartCoroutine(PickUpAITiles());

            //StartCoroutine(MoveSmoothly());
        }


        else
        {
            PlacedTileOnTable(currentHeldTile.gameObject);
        }
       
        currentHeldTile = null; 
    }

    public void PlacedTileOnTable(GameObject heldObject)
    {
        heldObject.transform.position = new Vector3(heldObject.transform.position.x, 6.8f, heldObject.transform.position.z);

        float dotResult = Vector3.Dot(Vector3.up, heldObject.transform.up);
        if (dotResult > 0.5f)
        {
            heldObject.transform.rotation = Quaternion.Euler(0, heldObject.transform.rotation.eulerAngles.y, 0);
        }
        else if (dotResult < -0.5f)
        {
            heldObject.transform.rotation = Quaternion.Euler(0, heldObject.transform.rotation.eulerAngles.y, 180);
        }
        else
        {
            heldObject.transform.rotation = Quaternion.Euler(-90, 0, 0);
        }
    }

    private IEnumerator PickUpAITiles()
    {
        canPickUp = false;

        int i = 1;

        while (i < 4)
        {
            Debug.Log("Moving AI Tile; " + i);
            Tile newAiTile = TileManager.instance.GetRandomPoolTile();
            playerTileWalls[i].InsertTile(newAiTile);


            TileManager.instance.RemoveTileFromPool(newAiTile);
            yield return new WaitForSeconds(aiPickUpTileDelay);
            i++;
        }

        canPickUp = true;
        //yield return null; 
    }

    public void ShuffleFinished()
    {
        gameState = GameState.WALL;

    }

    public bool CanShuffle()
    {
        return gameState == GameState.SHUFFLE; 
    }


    //private IEnumerator MoveSmoothly()
    //{
    //    while (transform.position != aiWall)
    //    {
    //        yield return new WaitForSeconds(0.5f);

    //        float smooth = speed * Time.deltaTime;

    //        transform.position = Vector3.MoveTowards(transform.position, aiWall, smooth);
            //    }

 
            // Start is called before the first frame update


            void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {

        }

    //}
}
