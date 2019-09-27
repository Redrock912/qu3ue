using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonInfo : MonoBehaviour
{

    public DungeonRoom[] dungeonRooms;
    public GameObject currentPlace;
    public Transform flagSprite;



    public CharacterCluster characterCluster;
    // Start is called before the first frame update


    public int currentPosition;
    public int gameoverPosition;




    public void StartJourney()
    {
        SetUpRooms();
        
        Instantiate(characterCluster, transform.position, Quaternion.identity);
    }


    public void SetUpRooms()
    {
        

        int currentPosition = GameState.instance.runnerData.currentPosition;

        print(currentPosition);

        // 한바뀌를 돌아보자
        foreach (var room in dungeonRooms)
        {
            if (currentPosition % 5 == 4)
            {
              
                room.SetType(2);
            }
            else
            {
                int random3 = Random.Range(1, 3);
                switch (random3)
                {
                    case 1:
                        room.SetType(1);
                        
                        break;
                    case 2:
                        room.SetType(3);
              
                        break;
                    default:
                        break;
                }
            }
            room.position = currentPosition;
            currentPosition++;
            
        }
    }

    public void MarkPosition(int index)
    {
        flagSprite.position= dungeonRooms[index].flagPosition.position;
    }

    public void CreateDungeon()
    {

    }
}
