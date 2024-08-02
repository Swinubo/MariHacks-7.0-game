using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    private Button openShop;
    // Start is called before the first frame update
    void Start()
    {
        openShop = GameObject.Find("Counter Interact").GetComponent<Button>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        openShop.enabled = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        openShop.enabled = false;
    }

    public void CounterInteract()
    {
        Collector.currentRizkamon = new Creature(Collector.currentRizkamon);
    }
}
