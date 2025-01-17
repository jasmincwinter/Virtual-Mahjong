﻿using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public enum Symbol
{ 
    CIRCLES = 0, 
    STICKS = 1,
    NUMBERS = 2,
    WIND = 3,
    DRAGON = 4, 
}

public class Tile : MonoBehaviour
{
    public Symbol symbol;
    public int iD;

    public Text tileText;

    private bool isInTileWall;
    public bool GetIsInTileWall()
    { return isInTileWall; }

    public void SetIsInTileWall(bool val)
    { isInTileWall = val; }

         

    void Start()
    {
        tileText.text = symbol.ToString() + " - " + iD;
    }


    void Update()
    {
        
    }
}
