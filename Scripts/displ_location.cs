using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class displ_location : MonoBehaviour
{
    private Image location;
    private Text locationText;

    public static string location_str;

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
        location_str = locationText.text;
        //updateLocation();
        yield return new WaitForSeconds(3);
        location.enabled =false;
        locationText.enabled =false;
    } 

    /*private void updateLocation()
    {
        location_str = "";
        
        if (gameObject.name == "Rizz city")
        {
            location_str = "Rizz city";
        }
        else if (gameObject.name == "Sky-bidi forest")
        {
            location_str = "Sky-bidi forest";
        }
    }*/
}
