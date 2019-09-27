using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartUI : MonoBehaviour
{

    public Button startButton;

    public CampUI campUI;





    public void StartGame()
    {

        campUI.ActivePosition();
        GameState.instance.ShowUI();
        Destroy(gameObject);
    }

}
