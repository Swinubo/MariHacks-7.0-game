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

    //location string lists
    private string[] sky_bidi = {"Bip", "Richard", "Punny", "Joe"};
    private string[] rizz = {"AlvinJR", "Whale"};
    private string[] edge = {"Quakor", "Terroc", "Beeogee", "Bellico", "Jo"};


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
            TapToShoot.raycastTarget = true;

            if (displ_location.location_str == "Rizz city")
            {
                chooseRizkamon(rizz);
            }
            else if (displ_location.location_str == "Sky-bidi forest")
            {
                chooseRizkamon(sky_bidi);
            }
            else if (displ_location.location_str == "Edger's mountain")
            {
                chooseRizkamon(edge);
            }
        }
    }

    private void chooseRizkamon(string[] rizkamonList)
    {
        // Generate a random index
        int randomIndex = random.Next(rizkamonList.Length);

        // Retrieve the string at the random index
        string rizkamon = rizkamonList[randomIndex];

        GameObject.Find(rizkamon+"_irnl").GetComponent<SpriteRenderer>().enabled =true; 
        GameObject.Find(rizkamon+"_irnl").GetComponent<BoxCollider2D>().enabled =true; 

    }
}