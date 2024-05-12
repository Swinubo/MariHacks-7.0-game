using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class displ_location : MonoBehaviour
{
    private Image location;
    private Text locationText;

    public static bool in_Skybidi;
    public static bool in_Rizz;

    private void Start()
    {
        location = GameObject.Find("Location").GetComponent<Image>(); 
        locationText = GameObject.Find("LocationText").GetComponent<Text>(); 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            StartCoroutine(DisplayLocation());
        }
    }

    IEnumerator DisplayLocation()
    {
        location.enabled =true;
        locationText.enabled =true;
        locationText.text = gameObject.name;
        updateLocation();
        yield return new WaitForSeconds(3);
        location.enabled =false;
        locationText.enabled =false;
    } 

    private void updateLocation()
    {
        in_Rizz=false;
        in_Skybidi=false;
        
        if (gameObject.name == "Rizz city")
        {
            in_Rizz = true;
        }
        else if (gameObject.name == "Sky-bidi forest")
        {
            in_Skybidi = true;
        }
    }
}
