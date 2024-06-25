using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Flee : MonoBehaviour
{
    private Camera mainCam;
    private Camera battleCam;

    void Start()
    {
        mainCam = GameObject.Find("Main Camera").GetComponent<Camera>();
        battleCam = GameObject.Find("Battle Camera").GetComponent<Camera>();
    }

    public void OnFlee(){
        deleteAllBattle(mainCam, battleCam, true);
    }

    public static void deleteAllBattle(Camera mainCam, Camera battleCam, bool OnorOff){
        battleCam.enabled = !OnorOff;
        mainCam.enabled = OnorOff;
        Change_to_battle.battleDisplayRan = !OnorOff;
        GameObject.Find("Battle").GetComponent<AudioSource>().enabled =!OnorOff; 
        GameObject.Find("Player").GetComponent<AudioSource>().enabled =OnorOff; 
        GameObject.Find("Balls").GetComponent<Image>().enabled =OnorOff; 
        GameObject.Find("Move1").GetComponent<Image>().enabled =OnorOff;
        GameObject.Find("Move2").GetComponent<Image>().enabled =OnorOff;
        GameObject.Find("Flee").GetComponent<Image>().enabled =OnorOff;
        GameObject.Find("Balls").GetComponent<Button>().enabled =OnorOff; 
        GameObject.Find("Move1").GetComponent<Button>().enabled =OnorOff;
        GameObject.Find("Move2").GetComponent<Button>().enabled =OnorOff;
        GameObject.Find("Flee").GetComponent<Button>().enabled =OnorOff;
        GameObject.Find("BallsText").GetComponent<Text>().enabled =OnorOff; 
        GameObject.Find("Move1Text").GetComponent<Text>().enabled =OnorOff;
        GameObject.Find("Move2Text").GetComponent<Text>().enabled =OnorOff;
        GameObject.Find("FleeText").GetComponent<Text>().enabled =OnorOff;

        foreach (var item in Collector.rizkamons)
        {
            GameObject.Find(item.name).GetComponent<SpriteRenderer>().enabled =false;
            GameObject.Find(item.name).GetComponent<BoxCollider2D>().enabled =false;
        }
    }
}
