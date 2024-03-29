﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CampUI : MonoBehaviour
{
    private static CampUI _instance;

    public static CampUI Instance { get { return _instance; } }

    public Vector2 hidePosition;
    public Vector2 activePosition;

    public DungeonInfo dungeonInfo;

    public Button journeyButton;

    public Camera uiCamera;

    

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }


    public void SetPosition(Transform uiObject, float x, float y)
    {
        Vector2 outPosition;
        RectTransform rect = uiObject.GetComponent<RectTransform>();

        // 스크린 좌표계 (해상도에 따라 다 다르게 계산되야함)
        RectTransformUtility.ScreenPointToLocalPointInRectangle(rect, new Vector2((int)(Screen.width * x), (int)(Screen.height * y)), uiCamera, out outPosition);

        // 기존 위치
        Vector3 tempLocal = uiObject.transform.localPosition;

        // 새로운 위치
        uiObject.transform.localPosition = tempLocal + new Vector3(outPosition.x, outPosition.y, 0);
    }

    public void ActivePosition()
    {

        SetPosition(journeyButton.transform, 0.9f, 0.2f);

        
        
    }

    public void HidePosition()
    {
        SetPosition(journeyButton.transform, 2.0f, 2.0f);
    }



    public void JourneyStart()
    {
        HidePosition();
        //DungeonInfo.Instance.StartJourney();
        Instantiate(GameAssets.instance.journetPlanPrefab, transform.position, Quaternion.identity);
    }
}
