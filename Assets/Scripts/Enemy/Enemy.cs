using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{

    public Sprite enemyImage;

    public float maxHealth = 5;
    private float currentHealth;
    public float attack = 1;
    public bool isAlive = true;
    [Header("UI")]
    public Image healthBar;


    public List<EnemyData> enemyData;

    int dataLength;

    // Start is called before the first frame update
    void Start()
    {


        dataLength = enemyData.Count;

        
        //JsonData.SaveEnemyDataToJson(enemyDataList);
        //enemyDataList = JsonData.LoadEnemyDataFromJson("enemyData");

        //enemyImage = enemyDataList.enemyList[0].enemySprite;


    }

    public void SetupData(int i)
    {
        enemyImage = enemyData[i].enemySprite;
        attack = enemyData[i].attack;
        maxHealth = enemyData[i].hp;
        currentHealth = maxHealth;
        gameObject.GetComponent<SpriteRenderer>().sprite = enemyImage;

    }


    public void TakeDamage(float amount)
    {
        currentHealth -= amount;

        healthBar.fillAmount = currentHealth/maxHealth;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Attack(Characters character)
    {
    }

    public void Die()
    {
        
        setToIdlePosition();

    }

    public void setToIdlePosition()
    {
        isAlive = false;
        transform.position = new Vector3(10, 30, 0);
    }

    public void setToBattlePosition()
    {
        SetupData(Random.Range(0, dataLength));
        isAlive = true;
        transform.position = new Vector3(10, 0, 0);
    }
}
