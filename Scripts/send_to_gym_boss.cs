using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class send_to_gym_boss : MonoBehaviour
{   
    private Camera mainCam;
    private Camera battleCam;
    [SerializeField] private int gym_leader;
    //0 = Rizz city gym leader
    //1 = Gyatt city gym leader
    public static bool inBattle = false;
    private Text gen_text;
    private int messageCount;
    private Animator anim;
    public static Image trans;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
            SceneManager.LoadScene(2);
        }
    }

    private void StartInNewScene()
    {
        mainCam = GameObject.Find("Main Camera").GetComponent<Camera>();
        battleCam = GameObject.Find("Battle Camera").GetComponent<Camera>();

        gen_text = GameObject.Find("text").GetComponent<Text>();

        anim = GameObject.Find("Arm").GetComponent<Animator>();

        trans = GameObject.Find("trans BGRND").GetComponent<Image>();
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        StartInNewScene();
        updatePos();
        if (gym_leader == 0)
        {
            Change_to_battle.rizkamon = Creature.Travis;
            GameObject.Find("Travis_irnl").GetComponent<SpriteRenderer>().enabled =true; 
            GameObject.Find("Travis_irnl").GetComponent<BoxCollider2D>().enabled =true; 
        }
        else if (gym_leader == 1)
        {
            Change_to_battle.rizkamon = Creature.Ligma;
            GameObject.Find("Ligma_irnl").GetComponent<SpriteRenderer>().enabled =true; 
            GameObject.Find("Ligma_irnl").GetComponent<BoxCollider2D>().enabled =true; 
        }
        sendBattle();
        // Unsubscribe from the event to prevent memory leaks
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void updatePos()
    {
        Transform player = GameObject.Find("Player").GetComponent<Transform>();          
        Vector3 newPosition = new Vector3(change_scene.player_x, change_scene.player_y-5, player.position.z);
        player.position = newPosition;
    }

    private void sendBattle()
    {
        GameObject.Find(Change_to_battle.rizkamon.Name + "_irnl").GetComponent<SpriteRenderer>().enabled = true;
        GameObject.Find(Change_to_battle.rizkamon.Name + "_irnl").GetComponent<BoxCollider2D>().enabled = true;

        Flee.BattleActivation(mainCam, battleCam, true);

        GameObject.Find("Move1Text").GetComponent<Text>().text = Collector.currentRizkamon.Move1.Name;
        GameObject.Find("Move2Text").GetComponent<Text>().text = Collector.currentRizkamon.Move2.Name;

        inBattle = true;

        
        //displ_texts();
        anim.SetBool("throwing", true);
        displayMyRizkamon();
    }

    private void displ_texts()
    {          
        GameObject.Find("text").GetComponent<Text>().enabled =true; 
        GameObject.Find("General_text").GetComponent<Image>().enabled =true; 
        GameObject.Find("General_text").GetComponent<Button>().enabled =true; 

        //StartCoroutine(BattleTypewriter("A wild " + Change_to_battle.rizkamon.Name + " has appeared!", gen_text));
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

        messageCount = 0;
    }
}
