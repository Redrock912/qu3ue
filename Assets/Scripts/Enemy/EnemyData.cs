using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Enemy")]
public class EnemyData : ScriptableObject
{
    public int index;
    public new string name;
    public float attack;
    public float hp;
    public Sprite enemySprite;
}
