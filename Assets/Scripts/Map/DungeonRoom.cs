using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonRoom : MonoBehaviour
{


    public DirectionStats directionStats;
    public ContainerStats containerStats;
    public Vector2 dungeonCoordinate;


    [System.Serializable]
    public class DirectionStats
    {
        public bool isUpOpen = false;
        public bool isLeftOpen = false;
        public bool isRightOpen = false;
        public bool isDownOpen = false;
    }

    [System.Serializable]
    public class ContainerStats
    {
        public bool isItem = false;
        public bool isBattle = false;
        public bool isBoss = false;
    }



    // Start is called before the first frame update
    void Start()
    {
            
    }



}
