using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRLocomotion : MonoBehaviour
{
    public Transform vrRig;

    public Transform dictator;

    private VRInput controller;
    private Vector3 playerForward;
    private Vector3 playerRight; 

    void Start()
    {
        controller = GetComponent<VRInput>(); 
    }

    void Update()
    {
        playerForward = dictator.forward;
        playerForward.y = 0f;
        playerForward.Normalize();

        playerRight = dictator.right;
        playerRight.y = 0f;
        playerForward.Normalize();

        vrRig.Translate(playerForward * controller.thumbstick.y * Time.deltaTime);
        vrRig.Translate(playerRight * controller.thumbstick.x * Time.deltaTime); 
    }
}
