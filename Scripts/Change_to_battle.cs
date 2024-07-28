using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = System.Random;

public class Change_to_battle : MonoBehaviour
{
    private Camera mainCam;
    private Camera battleCam;
    public static Creature rizkamon;
    Random random = new Random();
    private int randomNumber;
    private Rigidbody2D rb;
    public static bool battleDisplayRan = false;
    private bool inBattle = false;
    private Text gen_text;
    private int messageCount;
    private Animator anim;
    public static Image trans;

    //location string lists
    private Creature[] sky_bidi;
    private Creature[] rizz;
    private Creature[] edge;

    private void Start()
    {
        rb = GameObject.Find("Player").GetComponent<Rigidbody2D>();
        mainCam = GameObject.Find("Main Camera").GetComponent<Camera>();
        battleCam = GameObject.Find("Battle Camera").GetComponent<Camera>();

        gen_text = GameObject.Find("text").GetComponent<Text>();

        anim = GameObject.Find("Arm").GetComponent<Animator>();

        trans = GameObject.Find("trans BGRND").GetComponent<Image>();

        //location creature lists
        sky_bidi = new Creature[] { Creature.Bip, Creature.Richard, Creature.Punny, Creature.Joe };
        rizz = new Creature[] { Creature.AlvinJR, Creature.Whale };
        edge = new Creature[] { Creature.Bellico, Creature.Beeogee, Creature.Terroc, Creature.Quakor, Creature.Jo };
    }

    private void Update()
    {
        if (inBattle)
        {
            //update healths
            GameObject.Find("My HP").GetComponent<Text>().text = Collector.currentRizkamon.Health.ToString() + " HP";
            GameObject.Find("Foe HP").GetComponent<Text>().text = rizkamon.Health.ToString() + "HP";
        }
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
                    GameObject.Find("Battle").GetComponent<AudioSource>().enabled = true;
                    GameObject.Find("Player").GetComponent<AudioSource>().enabled = false;
                    rb.bodyType = RigidbodyType2D.Static;
                    Player_Movement.playToBattle = true;
                }
            }
        }
    }

    private void SendToBattleSetting()
    {
        if (!battleDisplayRan)
        {
            Flee.BattleActivation(mainCam, battleCam, true);
            Player_Movement.playToBattle = false;

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

    private void chooseRizkamon(Creature[] rizkamonList)
    {
        // Generate a random index
        int randomIndex = random.Next(rizkamonList.Length);
        Debug.Log(randomIndex);

        // Retrieve the creature at the random index
        rizkamon = rizkamonList[randomIndex];
        Debug.Log(rizkamon.Name);

       // Debug.Log(rizkamon.Name);
        GameObject.Find(rizkamon.Name + "_irnl").GetComponent<SpriteRenderer>().enabled = true;
        GameObject.Find(rizkamon.Name + "_irnl").GetComponent<BoxCollider2D>().enabled = true;

      //  GameObject.Find(Collector.currentRizkamon.Name + "_irnly").GetComponent<BoxCollider2D>().enabled = true;

        GameObject.Find("Move1Text").GetComponent<Text>().text = Collector.currentRizkamon.Move1.Name;
        GameObject.Find("Move2Text").GetComponent<Text>().text = Collector.currentRizkamon.Move2.Name;

        inBattle = true;

        displ_texts();
    }

    private void displ_texts()
    {          
        GameObject.Find("text").GetComponent<Text>().enabled =true; 
        GameObject.Find("General_text").GetComponent<Image>().enabled =true; 
        GameObject.Find("General_text").GetComponent<Button>().enabled =true; 

        StartCoroutine(BattleTypewriter("A wild " + rizkamon.Name + " has appeared!", gen_text));
        trans.raycastTarget = true;
    }

    IEnumerator BattleTypewriter(string text, Text text_displ)
    {
        text_displ.text = "";

        foreach (char letter in text)
        {
            text_displ.text += letter;

            if (letter == '!')
            {           
                yield return new WaitForSeconds(0.5f);
            }
            else
            {
                yield return new WaitForSeconds(0.05f);
            }
        }

        ++messageCount;

        if (messageCount == 1)
        {
            StartCoroutine(BattleTypewriter("Go " + Collector.currentRizkamon.Name + "!", gen_text));
        }
        else if (messageCount == 2)
        {
            anim.SetBool("throwing", true);
            yield return new WaitForSeconds(0.5f);
            displayMyRizkamon();
        }
    }

    private void displayMyRizkamon()
    {
        GameObject.Find(Collector.currentRizkamon.Name + "_irnly").GetComponent<SpriteRenderer>().enabled = true;

        GameObject.Find("text").GetComponent<Text>().enabled =false; 
        GameObject.Find("General_text").GetComponent<Image>().enabled =false; 
        GameObject.Find("General_text").GetComponent<Button>().enabled =false;

        trans.raycastTarget = false;
    }
}
