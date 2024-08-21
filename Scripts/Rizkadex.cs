using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rizkadex : MonoBehaviour
{

    private bool on_dex = false;
    private Image map;

    private void Start()
    {
        map = GameObject.Find("Map").GetComponent<Image>();
    }
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
            /*GameObject.Find("Map").GetComponent<Image>().enabled =false;
            GameObject.Find("Map").GetComponent<Button>().enabled =false;*/

            foreach (var rizkamon in Collector.rizkamons)
            {               
                GameObject.Find((rizkamon.name).Replace("_irnl", "")).GetComponent<Image>().enabled =false;
                GameObject.Find((rizkamon.name).Replace("_irnl", "_text")).GetComponent<Text>().enabled =false;
            }
            foreach (var badge in Collector.have_gymRizkamons)
            {               
                GameObject.Find(badge.Name + " Badge").GetComponent<Image>().enabled =false;
            }
            on_dex = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (on_dex){
            GameObject.Find("BGRND_riz").GetComponent<Image>().enabled =true;
            /*GameObject.Find("Badges").GetComponent<Image>().enabled =true;
            GameObject.Find("Map").GetComponent<Button>().enabled =true;*/
            foreach (Creature rizkamon in Collector.have_rizkamons)
            {
                Debug.Log("Current rixkamon instance" + rizkamon.Name);
                GameObject.Find(rizkamon.Name).GetComponent<Image>().enabled =true;
                GameObject.Find(rizkamon.Name+"_text").GetComponent<Text>().enabled =true;
            }
            foreach (var badge in Collector.have_gymRizkamons)
            {               
                GameObject.Find(badge.Name + " Badge").GetComponent<Image>().enabled =true;
            }

        }
    }
}
