using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRTeleportation : MonoBehaviour
{
    public Transform vrRig;

    private LineRenderer teleportLine;
    private bool shouldTeleport;
    private Vector3 hitPosition;

    private VRInput controller;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<VRInput>();
        teleportLine = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        {
            if (controller)
            {
                if (controller.isThumbstickPressed)
                {
                    RaycastHit hit;
                    if (Physics.Raycast(transform.position, controller.transform.forward, out hit))
                    {
                        // do the teleporting
                        hitPosition = hit.point;
                        teleportLine.SetPosition(0, controller.transform.position);
                        teleportLine.SetPosition(1, hitPosition);
                        teleportLine.enabled = true;
                        shouldTeleport = true;
                    }
                }
                else if (controller.isThumbstickPressed == false)
                {
                    if (shouldTeleport == true)
                    {
                        vrRig.transform.position = hitPosition;
                        shouldTeleport = false;
                        teleportLine.enabled = false;
                    }
                }
            }
        }
    }
}
