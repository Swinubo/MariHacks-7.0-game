using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Flee : MonoBehaviour
{
    [SerializeField] private Camera mainCam;
    [SerializeField] private Camera battleCam;

    public void OnFlee(){
        deleteAllBattle(mainCam, battleCam);
    }

    public static void deleteAllBattle(Camera mainCam, Camera battleCam){
        battleCam.enabled = false;
        mainCam.enabled = true;
        Change_to_battle.battleDisplayRan = false;
        GameObject.Find("Battle").GetComponent<AudioSource>().enabled =false; 
        GameObject.Find("Player").GetComponent<AudioSource>().enabled =true; 
        GameObject.Find("ButtonToFlee").GetComponent<Image>().enabled =false; 
        GameObject.Find("TextForFlee").GetComponent<Text>().enabled =false; 
        GameObject.Find("ButtonToFlee").GetComponent<Button>().enabled =false; 
        foreach (var item in Collector.rizkamons)
        {
            GameObject.Find(item.name).GetComponent<SpriteRenderer>().enabled =false;
            GameObject.Find(item.name).GetComponent<BoxCollider2D>().enabled =false;
        }
        GameObject.Find("PressSPCBAR").GetComponent<Text>().enabled =false;  
        GameObject.Find("TapToShoot").GetComponent<Button>().enabled =false;  
        if (Player_Movement.use_buttons)
        {
            GameObject.Find("Right").GetComponent<Image>().enabled =true;
            GameObject.Find("Left").GetComponent<Image>().enabled =true;
            GameObject.Find("Up").GetComponent<Image>().enabled =true;
            GameObject.Find("Down").GetComponent<Image>().enabled =true;
            GameObject.Find("Shift").GetComponent<Image>().enabled =true;
            GameObject.Find("Right").GetComponent<Button>().enabled =true;
            GameObject.Find("Left").GetComponent<Button>().enabled =true;
            GameObject.Find("Up").GetComponent<Button>().enabled =true;
            GameObject.Find("Down").GetComponent<Button>().enabled =true;
            GameObject.Find("Shift").GetComponent<Image>().enabled =true;
        }
    }
}
