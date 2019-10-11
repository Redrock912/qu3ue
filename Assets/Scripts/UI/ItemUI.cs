using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour
{


    public Text potionAmount;
    public CharacterCluster characterCluster;

    public void Start()
    {
        GameState.instance.OnSave += UpdatePotions;
        UpdatePotions();
    }

    void UpdatePotions()
    {
        potionAmount.text = GameState.instance.potions.ToString();
    }

    public void Heal()
    {
        bool havePotion = GameState.instance.UsePotions();

        if (havePotion)
        {
            // Buff.cs   HealAll()
            foreach (var i in characterCluster.characterLists)
            {
                i.currentHealth = i.maxHealth;
                i.healthBar.fillAmount = i.currentHealth / i.maxHealth;
            }
        }
        else
        {
            // display text 여기부터
            FloatingText.TextPopup(transform.position, "No potions... ");
        }

        UpdatePotions();
    }

    private void OnDestroy()
    {
        GameState.instance.OnSave -= UpdatePotions;
    }
}
