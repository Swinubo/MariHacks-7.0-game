using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = System.Random;
using System.Threading;
public class Change_to_battle : MonoBehaviour
{
    [SerializeField] private Camera mainCam;
    [SerializeField] private Camera battleCam;
    public static string rizkamon = "";
    Random random = new Random();
    private int randomNumber;
    private Rigidbody2D rb;
    private Image TapToShoot;
    public static bool battleDisplayRan = false;

    private void Start()
    {
        rb = GameObject.Find("Player").GetComponent<Rigidbody2D>();
        TapToShoot = GameObject.Find("TapToShoot").GetComponent<Image>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            randomNumber = random.Next(0, 3);
            if (randomNumber == 2)
            {   
                if (!battleDisplayRan)
                {
                    GameObject.Find("Battle").GetComponent<AudioSource>().enabled =true; 
                    GameObject.Find("Player").GetComponent<AudioSource>().enabled =false; 
                    rb.bodyType = RigidbodyType2D.Static;                   
                    Player_Movement.playToBattle = true; 
                    Debug.Log(battleDisplayRan);
                }
            }
        }
    }

    //public static void SendToBattleSetting(Camera battleCam, Camera mainCam, Random random, int randomNumber)
    private void SendToBattleSetting()
    {
        if (!battleDisplayRan)
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
            battleDisplayRan = true;
            Player_Movement.playToBattle = false;   
            battleCam.enabled = true;
            mainCam.enabled = false;
            GameObject.Find("ButtonToFlee").GetComponent<Image>().enabled =true; 
            GameObject.Find("ButtonToFlee").GetComponent<Button>().enabled =true; 
            GameObject.Find("TextForFlee").GetComponent<Text>().enabled =true; 
            GameObject.Find("PressSPCBAR").GetComponent<Text>().enabled =true;
            GameObject.Find("TapToShoot").GetComponent<Button>().enabled =true;
            TapToShoot.raycastTarget = true;

            if (displ_location.location_str == "Rizz city")
            {
                chooseInRizzCity();
            }
            else if (displ_location.location_str == "Sky-bidi forest")
            {
                chooseInSkybidiForest();
            }
            else if (displ_location.location_str == "Edger's mountain")
            {
                chooseInEdgersMountain();
            }
        }
    }

    private void chooseInSkybidiForest()
    {
        randomNumber = random.Next(1, 5);
        if (randomNumber == 1)
        {
            rizkamon = "bip";
            GameObject.Find("Bip_irnl").GetComponent<SpriteRenderer>().enabled =true;
            GameObject.Find("Bip_irnl").GetComponent<BoxCollider2D>().enabled =true; 
        }
        else if (randomNumber == 2)
        {
            rizkamon = "richard";
            GameObject.Find("Richard_irnl").GetComponent<SpriteRenderer>().enabled =true; 
            GameObject.Find("Richard_irnl").GetComponent<BoxCollider2D>().enabled =true; 
        }
        else if (randomNumber == 3)
        {
            rizkamon = "punny";
            GameObject.Find("Punny_irnl").GetComponent<SpriteRenderer>().enabled =true; 
            GameObject.Find("Punny_irnl").GetComponent<BoxCollider2D>().enabled =true; 
        }
        else if (randomNumber == 4)
        {
            rizkamon = "joe";
            GameObject.Find("Joe_irnl").GetComponent<SpriteRenderer>().enabled =true; 
            GameObject.Find("Joe_irnl").GetComponent<BoxCollider2D>().enabled =true; 
        }
    }

    private void chooseInRizzCity()
    {
        randomNumber = random.Next(1, 3);
        if (randomNumber == 1)
        {
            rizkamon = "alvin";
            GameObject.Find("AlvinJR_irnl").GetComponent<SpriteRenderer>().enabled =true; 
            GameObject.Find("AlvinJR_irnl").GetComponent<BoxCollider2D>().enabled =true; 
        }
        else if (randomNumber == 2)
        {
            rizkamon = "whale";
            GameObject.Find("Whale_irnl").GetComponent<SpriteRenderer>().enabled =true; 
            GameObject.Find("Whale_irnl").GetComponent<BoxCollider2D>().enabled =true; 
        }
    }

    private void chooseInEdgersMountain()
    {
        randomNumber = random.Next(1, 6);
        if (randomNumber == 1)
        {
            rizkamon = "quakor";
            GameObject.Find("Quakor_irnl").GetComponent<SpriteRenderer>().enabled =true;
            GameObject.Find("Quakor_irnl").GetComponent<BoxCollider2D>().enabled =true; 
        }
        else if (randomNumber == 2)
        {
            rizkamon = "beeogee";
            GameObject.Find("Beeogee_irnl").GetComponent<SpriteRenderer>().enabled =true; 
            GameObject.Find("Beeogee_irnl").GetComponent<BoxCollider2D>().enabled =true; 
        }
        else if (randomNumber == 3)
        {
            rizkamon = "bellico";
            GameObject.Find("Bellico_irnl").GetComponent<SpriteRenderer>().enabled =true; 
            GameObject.Find("Bellico_irnl").GetComponent<BoxCollider2D>().enabled =true; 
        }
        else if (randomNumber == 4)
        {
            rizkamon = "terroc";
            GameObject.Find("Terroc_irnl").GetComponent<SpriteRenderer>().enabled =true; 
            GameObject.Find("Terroc_irnl").GetComponent<BoxCollider2D>().enabled =true; 
        }
        else if (randomNumber == 5)
        {
            rizkamon = "jo";
            GameObject.Find("Jo_irnl").GetComponent<SpriteRenderer>().enabled =true; 
            GameObject.Find("Jo_irnl").GetComponent<BoxCollider2D>().enabled =true; 
        }
    }
}