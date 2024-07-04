using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddRizkamon : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;

        private Camera mainCam;
    private Camera battleCam;

    void Start()
    {
        mainCam = GameObject.Find("Main Camera").GetComponent<Camera>();
        battleCam = GameObject.Find("Battle Camera").GetComponent<Camera>();

        rb = GameObject.Find("Player").GetComponent<Rigidbody2D>();
        anim = GameObject.Find("BallCatch").GetComponent<Animator>();
    }

    private void AddRizkamonToDex()
    {
        anim.SetBool("IsFlickering", false);
        Destroy(OnCollideWithBullet.ball);
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
