using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{

    private Button openShop;

    public static float peasantCost=150f;
    public static float goonCost=300f;
    public static float mafiaBossCost=600f;

    private void Start()
    {
        openShop = GameObject.Find("Interact").GetComponent<Button>();
        ShopDeactivate();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        openShop.enabled = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        openShop.enabled = false;
        ShopActivation(false, "Shop Menu");
    }

    public void ShopActivate()
    {
        ShopActivation(true, "Shop Menu");
    }

    public void ShopDeactivate()
    {
        ShopActivation(false, "Shop Menu");
    }

    public static void ShopActivation(bool OnorOff, string Menu)
    {
        // Find the parent GameObject named "Balls"
        GameObject parentObject = GameObject.Find(Menu);

        EnableOrDisableComponentsInChildren(parentObject.transform, OnorOff);
    }

    private static void EnableOrDisableComponentsInChildren(Transform parentTransform, bool OnorOff)
    {
        // Iterate through each child transform of the parent Transform
        foreach (Transform child in parentTransform)
        {
            // Log the name of the child
            Debug.Log("Processing child: " + child.name);

            // Try to get the Image, Button and Text component from the child
            Image imageComponent = child.GetComponent<Image>();
            Button buttonComponent = child.GetComponent<Button>();
            Text textComponent = child.GetComponent<Text>();

            if (imageComponent != null)
            {
                // Enable or disable the Image component
                imageComponent.enabled = OnorOff;
                Debug.Log("Image component " + (OnorOff ? "enabled" : "disabled") + " for child: " + child.name);
            }
            if (buttonComponent != null)
            {
                // Enable or disable the Button component
                buttonComponent.enabled = OnorOff;
                Debug.Log("Button component " + (OnorOff ? "enabled" : "disabled") + " for child: " + child.name);
            }
            if (textComponent != null)
            {
                // Enable or disable the Text component
                textComponent.enabled = OnorOff;
                Debug.Log("Text component " + (OnorOff ? "enabled" : "disabled") + " for child: " + child.name);
            }

            // Recursively call this function for each child
            if (child.childCount > 0)
            {
                EnableOrDisableComponentsInChildren(child, OnorOff);
            }
        }
    }

    public void BuyPeasant()
    {
        Balls.peasantCount = BuyBall(Balls.peasantCount, peasantCost);
        Debug.LogWarning(Balls.peasantCount);
    }

    public void BuyGoon()
    {
        Balls.goonCount = BuyBall(Balls.goonCount, goonCost);
    }

    public void BuyMafiaBoss()
    {
        Balls.mafiaBossCount = BuyBall(Balls.mafiaBossCount, mafiaBossCost);
    }

    private int BuyBall(int ballCount, float ballCost)
    {
        if (ballCost <= coinCount.coinAmount)
        {
            coinCount.coinAmount -= ballCost;
            return ++ballCount;
        }
        else
        {
            return ballCount;
        }
    }
}
