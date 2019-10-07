using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Enemy : MonoBehaviour
{

    public Sprite enemyImage;

    public float maxHealth = 5;
    private float currentHealth;
    public float attack = 1;
    public bool isAlive = true;
    public int skillType;
    public int skillTimer;
    public List<EnemyData> enemyData;
    [Header("UI")]
    public Image healthBar;





    int dataLength;

    // Start is called before the first frame update
    public void Start()
    {
        

        
        SetupData();
    }



    public virtual void SetupData()
    {
        dataLength = enemyData.Count;

        int i = Random.Range(0, dataLength);

        enemyImage = enemyData[i].enemySprite;
        attack = enemyData[i].attack;
        maxHealth = enemyData[i].hp;
        currentHealth = maxHealth;
        healthBar.fillAmount = currentHealth / maxHealth;
        gameObject.GetComponent<SpriteRenderer>().sprite = enemyImage;
        skillType = enemyData[i].skillType;
        skillTimer = enemyData[i].skillTimer;
        

    }


    public void TakeDamage(float amount)
    {
       
        currentHealth -= amount;

        healthBar.fillAmount = currentHealth/maxHealth;

        if (currentHealth <= 0)
        {
            Die();
        }
        else
        {
            FloatingText.DamagePopup(transform.position, (int)amount, 1, false);
        }
    }

    public virtual void Attack(Characters character)
    {
        character.TakeDamage(attack);
    }

    public void Die()
    {
        FloatingText.GoldPopup(transform.position, GameState.instance.enemyGold);
        GameState.instance.SaveGold((int)(GameState.instance.enemyGold * GameState.instance.multiplier));
        setToIdlePosition();

    }

    public void setToIdlePosition()
    {
        isAlive = false;
        transform.position = new Vector3(10, 30, 0);
        
    }

    public void setToBattlePosition()
    {
        SetupData();
        isAlive = true;
        transform.position = new Vector3(10, 0, 0);
    }
}
