using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimHandMove : MonoBehaviour
{
    // public Vector3 location;
    // public Transform otherLocation;
    public float moveSpeed;
    public float jumpForce;
    public float turnSpeed;
    public float sprint = 2.0f;
    private Rigidbody handRigidbody;
    
    
    void Start()
    {
        // transform.position = location; 
        handRigidbody = GetComponent<Rigidbody>();
        // Cursor.lockState = CursorLockMode.Locked;
    }
    
    // Update is called once per frame
    void Update()
    {
        #region Translational movement 
   
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);

        }

        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed * sprint);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * Time.deltaTime * moveSpeed);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * Time.deltaTime * moveSpeed);
        }

        // move up

        if (Input.GetKey(KeyCode.Space))
        {
           transform.Translate(Vector3.up * Time.deltaTime * moveSpeed); 
            
           // weinerRigidbody.AddForce(Vector3.up * jumpForce); 
        }

        if (Input.GetKey(KeyCode.X))
        {
            transform.Translate(Vector3.down * Time.deltaTime * moveSpeed);
        }


        #endregion

      
        #region Rotaional movement
        // Rotation 
        // rotate Left

        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(Vector3.down * Time.deltaTime * turnSpeed, Space.World);
        }

        // rotate right
        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed, Space.World); 
        }

        //forward 
        if (Input.GetKey(KeyCode.Z))
        {
            transform.Rotate(Vector3.right * Time.deltaTime * turnSpeed, Space.World);
        }

        // rotate back 
        if (Input.GetKey(KeyCode.C))
        {
            transform.Rotate(Vector3.left * Time.deltaTime * turnSpeed, Space.World);
        }
  
        #endregion
        
        

        /*
        #region Rotate using mouse

        transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * turnSpeed, Space.World);
        transform.Rotate(Vector3.left * Input.GetAxis("Mouse Y") * turnSpeed, Space.Self); 


        #endregion
        */
    }
}
