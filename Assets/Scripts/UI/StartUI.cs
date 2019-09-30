using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartUI : MonoBehaviour
{

    public Button startButton;

    





    public void StartGame()
    {
        CampUI.Instance.ActivePosition();
        
        GameState.instance.ShowUI();
        Destroy(gameObject);
    }

}
