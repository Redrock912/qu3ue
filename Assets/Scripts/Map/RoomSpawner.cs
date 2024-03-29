﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner: MonoBehaviour
{
    //1 -> down
    //2 -> up
    //3 -> left
    //4 -> right
    public int openingDirection;


    private RoomTemplate templates;
    private int rand;
    private bool spawned = false;

    public float waitTime = 4f;

    private void Start()
    {
        Destroy(gameObject, waitTime);
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplate>();
        Invoke("Spawn" , 0.05f);
        
    }


    void Spawn()
    {



        if(spawned == false)
        {

            //if (openingDirection == 1)
            //{
            //    rand = Random.Range(0, templates.bottomRooms.Length);
            //    Instantiate(templates.bottomRooms[rand], transform.position, templates.bottomRooms[rand].transform.rotation);

            //}
            //else if (openingDirection == 2)
            //{
            //    rand = Random.Range(0, templates.topRooms.Length);
            //    Instantiate(templates.bottomRooms[rand], transform.position, templates.topRooms[rand].transform.rotation);

            //}
            //else if (openingDirection == 3)
            //{
            //    rand = Random.Range(0, templates.leftRooms.Length);
            //    Instantiate(templates.leftRooms[rand], transform.position, templates.leftRooms[rand].transform.rotation);

            //}
            //else if (openingDirection == 4)
            //{
            //    rand = Random.Range(0, templates.rightRooms.Length);
            //    Instantiate(templates.rightRooms[rand], transform.position, templates.rightRooms[rand].transform.rotation);
            //}

            switch (openingDirection)
            {
                // down
                case 1:

                    // for the test only right and left
                    rand = Random.Range(0, templates.bottomRooms.Length);
                    Instantiate(templates.bottomRooms[rand], transform.position, templates.bottomRooms[rand].transform.rotation);
                    break;

                // up
                case 2:
                    rand = Random.Range(0, templates.topRooms.Length);
                    Instantiate(templates.topRooms[rand], transform.position, templates.topRooms[rand].transform.rotation);
                    break;
                //left
                case 3:
                    rand = Random.Range(0, templates.leftRooms.Length);
                    Instantiate(templates.leftRooms[rand], transform.position, templates.leftRooms[rand].transform.rotation);
                    break;
                //right
                case 4:
                    rand = Random.Range(0, templates.rightRooms.Length);
                    Instantiate(templates.rightRooms[rand], transform.position, templates.rightRooms[rand].transform.rotation);
                    break;
                default:
                    break;
            }


        }
        spawned = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
       
        if(collision.CompareTag("SpawnPoint"))
        {
            // spawn walls to block loose openings!
            if(collision && collision.GetComponent<RoomSpawner>().spawned == false && spawned == false)
            {
              
                //Instantiate(templates.closedRoom, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }

            spawned = true;
        }
    }

}
