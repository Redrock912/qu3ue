using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Characters : MonoBehaviour
{

    int position = 100;

    enum Direction { left, front, right};


    public bool isMoving = false;

    int hp =10;
    int attack = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }




    // Update is called once per frame
    void Update()
    {
        if(isMoving)
        {
            transform.Rotate(0, 0, 1);
        }
    }

    public void setPosition(int index)
    {
        position = index;
    }

    public void setCurrentState(bool moving)
    {
        isMoving = moving;
        transform.rotation = Quaternion.identity;
    }

    
}
