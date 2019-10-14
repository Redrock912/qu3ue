using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



// For Data saving
public class GameState : MonoBehaviour
{
    // Start is called before the first frame update

    public static GameState instance;

    private int currentPosition;
    private int endPosition;
    public RunnerData runnerData;

    public Text currentPositionText;
    public Text wDPositionText;
    public Canvas gameStateCanvas;

    public int enemyGold = 50;
    public int bossGold = 150;

    // 포션은 스테이트가 들고 있어야 하는가..?
    public int potions = 0;
    public int potionPrice = 50;
    

    public float multiplier = 1.0f;

    public CharacterCluster characterCluster;

    public delegate void PotionHandler();
    public event PotionHandler OnSave;
   
    public void SavePosition()
    {
        JsonData.SaveRunnerDataToJson(runnerData);


    }

    public void AddPotions(bool isBuying, int price = 0)
    {

        if (isBuying)
        {

            if (runnerData.gold > price)
            {
                runnerData.gold -= price;
                potions += 1;
            }
        }
        
        if(OnSave != null)
        {
            OnSave();
        }
    }



    public bool UsePotions()
    {

        bool havePotion;
        if(potions > 0)
        {
            potions--;
            havePotion = true;
        }
        else
        {
            havePotion = false;
        }

        return havePotion;
        
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

    public void UpdateWDPosition(int amount)
    {
        runnerData.wDPosition += amount;

        wDPositionText.text = runnerData.wDPosition.ToString();

        if(runnerData.wDPosition >= runnerData.currentPosition)
        {
            Instantiate(GameAssets.instance.GameOverPrefab, transform.position, Quaternion.identity);
            
        }
    }

    public void SaveGold(int amount) {
        runnerData.gold += amount;
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
        wDPositionText.text = runnerData.wDPosition.ToString();
    }


}
