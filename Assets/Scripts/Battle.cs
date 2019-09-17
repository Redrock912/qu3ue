using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battle : MonoBehaviour
{

    public CharacterCluster characterCluster;
    public Enemy enemy;

    public Planning planningPrefab;

    private Characters battleCharacter;

    void Start()
    {
        characterCluster = GameObject.FindGameObjectWithTag("CharacterCluster").GetComponent<CharacterCluster>();
        battleCharacter = characterCluster.characterLists[0];

        enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Enemy>();

        enemy.setToBattlePosition();

        InvokeRepeating("Duel", 0.5f, 1.0f);
    }


    void Duel()
    {
        if (battleCharacter && enemy.isAlive)
        {
            battleCharacter.TakeDamage(enemy.attack);
            enemy.TakeDamage(battleCharacter.attack);
        }
        else if (!enemy.isAlive)
        {

            // Plannig phase
            Instantiate(planningPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);

        }
        else if (!battleCharacter)
        {
            if (characterCluster.characterLists.Count > 0)
            {
                battleCharacter = characterCluster.characterLists[0];
            }
            else
            {
                // Game Over
            }

        }

    }

}
