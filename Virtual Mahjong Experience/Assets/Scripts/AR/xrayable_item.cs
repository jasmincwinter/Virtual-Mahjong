﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class xrayable_item : MonoBehaviour
{
    void Awake()
    {
        if(GetComponent<Renderer>())
        {
            GetComponent<Renderer>().material.renderQueue = 3002; 
        }
    }

}
