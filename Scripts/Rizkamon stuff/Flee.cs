using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Flee : MonoBehaviour
{
    private Camera mainCam;
    private Camera battleCam;

    private Rigidbody2D rb;

    void Start()
    {
        mainCam = GameObject.Find("Main Camera").GetComponent<Camera>();
        battleCam = GameObject.Find("Battle Camera").GetComponent<Camera>();

        rb = GameObject.Find("Player").GetComponent<Rigidbody2D>();
    }

    public void OnFlee(){
        BattleActivation(mainCam, battleCam, false);
        foreach (var item in Collector.rizkamons)
        {
            GameObject.Find(item.name).GetComponent<SpriteRenderer>().enabled =false;
            GameObject.Find(item.name).GetComponent<BoxCollider2D>().enabled =false;
        }
        rb.bodyType = RigidbodyType2D.Dynamic;
    }

    public static void BattleActivation(Camera mainCam, Camera battleCam, bool OnorOff){
        battleCam.enabled = OnorOff;
        mainCam.enabled = !OnorOff;
        Change_to_battle.battleDisplayRan = OnorOff;
        GetOutOfStart.OnStart();
        GameObject.Find("Battle").GetComponent<AudioSource>().enabled =OnorOff; 
        GameObject.Find("Player").GetComponent<AudioSource>().enabled =!OnorOff; 
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
        GameObject.Find("PressSPCBAR").GetComponent<Text>().enabled =OnorOff;
        GameObject.Find("My HP").GetComponent<Text>().enabled =OnorOff;
        GameObject.Find("Foe HP").GetComponent<Text>().enabled =OnorOff;
        GameObject.Find("My Bar BGRND").GetComponent<Image>().enabled =OnorOff;
        GameObject.Find("My Bar").GetComponent<Image>().enabled =OnorOff;
        GameObject.Find("Foe Bar BGRND").GetComponent<Image>().enabled =OnorOff;
        GameObject.Find("Foe Bar").GetComponent<Image>().enabled =OnorOff;
        Debug.Log(Change_to_battle.rizkamon.Name + "_irnl");
        GameObject.Find(Change_to_battle.rizkamon.Name + "_irnl").GetComponent<Image>().enabled =OnorOff;
        GameObject.Find(Change_to_battle.rizkamon.Name + "_irnl").GetComponent<BoxCollider2D>().enabled =OnorOff;
        GameObject.Find(Collector.currentRizkamon.Name + "_irnly").GetComponent<Image>().enabled =OnorOff;
        Change_to_battle.rizkamon = new Creature(Change_to_battle.rizkamon);
        MoveManager.mySlider.value = 1;
        MoveManager.foeSlider.value = 1;
    }
}
