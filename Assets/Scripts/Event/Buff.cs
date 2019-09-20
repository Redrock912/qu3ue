using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buff : MonoBehaviour
{

    private CharacterCluster characterCluster;

    public BuffDataList buffList;

    public Planning planningPrefab;

    public bool visited = false;

    int randomIndex = 0;

    // Start is called before the first frame update
    void Start()
    {

        buffList = JsonData.LoadBuffDataFromJson();

        randomIndex = Random.Range(0, buffList.buffList.Count);

        
        GetBuff(randomIndex);

        Instantiate(planningPrefab, transform.position, Quaternion.identity);
    }



    void GetBuff(int index)
    {

        if (!characterCluster)
        {
            characterCluster = GameObject.FindGameObjectWithTag("CharacterCluster").GetComponent<CharacterCluster>();
        }


        switch (index)
        {
            // heal
            case 0:
                HealAll();
                Debug.Log(buffList.buffList[index].description);
                break;

            case 1:
                AttackUp();
                Debug.Log(buffList.buffList[index].description);
                break;
            default:
                Debug.Log("Out of index");
                break;
        }
    }





    void GetRandomBuffList()
    {

    }

    void HealAll()
    {
        foreach (var i in characterCluster.characterLists)
        {
            i.currentHealth = i.maxHealth;
            i.TakeDamage(0);
        }
    }

    void AttackUp()
    {
        foreach (var i in characterCluster.characterLists)
        {
            i.currentHealth = i.maxHealth;
            i.TakeDamage(0);
        }
    }

}
