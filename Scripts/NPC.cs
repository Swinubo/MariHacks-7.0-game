using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public class NPC : MonoBehaviour
{
    private string gartner = "Gartner: I like apples, do you?";
    private string fox = "Fox: Aaaaaaargh! Woops, I'm just scared of my own name.";
    private string piper = "Piper: For the last time, I am NOT a Brawl Stars character!";
    private string anderson = "Annderson: Uhhhh, what I do... I play with CR7!";
    private string baifield = "Baifield: Only 4 monsters can be found here according to a certain mad scientist!";
    private string joseph = "Joseph: Don't disturb me, I'm mewing!";
    private string alexander = "Alexander: My uncle Robert lives in the middle east!";
    private string mbappee = "Mbappee: Don't walk on grass! Catalans will attack you!";
    private string renchesse = "Renchesse: I'm a woman???";
    private string logan = "Logan: Did you know you snore at night?";
    private string mom = "Mom: Hey son! Glad to see you back! Go explore the world of Monsters of Dawn!";

    [SerializeField] private Text text_displ;
    [SerializeField] private bool mumInScene;
    private Rigidbody2D rb;
    private Rigidbody2D rbMum;
    private Animator anim;
    private float move_speed = 300f;

    private void Start()
    {
        rb = GameObject.Find("Player").GetComponent<Rigidbody2D>();
        if (mumInScene)
        {
            rbMum = GameObject.Find("NPC_Mom").GetComponent<Rigidbody2D>();
            anim = GameObject.Find("NPC_Mom").GetComponent<Animator>();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            GameObject.Find("text").GetComponent<Text>().enabled =true; 
            GameObject.Find("General_text").GetComponent<Image>().enabled =true; 
            GameObject.Find("General_text").GetComponent<Button>().enabled =true; 

            if (gameObject.name == "NPC_Gartner")
            {
                text_displ.text = gartner;
            }
            else if (gameObject.name == "NPC_Fox")
            {
                text_displ.text = fox;
            }
            else if (gameObject.name == "NPC_Piper")
            {
                text_displ.text = piper;
            }
            else if (gameObject.name == "NPC_Anderson")
            {
                text_displ.text = anderson;
            }
            else if (gameObject.name == "NPC_Baifield")
            {
                text_displ.text = baifield;
            }
            else if (gameObject.name == "NPC_Joseph")
            {
                text_displ.text = joseph;
            }
            else if (gameObject.name == "NPC_Alexander")
            {
                text_displ.text = alexander;
            }
            else if (gameObject.name == "NPC_Mbappee")
            {
                text_displ.text = mbappee;
            }
            else if (gameObject.name == "NPC_Renchesse")
            {
                text_displ.text = renchesse;
            }
            else if (gameObject.name == "NPC_Logan")
            {
                text_displ.text = logan;
            }
            else if (gameObject.name == "NPC_Mom")
            {
                StartCoroutine(DisplayMomText());         
            }
            
        }
    }

    //mom
    IEnumerator DisplayMomText()
    {
        text_displ.text = mom;
        rb.bodyType = RigidbodyType2D.Static;
        yield return new WaitForSeconds(3);
        anim.SetBool("leave", true);
        rbMum.velocity = new Vector2(0, move_speed);
        rb.bodyType = RigidbodyType2D.Dynamic;
    }

    //essentials
    private void OnTriggerExit2D(Collider2D collision)
    {
        removeTextDispl();
    }

    public void shrugText()
    {
        removeTextDispl();
    }

    private void removeTextDispl()
    {
        GameObject.Find("text").GetComponent<Text>().enabled =false; 
        GameObject.Find("General_text").GetComponent<Image>().enabled =false; 
        GameObject.Find("General_text").GetComponent<Button>().enabled =false; 
    }
}
