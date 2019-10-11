using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JourneyPlanUI : MonoBehaviour
{

    public Button potionButton;
    public Text potionPriceText;


    int price =25;
    public int Price { get {
            return price;
        }
        set
        {
            price = value;
        }
    }
    int money = 0;


    private void Start()
    {
        potionPriceText.text = price.ToString();
    }

    public void BuyPotion()
    {

        GameState.instance.AddPotions(true, price);
        
    }

    public void ConfirmButton()
    {

        GameState.instance.SavePosition();
        DungeonInfo.Instance.StartJourney();
        Destroy(this.gameObject);
    }

}
