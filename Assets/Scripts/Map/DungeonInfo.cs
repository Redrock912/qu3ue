using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonInfo : MonoBehaviour
{

    public Vector2[] sampleDungeon;
    public DungeonRoom[] dungeonRooms;
    public GameObject currentPlace;


    public CharacterCluster characterCluster;
    // Start is called before the first frame update

          

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
        int length = sampleDungeon.Length -1;

        // 일단 닫히는 로직은 생각하지말고 다 구체적으로

        //for(int i = 0; i < sampleDungeon.Length; i++)
        //{

        //}   

        dungeonRooms[2].containerStats.isBattle = true;
        dungeonRooms[3].containerStats.isItem = true;
        dungeonRooms[length].containerStats.isBoss = true;
        
    }

    public void setupCurrentPosition(int index)
    {
        currentPlace.transform.position = dungeonRooms[index].transform.position;
    }
}
