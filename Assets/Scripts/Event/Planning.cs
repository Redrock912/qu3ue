using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Planning : MonoBehaviour
{

    public float maxTime = 10.0f;
    private float currentTime;


    CharacterCluster characterCluster;
    DungeonInfo dungeonInfo;

    public ResultUI resultUI;


    [Header("UI")]
    public Image timerBar;
    public Button confirmButton;
    public Button campButton;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = maxTime;

        characterCluster = GameObject.FindGameObjectWithTag("CharacterCluster").GetComponent<CharacterCluster>();
        dungeonInfo = GameObject.FindGameObjectWithTag("Info").GetComponent<DungeonInfo>();

        if (characterCluster.currentMapLocation == 4)
        {
            dungeonInfo.SetUpRooms();
        }
    }

    // Update is called once per frame
    void Update()
    {
        float deltaTime = Time.deltaTime;
        currentTime -= deltaTime;


        timerBar.fillAmount = currentTime / maxTime;
        if (currentTime <= 0)
        {
            Confirm();
        }
    }

    public void Confirm()
    {
        characterCluster.StartMoving();
        

        
        Destroy(this.gameObject);
    }

    public void Camp()
    {
        Instantiate(resultUI, transform.position, Quaternion.identity);

        CampUI.Instance.ActivePosition();

        Destroy(this.gameObject);
    }
}
