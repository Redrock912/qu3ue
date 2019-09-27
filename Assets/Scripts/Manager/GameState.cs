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
    public Canvas gameStateCanvas;

    public void SavePosition()
    {
        JsonData.SaveRunnerDataToJson(runnerData);
    }

    // 시작화면에선 보여주지 말자
    public void ShowUI()
    {
        gameStateCanvas.gameObject.SetActive(true);
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
        // 나중에 서버에서 가져와야 함
        runnerData = JsonData.LoadRunnerDataFromJson();

        currentPositionText.text = runnerData.currentPosition.ToString();
        gameoverPositionText.text = runnerData.gameoverPosition.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
