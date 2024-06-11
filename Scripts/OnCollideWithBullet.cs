using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnCollideWithBullet : MonoBehaviour
{
    [SerializeField] private Camera mainCam;
    [SerializeField] private Camera battleCam;

    
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
            GameObject.Find("ButtonToFlee").GetComponent<Image>().enabled =false; 
            GameObject.Find("TextForFlee").GetComponent<Text>().enabled =false; 
            GameObject.Find("ButtonToFlee").GetComponent<Button>().enabled =false; 
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

            if (Change_to_battle.rizkamon == "bip")
            {
                GameObject.Find("Bip_irnl").GetComponent<SpriteRenderer>().enabled =false;
                GameObject.Find("Bip_irnl").GetComponent<BoxCollider2D>().enabled =false; 
                Collector.have_bip = true;
            }
            else if (Change_to_battle.rizkamon == "richard")
            {
                GameObject.Find("Richard_irnl").GetComponent<SpriteRenderer>().enabled =false; 
                GameObject.Find("Richard_irnl").GetComponent<BoxCollider2D>().enabled =false; 
                Collector.have_richard = true;                   
            }
            else if (Change_to_battle.rizkamon == "punny")
            {
                GameObject.Find("Punny_irnl").GetComponent<SpriteRenderer>().enabled =false; 
                GameObject.Find("Punny_irnl").GetComponent<BoxCollider2D>().enabled =false;   
                Collector.have_punny = true;          

            }
            else if (Change_to_battle.rizkamon == "joe")
            {
                GameObject.Find("Joe_irnl").GetComponent<SpriteRenderer>().enabled =false; 
                GameObject.Find("Joe_irnl").GetComponent<BoxCollider2D>().enabled =false; 
                Collector.have_joe = true;                  
            
            }
            else if (Change_to_battle.rizkamon == "alvin")
            {
                GameObject.Find("AlvinJR_irnl").GetComponent<SpriteRenderer>().enabled =false; 
                GameObject.Find("AlvinJR_irnl").GetComponent<BoxCollider2D>().enabled =false; 
                Collector.have_alvin = true;                  
            
            }
            else if (Change_to_battle.rizkamon == "whale")
            {
                GameObject.Find("Whale_irnl").GetComponent<SpriteRenderer>().enabled =false; 
                GameObject.Find("Whale_irnl").GetComponent<BoxCollider2D>().enabled =false; 
                Collector.have_whale = true;                             
            }
            else if (Change_to_battle.rizkamon == "travis")
            {
                GameObject.Find("Travis_irnl").GetComponent<SpriteRenderer>().enabled =false; 
                GameObject.Find("Travis_irnl").GetComponent<BoxCollider2D>().enabled =false; 
                Collector.have_travis = true;                             
            }
            else if (Change_to_battle.rizkamon == "ligma")
            {
                GameObject.Find("Ligma_irnl").GetComponent<SpriteRenderer>().enabled =false; 
                GameObject.Find("Ligma_irnl").GetComponent<BoxCollider2D>().enabled =false; 
                Collector.have_ligma = true;                             
            }
            else if (Change_to_battle.rizkamon == "quakor")
            {
                GameObject.Find("Quakor_irnl").GetComponent<SpriteRenderer>().enabled =false; 
                GameObject.Find("Quakor_irnl").GetComponent<BoxCollider2D>().enabled =false; 
                Collector.have_quakor = true;                             
            }
            else if (Change_to_battle.rizkamon == "beeogee")
            {
                GameObject.Find("Beeogee_irnl").GetComponent<SpriteRenderer>().enabled =false; 
                GameObject.Find("Beeogee_irnl").GetComponent<BoxCollider2D>().enabled =false; 
                Collector.have_beeogee = true;                             
            }
            else if (Change_to_battle.rizkamon == "bellico")
            {
                GameObject.Find("Bellico_irnl").GetComponent<SpriteRenderer>().enabled =false; 
                GameObject.Find("Bellico_irnl").GetComponent<BoxCollider2D>().enabled =false; 
                Collector.have_bellico = true;                             
            }
            else if (Change_to_battle.rizkamon == "terroc")
            {
                GameObject.Find("Terroc_irnl").GetComponent<SpriteRenderer>().enabled =false; 
                GameObject.Find("Terroc_irnl").GetComponent<BoxCollider2D>().enabled =false; 
                Collector.have_terroc = true;                             
            }
            else if (Change_to_battle.rizkamon == "jo")
            {
                GameObject.Find("Jo_irnl").GetComponent<SpriteRenderer>().enabled =false; 
                GameObject.Find("Jo_irnl").GetComponent<BoxCollider2D>().enabled =false; 
                Collector.have_jo = true;                             
            }
        }
    }
}
