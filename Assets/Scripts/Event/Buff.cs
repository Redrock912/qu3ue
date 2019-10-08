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
        
        // 일단은 1개 맵만 생각, 나중에는 맵정보를 기반으로 데이터를 가져와야함
        buffList = JsonData.LoadBuffDataFromJson("buffData");

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
        Destroy(gameObject);
    }





    void GetRandomBuffList()
    {

    }

    void HealAll()
    {
        foreach (var i in characterCluster.characterLists)
        {
            i.currentHealth = i.maxHealth;
            i.healthBar.fillAmount = i.currentHealth / i.maxHealth;   
        }

        
    }

    void AttackUp()
    {


        characterCluster.characterLists[0].attack += 1;
        
    }

}
