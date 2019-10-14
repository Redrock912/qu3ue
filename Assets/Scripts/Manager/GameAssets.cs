using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAssets : MonoBehaviour
{

    public static GameAssets instance;

    public Transform floatingDamagePrefab;
    public Transform floatingGoldPrefab;
    public Transform journetPlanPrefab;
    public Transform GameOverPrefab;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }



}



