using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Balls : MonoBehaviour
{
    public void BallsActivate()
    {
        BallsActivation(true);
    }

    public void BallsDeactivate()
    {
        BallsActivation(false);
    }

    private void BallsActivation(bool OnorOff)
    {
        // Find the parent GameObject named "Balls"
        GameObject parentObject = GameObject.Find("Balls");
        if (parentObject != null)
        {
            // Iterate through each child transform of the parent GameObject
            foreach (Transform child in parentObject.transform)
            {
                // Try to get the Image, Button and Text component from the child
                Image imageComponent = child.GetComponent<Image>();
                Button buttonComponent = child.GetComponent<Button>();
                Text textComponent = child.GetComponent<Text>();

                if (imageComponent != null)
                {
                    // Enable or disable the Image component
                    imageComponent.enabled = OnorOff;
                }
                if (buttonComponent != null)
                {
                    // Enable or disable the Button component
                    buttonComponent.enabled = OnorOff;
                }
                if (textComponent != null)
                {
                    // Enable or disable the Text component
                    textComponent.enabled = OnorOff;
                }
            }
        }
        else
        {
            Debug.LogWarning("GameObject with name 'Balls' not found.");
        }
    }
}
