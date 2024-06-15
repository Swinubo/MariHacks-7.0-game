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
            GameObject.Find("Map").GetComponent<Image>().enabled =false;
            GameObject.Find("Map").GetComponent<Button>().enabled =false;

            foreach (var rizkamon in Collector.rizkamons)
            {               
                GameObject.Find((rizkamon.name).Replace("_irnl", "")).GetComponent<Image>().enabled =false;
                GameObject.Find((rizkamon.name).Replace("_irnl", "_text")).GetComponent<Text>().enabled =false;
            }
            on_dex = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (on_dex){
            GameObject.Find("BGRND_riz").GetComponent<Image>().enabled =true;
            GameObject.Find("Map").GetComponent<Image>().enabled =true;
            GameObject.Find("Map").GetComponent<Button>().enabled =true;
            Debug.Log(Collector.have_rizkamons);
            foreach (var rizkamon in Collector.have_rizkamons)
            {
                Debug.Log(rizkamon);
                GameObject.Find(rizkamon).GetComponent<Image>().enabled =true;
                GameObject.Find(rizkamon+"_text").GetComponent<Text>().enabled =true;
            }

        }
    }
}
