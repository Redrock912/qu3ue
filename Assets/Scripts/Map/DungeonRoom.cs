using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DungeonRoom : MonoBehaviour
{


    public SpriteRenderer iconContainer;
    public List<Sprite> iconList;
    public Transform flagPosition;

    // 0 = 없음, 1= battle, 2 = boss , 3 = buff

    public int roomType;
    public int position;
    public int enemyType;




    /// <summary>
    ///  0 = 없음, 1= battle, 2 = boss , 3 = buff
    /// </summary>
    public void SetType(int index)
    {
        roomType = index;
        iconContainer.sprite = iconList[roomType];
    }

    // Start is called before the first frame update
    void Start()
    {
            
    }



}
