using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Balls : MonoBehaviour
{

    private Animator anim;
    private GameObject peasantBall;
    private GameObject goonBall;
    private GameObject mafiaBossBall;
    private Transform shootingPoint;
    [SerializeField] private float angle = 20;

    public static int peasantCount;
    public static int goonCount;
    public static int mafiaBossCount;
    private int randomNum;
    private int peasantPercent = 50;
    private int goonPercent = 75;
    private int mafiaBossPercent = 100;

    private void Start()
    {
        anim = GameObject.Find("Arm").GetComponent<Animator>();

        peasantBall = GameObject.Find("peasantBall");
        goonBall = GameObject.Find("goonBall");
        mafiaBossBall =  GameObject.Find("mafiaBossBall");

        shootingPoint = GameObject.Find("shooting point").GetComponent<Transform>();
    }

    private void Update()
    {
        GameObject.Find("Peasant amount").GetComponent<Text>().text = "x" + peasantCount.ToString();
        GameObject.Find("Goon amount").GetComponent<Text>().text = "x" + goonCount.ToString();
        GameObject.Find("Mafia Boss amount").GetComponent<Text>().text = "x" + mafiaBossCount.ToString();
    }

    public void BallsActivate()
    {
        BallsActivation(true);
    }

    public void BallsDeactivate()
    {
        BallsActivation(false);
    }

    public void BallsActivation(bool OnorOff)
    {
        // Find the parent GameObject named "Balls"
        GameObject parentObject = GameObject.Find("Balls");
        if (parentObject != null)
        {
            Debug.Log("Parent GameObject 'Balls' found.");
            
            // Call the recursive function to enable/disable components in all descendants
            EnableOrDisableComponentsInChildren(parentObject.transform, OnorOff);
        }
        else
        {
            Debug.LogWarning("GameObject with name 'Balls' not found.");
        }
    }

    private void EnableOrDisableComponentsInChildren(Transform parentTransform, bool OnorOff)
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

        GameObject.Find("BallsText").GetComponent<Text>().enabled = true;
    }

    public void ThrowPeasant()
    {
        peasantCount = ThrowBall(peasantBall, peasantCount, peasantPercent);
    }
    public void ThrowGoon()
    {
        goonCount = ThrowBall(goonBall, goonCount, goonPercent);
    }
    public void ThrowMafiaBoss()
    {
        mafiaBossCount = ThrowBall(mafiaBossBall, mafiaBossCount, mafiaBossPercent);
    }

    private int ThrowBall(GameObject Ball, int count, int percent)
    {
        randomNum = Random.Range(0, 101);

        if (count != 0)
        {
            if (randomNum < percent)
            {
                Quaternion bulletRotation = Quaternion.Euler(0, 0, angle) * transform.rotation;
                Instantiate(Ball, shootingPoint.position, bulletRotation);
                anim.Play("Throw");
                BallsDeactivate();
            }
            return --count;
        }
        else
        {
            Debug.LogError(Ball.name + " unavailable");
            return count;
        }
    }

}
