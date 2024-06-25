using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnCollideWithBullet : MonoBehaviour
{
    private Camera mainCam;
    private Camera battleCam;

    void Start()
    {
        mainCam = GameObject.Find("Main Camera").GetComponent<Camera>();
        battleCam = GameObject.Find("Battle Camera").GetComponent<Camera>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Bullet(Clone)")
        {
            battleCam.enabled = false;
            mainCam.enabled = true;
            Change_to_battle.battleDisplayRan = false;
            GameObject.Find("Battle").GetComponent<AudioSource>().enabled =false; 
            GameObject.Find("Player").GetComponent<AudioSource>().enabled =true; 
            Debug.Log(Change_to_battle.rizkamon);

            foreach (var item in Collector.rizkamons)
            {
                GameObject.Find(item.name).GetComponent<SpriteRenderer>().enabled =false;
                GameObject.Find(item.name).GetComponent<BoxCollider2D>().enabled =false;
            }

            Collector.have_rizkamons.Add(Change_to_battle.rizkamon);
            Debug.Log("Added rizkamon: " + Change_to_battle.rizkamon);
        }
    }
}
