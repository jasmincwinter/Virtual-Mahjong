using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SimHandGrab : MonoBehaviour
{
    public GameObject collidingObject;      // save what we're touching
    public GameObject heldObject;           // save what we're holding

    public bool gripHeld;
    public bool isHeld;

    public float throwForce;

    public bool manualPickup = false;


    [SerializeField]
    private Transform snapPosition;

    private void OnTriggerEnter(Collider other)
    {
        collidingObject = other.gameObject;
    }
    private void OnTriggerExit(Collider other)
    {
        // check that we exited the "colliding object" and not some other object 
        if (other.gameObject == collidingObject)
        {
            collidingObject = null;
        }
    }

    void Start()
    {

    }

    void Update()
    {
        // check for mouse input
        if ((Input.GetKeyDown(KeyCode.P)) && gripHeld == false)
        {
            gripHeld = true;
            manualPickup = false;
            if (collidingObject)
            {
                if (collidingObject.GetComponent<Rigidbody>())
                {
                    heldObject = collidingObject;
                    Grab();
                }
            }
        }
        if ((Input.GetKeyDown(KeyCode.R)) && gripHeld == true)
        {
            gripHeld = false;
         
            if (heldObject)
            {
                Release();
            }
        }
        if(heldObject)

        {

            // Debug.Log(Vector3.Dot(Vector3.up, heldObject.transform.up));
        }
    }
    private void Grab()
    {
        Tile tile = heldObject.GetComponent<Tile>();

        if (tile != null && GameManager.instance.CanPickUpTile(tile))
        {
            GameManager.instance.PickedUpTile(tile);
            heldObject.transform.SetParent(snapPosition);
            heldObject.transform.localPosition = Vector3.zero;
            heldObject.GetComponent<Rigidbody>().isKinematic = true;
        }

       
    }
    private void Release()
    {
        // get the rigidbody
        Rigidbody rb = heldObject.GetComponent<Rigidbody>();


        // reset heldObject        
        rb.isKinematic = true;
        heldObject.transform.SetParent(null);

        Tile tile = heldObject.GetComponent<Tile>();

        if (tile != null)
        {
            GameManager.instance.DroppedTile();
        }

        heldObject = null;
        


        
    }
}