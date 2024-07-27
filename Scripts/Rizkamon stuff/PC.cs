using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PC : MonoBehaviour
{   
    private Button openShop;
    private void Start()
    {
        openShop = GameObject.Find("Interact").GetComponent<Button>();
        PcDeactivate();
    }

    private void Update()
    {
        GameObject.Find("currentRizkamonName").GetComponent<Text>().text = Collector.currentRizkamon.Name;
        GameObject.Find("currentRizkamonImage").GetComponent<Image>().sprite = GameObject.Find(Collector.currentRizkamon.Name).GetComponent<Image>().sprite;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        openShop.enabled = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        openShop.enabled = false;
        PcDeactivate();
    }
    public void PcActivate()
    {
        Shop.ShopActivation(true, "Selector");
    }

    public void PcDeactivate()
    {
        Shop.ShopActivation(false, "Selector");
    }

    public void findRizkamon(string rizkamonName)
    {
        foreach (Creature rizkamon in Collector.have_rizkamons)
        {
            if (rizkamon.Name == rizkamonName)
            {
                Collector.currentRizkamon = rizkamon;
            }
        }
    }
}
