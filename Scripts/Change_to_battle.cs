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
    public static bool battleDisplayRan = false;

    private void Start()
    {
        rb = GameObject.Find("Player").GetComponent<Rigidbody2D>();
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
            GameObject.Find("Right").GetComponent<Image>().enabled =false;
            GameObject.Find("Left").GetComponent<Image>().enabled =false;
            GameObject.Find("Up").GetComponent<Image>().enabled =false;
            GameObject.Find("Down").GetComponent<Image>().enabled =false;
            GameObject.Find("Shift").GetComponent<Image>().enabled =false;
            GameObject.Find("Right").GetComponent<Button>().enabled =false;
            GameObject.Find("Left").GetComponent<Button>().enabled =false;
            GameObject.Find("Up").GetComponent<Button>().enabled =false;
            GameObject.Find("Down").GetComponent<Button>().enabled =false; 
            GameObject.Find("Shift").GetComponent<Button>().enabled =false; 

            randomNumber = random.Next(1, 5);
            if (randomNumber == 1)
            {
                rizkamon = "bip";
                GameObject.Find("Bip_irnl").GetComponent<SpriteRenderer>().enabled =true;
                GameObject.Find("Bip_irnl").GetComponent<BoxCollider2D>().enabled =true; 
            }
            if (randomNumber == 2)
            {
                rizkamon = "richard";
                GameObject.Find("Richard_irnl").GetComponent<SpriteRenderer>().enabled =true; 
                GameObject.Find("Richard_irnl").GetComponent<BoxCollider2D>().enabled =true; 
            }
            if (randomNumber == 3)
            {
                rizkamon = "punny";
                GameObject.Find("Punny_irnl").GetComponent<SpriteRenderer>().enabled =true; 
                GameObject.Find("Punny_irnl").GetComponent<BoxCollider2D>().enabled =true; 
            }
            if (randomNumber == 4)
            {
                rizkamon = "joe";
                GameObject.Find("Joe_irnl").GetComponent<SpriteRenderer>().enabled =true; 
                GameObject.Find("Joe_irnl").GetComponent<BoxCollider2D>().enabled =true; 
            }
        }
    }
}