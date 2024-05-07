using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rizkadex : MonoBehaviour
{

    private bool on_dex = false;

    // Start is called before the first frame update
    public void rizkadex_displ()
    {
        if (!on_dex)
        {
            on_dex = true;
        } 
        else if (on_dex)
        {
            GameObject.Find("BGRND_riz").GetComponent<Image>().enabled =false;
            GameObject.Find("Bip").GetComponent<Image>().enabled =false;
            GameObject.Find("Blue").GetComponent<Image>().enabled =false;
            GameObject.Find("Red").GetComponent<Image>().enabled =false;
            GameObject.Find("Joe").GetComponent<Image>().enabled =false;
            on_dex = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (on_dex){
            GameObject.Find("BGRND_riz").GetComponent<Image>().enabled =true;
            if (Collector.have_bip){
                GameObject.Find("Bip").GetComponent<Image>().enabled =true;
            }
            if (Collector.have_blue){
                GameObject.Find("Blue").GetComponent<Image>().enabled =true;
            }
            if (Collector.have_red){
                GameObject.Find("Red").GetComponent<Image>().enabled =true;
            }
            if (Collector.have_joe){
                GameObject.Find("Joe").GetComponent<Image>().enabled =true;
            }
        }
    }
}
