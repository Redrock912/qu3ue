using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Characters : MonoBehaviour
{

    int position = 100;

    enum Direction { left, front, right };


    public bool isMoving = false;

    public float maxHealth = 10;
    public float currentHealth;
    public float attack = 1;



    [Header("UI")]
    public Image healthBar;
    public SpriteRenderer selectedSprite;

    CharacterCluster characterCluster;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        characterCluster = GameObject.FindGameObjectWithTag("CharacterCluster").GetComponent<CharacterCluster>();
    }




    // Update is called once per frame
    void Update()
    {
        if (isMoving)
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


    public void Attack(Enemy enemy)
    {
        enemy.TakeDamage(attack);
    }


    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        FloatingText.DamagePopup(transform.position,  (int)amount, 0, false);

        healthBar.fillAmount = currentHealth / maxHealth;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        characterCluster.characterLists.Remove(this);
        Destroy(gameObject);
       
    }


    private void OnMouseDown()
    {

        if (!characterCluster.selectedCharacter)
        {
            selectedSprite.color = new Vector4(255, 255, 255, 255);
            characterCluster.selectedCharacter = this;
        }
        else if (characterCluster.selectedCharacter != this)
        {
            characterCluster.ChangePosition(this);
        }
        else if (characterCluster.selectedCharacter == this)
        {
            selectedSprite.color = new Vector4(255, 255, 255, 0);
            characterCluster.selectedCharacter = null;
        }
    }

    
}
