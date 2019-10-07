using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCluster : MonoBehaviour
{

    public List<Characters> characterLists;

  

    public Battle battleSimulator;
    public Buff buffSimulator;

    public Characters selectedCharacter;


    DungeonInfo dungeonInfo;

    private bool isMoving = true;


    // 캐릭터는 0~4번 방을 계속해서 돌뿐, 알 필요 없다.
    public int currentMapLocation=0;

    public bool IsMoving { get => isMoving; set => isMoving = value; }

    // Start is called before the first frame update
    void Start()
    {
        dungeonInfo = GameObject.FindGameObjectWithTag("Info").GetComponent<DungeonInfo>();
        
        Invoke("Move", 1.0f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartMoving()
    {
        isMoving = true;
        currentMapLocation++;
        for (int i = 0; i < characterLists.Count; i++)
        {
            characterLists[i].setCurrentState(IsMoving);
        }

        Invoke("Move", 1.0f);
    }

    void Move()
    {
        currentMapLocation = currentMapLocation % 5;


        if (IsMoving)
        {


            // 현재는 1자 진행이므로
            


            DungeonRoom currentRoom = dungeonInfo.dungeonRooms[currentMapLocation];
            GameState.instance.NextPosition();
            dungeonInfo.MarkPosition(currentMapLocation);
            //dungeonInfo.setupCurrentPosition(currentMapLocation);
         
            if (currentRoom.roomType == 1 || currentRoom.roomType ==2)
            {
                IsMoving = false;
                Battle battle = Instantiate(battleSimulator, transform.position, Quaternion.identity);
                battle.GetBasicData(currentRoom.roomType);
            }

            if (currentRoom.roomType == 3)
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
