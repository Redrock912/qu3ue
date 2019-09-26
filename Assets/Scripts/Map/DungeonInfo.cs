using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonInfo : MonoBehaviour
{

    public DungeonRoom[] dungeonRooms;
    public GameObject currentPlace;




    public CharacterCluster characterCluster;
    // Start is called before the first frame update


    public int currentPosition;

    public int gameoverPosition;


    void Start()
    {



        setUpRooms();
        setupCurrentPosition(0);
        Instantiate(characterCluster, transform.position, Quaternion.identity);
    }

    private void Update()
    {

    }

    void setUpRooms()
    {
        dungeonRooms = new DungeonRoom[5];

        int currentPosition = GameState.instance.runnerData.currentPosition;

        // 한바뀌를 돌아보자
        foreach (var room in dungeonRooms)
        {
            if (currentPosition % 5 == 0)
            {
                room.containerStats.isBoss = true;
            }
            else
            {
                int random3 = Random.Range(1, 3);
                switch (random3)
                {
                    case 1:
                        room.containerStats.isBattle = true;
                        
                        break;
                    case 2:
                        room.containerStats.isItem = true;
                        break;
                    case 3:
                        break;
                    default:
                        break;
                }
            }

            currentPosition++;
            
        }
    }

    public void setupCurrentPosition(int index)
    {
        //currentPlace.transform.position = dungeonRooms[index].transform.position;
    }

    public void CreateDungeon()
    {

    }
}
