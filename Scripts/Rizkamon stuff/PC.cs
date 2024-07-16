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
            Debug.Log(rizkamon.Name);
            Debug.Log("dd");
            if (rizkamon.Name == rizkamonName)
            {
                Collector.currentRizkamon = rizkamon;
                Debug.Log(Collector.currentRizkamon.Name);
            }
        }
        Debug.Log("he;");
    }
}
