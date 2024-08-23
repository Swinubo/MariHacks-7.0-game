using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    private Button openShop;
    private Rigidbody2D rb;
    private Text updates;
    // Start is called before the first frame update
    void Start()
    {
        openShop = GameObject.Find("Counter Interact").GetComponent<Button>();
        rb = GameObject.Find("Player").GetComponent<Rigidbody2D>();
        updates = GameObject.Find("updates Text").GetComponent<Text>();
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
        StartCoroutine(heal());
    }

    IEnumerator heal()
    {
        rb.bodyType = RigidbodyType2D.Static;
        updates.enabled = true;
        for (int i = 0; i < 5; i++) 
        {
            updates.text = "Healing··.";
            yield return new WaitForSeconds(0.2f);
            updates.text = "Healing.··";
            yield return new WaitForSeconds(0.2f);
            updates.text = "Healing·.·";
            yield return new WaitForSeconds(0.2f);
        }
        updates.text = Collector.currentRizkamon.Name +  " has been healed!";
        yield return new WaitForSeconds(2);
        updates.enabled = false;
        
        Collector.currentRizkamon = new Creature(Collector.currentRizkamon);
        rb.bodyType = RigidbodyType2D.Dynamic;
    }
}
