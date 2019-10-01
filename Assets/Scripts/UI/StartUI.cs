using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartUI : MonoBehaviour
{

    public Button startButton;



    private void Start()
    {

        //JsonData.SaveRunnerDataToJson(GameState.instance.runnerData);
    }



    public void StartGame()
    {
        CampUI.Instance.ActivePosition();
        DungeonInfo.Instance.SetUpRooms();

        
        GameState.instance.ShowUI();
        Destroy(gameObject);
    }

}
