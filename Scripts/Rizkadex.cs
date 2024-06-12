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
            
            if (Collector.have_bip){
                GameObject.Find("Bip").GetComponent<Image>().enabled =true;
                GameObject.Find("Bip_text").GetComponent<Text>().enabled =true;
            }
            if (Collector.have_richard){
                GameObject.Find("Richard").GetComponent<Image>().enabled =true;
                GameObject.Find("Richard_text").GetComponent<Text>().enabled =true;
            }
            if (Collector.have_punny){
                GameObject.Find("Punny").GetComponent<Image>().enabled =true;
                GameObject.Find("Punny_text").GetComponent<Text>().enabled =true;
            }
            if (Collector.have_joe){
                GameObject.Find("Joe").GetComponent<Image>().enabled =true;
                GameObject.Find("Joe_text").GetComponent<Text>().enabled =true;
            }
            if (Collector.have_alvin){
                GameObject.Find("AlvinJR").GetComponent<Image>().enabled =true;
                GameObject.Find("AlvinJR_text").GetComponent<Text>().enabled =true;
            }
            if (Collector.have_whale){
                GameObject.Find("Whale").GetComponent<Image>().enabled =true;
                GameObject.Find("Whale_text").GetComponent<Text>().enabled =true;
            }
            if (Collector.have_travis){
                GameObject.Find("Travis").GetComponent<Image>().enabled =true;
                GameObject.Find("Travis_text").GetComponent<Text>().enabled =true;
            }
            if (Collector.have_ligma){
                GameObject.Find("Ligma").GetComponent<Image>().enabled =true;
                GameObject.Find("Ligma_text").GetComponent<Text>().enabled =true;
            }
            if (Collector.have_quakor){
                GameObject.Find("Quakor").GetComponent<Image>().enabled =true;
                GameObject.Find("Quakor_text").GetComponent<Text>().enabled =true;
            }
            if (Collector.have_beeogee){
                GameObject.Find("Beeogee").GetComponent<Image>().enabled =true;
                GameObject.Find("Beeogee_text").GetComponent<Text>().enabled =true;
            }
            if (Collector.have_bellico){
                GameObject.Find("Bellico").GetComponent<Image>().enabled =true;
                GameObject.Find("Bellico_text").GetComponent<Text>().enabled =true;
            }
            if (Collector.have_terroc){
                GameObject.Find("Terroc").GetComponent<Image>().enabled =true;
                GameObject.Find("Terroc_text").GetComponent<Text>().enabled =true;
            }
            if (Collector.have_jo){
                GameObject.Find("Jo").GetComponent<Image>().enabled =true;
                GameObject.Find("Jo_text").GetComponent<Text>().enabled =true;
            }
        }
    }
}
