using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileWasher : MonoBehaviour
{
    private Vector3 target = new Vector3(0.0f, 6.7f, 0.0f);


    void Update()
    {
        transform.RotateAround(target, Vector3.up, 70 * Time.deltaTime);
    }
}

