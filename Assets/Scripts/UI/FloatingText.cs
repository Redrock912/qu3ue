using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class FloatingText : MonoBehaviour
{
    private static int sortingOrder;
    private const float DISAPPEAR_TIMER_MAX = 1f;
    private float moveYSpeed = 10f;

    private float disappearTimer;
    private TextMeshPro textMesh;
    private Color textColor;

    public static FloatingText DamagePopup(Vector3 position, int damageAmount, int type, bool isCritical)
    {

        Transform FloatingTextTransform = Instantiate(GameAssets.instance.floatingDamagePrefab, position + new Vector3(0, 2), Quaternion.identity);
        FloatingText damagePopup = FloatingTextTransform.GetComponent<FloatingText>();
        damagePopup.Setup(damageAmount, type, isCritical);

        return damagePopup;
    }

    public static FloatingText TextPopup(Vector3 position, string text)
    {
        Transform FloatingTextTransform = Instantiate(GameAssets.instance.floatingDamagePrefab, position + new Vector3(0, 2), Quaternion.identity);
        FloatingText textPopup = FloatingTextTransform.GetComponent<FloatingText>();
        textPopup.SetupText(text);
        return textPopup;
    }


    public static FloatingText GoldPopup(Vector3 position, int goldAmount)
    {

        Transform FloatingTextTransform = Instantiate(GameAssets.instance.floatingGoldPrefab, position + new Vector3(0, 2), Quaternion.identity);
        FloatingText goldPopup = FloatingTextTransform.GetComponent<FloatingText>();
        goldPopup.SetupGold(goldAmount);

        return goldPopup;
    }


    private void Awake()
    {

        textMesh = transform.GetComponent<TextMeshPro>();
    }

    public void SetupText(string text)
    {
        textMesh.SetText(text);


    }

    public void Setup(int damageAmount, int type, bool isCritical)
    {
        textMesh.SetText(damageAmount.ToString());


        // enemy hitting ally
        if (type == 0)
        {
            textMesh.color = Color.red;
        }

        if (isCritical)
        {
            textMesh.color = Color.yellow;
            textMesh.fontSize = 36;
        }


        //sortingOrder++;
        //textMesh.sortingOrder = sortingOrder;
        disappearTimer = DISAPPEAR_TIMER_MAX;
        textColor = textMesh.color;
    }


    public void SetupGold(int goldAmount)
    {
        textMesh.SetText(goldAmount.ToString());

        disappearTimer = DISAPPEAR_TIMER_MAX;
        textColor = textMesh.color;
    }

    private void Update()
    {

        transform.position += new Vector3(0, moveYSpeed) * Time.deltaTime;

        if (disappearTimer > DISAPPEAR_TIMER_MAX * .5f)
        {
            
            // first half of the lifetime
            //float increaseScaleAmount = 1f;
            //transform.localScale += Vector3.one * increaseScaleAmount * Time.deltaTime;
        }
        else
        {
            if (moveYSpeed > 7f)
                moveYSpeed -= 0.2f;
            //float decreaseScaleAmount = 1f;
            //transform.localScale -= Vector3.one * decreaseScaleAmount * Time.deltaTime;
        }

        disappearTimer -= Time.deltaTime;

        if (disappearTimer < 0)
        {
            float disappearSpeed = 3f;
            textColor.a -= disappearSpeed * Time.deltaTime;
            textMesh.color = textColor;

        }

        if (textColor.a < 0)
        {
            Destroy(gameObject);
        }
    }
}
