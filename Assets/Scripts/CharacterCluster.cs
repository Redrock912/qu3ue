using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCluster : MonoBehaviour
{

    public List<Characters> characterLists;

    public List<Vector2> memoryMap;

    public Battle battleSimulator;
    public Buff buffSimulator;

    public Characters selectedCharacter;


    DungeonInfo dungeonInfo;

    private bool isMoving = true;


    public int currentMapLocation=0;

    public bool IsMoving { get => isMoving; set => isMoving = value; }

    // Start is called before the first frame update
    void Start()
    {
        dungeonInfo = GameObject.FindGameObjectWithTag("Info").GetComponent<DungeonInfo>();
       
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Move()
    {
        if (IsMoving)
        {


            // 현재는 1자 진행이므로
            currentMapLocation++;


            DungeonRoom currentRoom = dungeonInfo.dungeonRooms[currentMapLocation];

            dungeonInfo.setupCurrentPosition(currentMapLocation);
            memoryMap.Add(currentRoom.dungeonCoordinate);

            if (currentRoom.containerStats.isBattle || currentRoom.containerStats.isBoss)
            {
                IsMoving = false;
                Battle battle = Instantiate(battleSimulator, transform.position, Quaternion.identity);
                battle.GetBasicData(currentRoom.enemyType);
            }

            if (currentRoom.containerStats.isItem)
            {
                isMoving = false;
                Instantiate(buffSimulator, transform.position, Quaternion.identity);
            }


            for (int i = 0; i < characterLists.Count; i++)
            {
                characterLists[i].setCurrentState(IsMoving);
            }
        }
    }


    

    public void ChangePosition(Characters targetCharacter)
    {
        int selectedCharacterIndex = characterLists.IndexOf(selectedCharacter);
        int targetCharacterIndex = characterLists.IndexOf(targetCharacter);

        Vector3 selectedCharacterPosition = selectedCharacter.transform.position;
        Vector3 targetCharacterPosition = targetCharacter.transform.position;

        // swap in list and position
        Characters temp = targetCharacter;
        characterLists[targetCharacterIndex] = selectedCharacter;
        characterLists[selectedCharacterIndex] = temp;
        selectedCharacter.transform.position = targetCharacterPosition;
        targetCharacter.transform.position = selectedCharacterPosition;
    }
}
