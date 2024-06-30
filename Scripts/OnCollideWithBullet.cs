using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnCollideWithBullet : MonoBehaviour
{
    private Camera mainCam;
    private Camera battleCam;

    private Rigidbody2D rb;

    private CircleCollider2D ballCC2D;
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
            ballCC2D = GameObject.Find(collision.gameObject.name).GetComponent<CircleCollider2D>();
            ballRB2D = GameObject.Find(collision.gameObject.name).GetComponent<Rigidbody2D>();

            ballCC2D.isTrigger = false;
            GameObject.Find(collision.gameObject.name).GetComponent<Rotate>().enabled = false;
            ballRB2D.velocity = new Vector2(0, 500);
            ballRB2D.gravityScale = 150;
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
