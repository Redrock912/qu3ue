using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Restart()
    {
        RunnerData resetData = new RunnerData(1, 0, 0);
        JsonData.SaveRunnerDataToJson(resetData);

        SceneManager.LoadScene("SampleScene");
    }
}
