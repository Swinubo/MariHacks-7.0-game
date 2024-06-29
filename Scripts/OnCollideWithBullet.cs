using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnCollideWithBullet : MonoBehaviour
{
    private Camera mainCam;
    private Camera battleCam;

    private Rigidbody2D rb;

    private BoxCollider2D ballBC2D;
    private Rigidbody2D ballRB2D;

    void Start()
    {
        mainCam = GameObject.Find("Main Camera").GetComponent<Camera>();
        battleCam = GameObject.Find("Battle Camera").GetComponent<Camera>();

        rb = GameObject.Find("Player").GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            ballBC2D = GameObject.Find(collision.gameObject.name).GetComponent<BoxCollider2D>();
            ballRB2D = GameObject.Find(collision.gameObject.name).GetComponent<Rigidbody2D>();

            ballBC2D.isTrigger = false;
        }
    }

    private void AddRizkamon()
    {
        Flee.BattleActivation(mainCam, battleCam, true);
        rb.bodyType = RigidbodyType2D.Dynamic;

        foreach (var item in Collector.rizkamons)
        {
            GameObject.Find(item.name).GetComponent<SpriteRenderer>().enabled =false;
            GameObject.Find(item.name).GetComponent<BoxCollider2D>().enabled =false;
        }

        Collector.have_rizkamons.Add(Change_to_battle.rizkamon);
        Debug.Log("Added rizkamon: " + Change_to_battle.rizkamon);
    }
}
