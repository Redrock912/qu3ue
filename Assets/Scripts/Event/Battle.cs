using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battle : MonoBehaviour
{

    public CharacterCluster characterCluster;
    public Enemy enemy;
    public Boss boss;

    // global for dueling
    Enemy currentEnemy;
    public Planning planningPrefab;

    private Characters battleCharacter;


    private void InitializeData()
    {
        if (characterCluster == null)
        {
            characterCluster = GameObject.FindGameObjectWithTag("CharacterCluster").GetComponent<CharacterCluster>();
        }

        if (enemy == null)
        {
            enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Enemy>();
        }

        if (boss == null)
        {
            boss = GameObject.FindGameObjectWithTag("Boss").GetComponent<Boss>();
        }

    }

    public void GetBasicData(int roomType)
    {

        InitializeData();
        battleCharacter = characterCluster.characterLists[0];

        if (roomType == 1)
        {
            currentEnemy = enemy;
            enemy.setToBattlePosition();
        }
        else if(roomType == 2)
        {
            currentEnemy = boss;
            boss.setToBattlePosition();
        }



        InvokeRepeating("Duel", 1.0f, 0.5f);
    }
    


    void Duel()
    {
        
        if (battleCharacter.currentHealth>0 && currentEnemy.isAlive)
        {
            battleCharacter.Attack(currentEnemy);
            currentEnemy.Attack(battleCharacter);
            

            //battleCharacter.TakeDamage(currentEnemy.attack);
            //currentEnemy.TakeDamage(battleCharacter.attack);
        }
        else if (!currentEnemy.isAlive)
        {

            // Plannig phase
            Instantiate(planningPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);

        }
        else 
        {
            if (characterCluster.characterLists.Count > 0)
            {
                battleCharacter = characterCluster.characterLists[0];

                battleCharacter.Attack(currentEnemy);
                currentEnemy.Attack(battleCharacter);

                //battleCharacter.TakeDamage(currentEnemy.attack);
                //currentEnemy.TakeDamage(battleCharacter.attack);
            }
            else
            {
                // Game Over
            }

        }

    }

}
