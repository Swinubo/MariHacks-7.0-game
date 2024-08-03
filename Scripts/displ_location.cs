using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class displ_location : MonoBehaviour
{
    private Image location;
    private Text locationText;

    public static string location_str;
    public static string city_str;

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
        updateCity();
        yield return new WaitForSeconds(3);
        location.enabled =false;
        locationText.enabled =false;
    } 

    private void updateCity()
    {
        if (location_str == "Rizz city" || location_str == "Gyatt city")
        {
            city_str = location_str;
        }
    }
}
