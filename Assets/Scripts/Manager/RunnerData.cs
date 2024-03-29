﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class RunnerData
{

    public int currentPosition;
    public int wDPosition;

    public int gold;

    public int bronze;

    public int[] mapInfo = new int[5];

    public RunnerData(int cp, int wdp, int gd)
    {
        currentPosition = cp;
        wDPosition = wdp;
        gold = gd;
        bronze = 0;

        mapInfo = new int[] { 0, 0, 0, 0, 0 };
    }
    
}
