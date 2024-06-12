using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Map : MonoBehaviour
{

    private bool on_map = false;
    private Image[] images;
    private string CurrentLocation;

    // Start is called before the first frame update
    void Start()
    {
        images = GetComponentsInChildren<Image>();
        CurrentLocation = displ_location.location_str;
    }

    void Update()
    {
        StartCoroutine(FlickerLocation());
    }


    public void onMapClicked()
    {
        if (on_map)
        {
            setImage(false);
        }
        else
        {
            setImage(true);
        }

        on_map = !on_map;
    }

    private void setImage(bool boolVal)
    {
        foreach (Image image in images)
        {
            image.enabled = boolVal;
        }
    }

    IEnumerator FlickerLocation()
    {
        GameObject.Find(displ_location.location_str + "_m").GetComponent<Image>().color = Color.white;
        yield return new WaitForSeconds(1);
        GameObject.Find(displ_location.location_str + "_m").GetComponent<Image>().color = Color.red;
        yield return new WaitForSeconds(1);
    }
}
