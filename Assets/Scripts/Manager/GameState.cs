using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameState : MonoBehaviour
{
    // Start is called before the first frame update

    public static GameState instance;

    private int currentPosition;
    private int endPosition;
    public RunnerData runnerData;

    public Text currentPositionText;
    public Text gameoverPositionText;

    public void SavePosition()
    {
        JsonData.SaveRunnerDataToJson(runnerData);
    }
    
    public void NextPosition()
    {

        runnerData.currentPosition++;

        currentPositionText.text = runnerData.currentPosition.ToString();
    }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
