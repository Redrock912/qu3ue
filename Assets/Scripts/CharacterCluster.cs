using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCluster : MonoBehaviour
{

    public Characters[] characterLists;

    public List<Vector2> memoryMap;

    DungeonInfo dungeonInfo;

    private bool isMoving = true;


    public int currentMapLocation=0;

    // Start is called before the first frame update
    void Start()
    {
        dungeonInfo = GameObject.FindGameObjectWithTag("Info").GetComponent<DungeonInfo>();
        memoryMap.Add(dungeonInfo.dungeonRooms[currentMapLocation].dungeonCoordinate);
        InvokeRepeating("Move", 0.5f, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Move()
    {
        if (isMoving)
        {


            // 현재는 1자 진행이므로
            currentMapLocation++;


            DungeonRoom currentRoom = dungeonInfo.dungeonRooms[currentMapLocation];

            dungeonInfo.setupCurrentPosition(currentMapLocation);
            memoryMap.Add(currentRoom.dungeonCoordinate);

            if (currentRoom.containerStats.isBattle || currentRoom.containerStats.isBoss)
            {
                isMoving = false;
                
            }


            for (int i = 0; i < characterLists.Length; i++)
            {
                characterLists[i].setCurrentState(isMoving);
            }
        }
    }

    void Battle()
    {

    }


    void Item()
    {

    }
    
}
