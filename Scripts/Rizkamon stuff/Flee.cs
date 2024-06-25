using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Flee : MonoBehaviour
{
    private Camera mainCam;
    private Camera battleCam;
    private static Image TapToShoot;

    void Start()
    {
        TapToShoot = GameObject.Find("TapToShoot").GetComponent<Image>();

        mainCam = GameObject.Find("Main Camera").GetComponent<Camera>();
        battleCam = GameObject.Find("Battle Camera").GetComponent<Camera>();
    }

    public void OnFlee(){
        deleteAllBattle(mainCam, battleCam);
    }

    public static void deleteAllBattle(Camera mainCam, Camera battleCam){
        battleCam.enabled = false;
        mainCam.enabled = true;
        Change_to_battle.battleDisplayRan = false;
        GameObject.Find("Battle").GetComponent<AudioSource>().enabled =false; 
        GameObject.Find("Player").GetComponent<AudioSource>().enabled =true; 
        foreach (var item in Collector.rizkamons)
        {
            GameObject.Find(item.name).GetComponent<SpriteRenderer>().enabled =false;
            GameObject.Find(item.name).GetComponent<BoxCollider2D>().enabled =false;
        }
        TapToShoot.raycastTarget = false;
    }
}
