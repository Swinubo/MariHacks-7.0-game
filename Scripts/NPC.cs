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
    private string alexander = "Alexander: My uncle Robert livesin the middle east!";
    private string mbappee = "Mbappee: Don't walk on grass! Catalans will attack you!";
    private string renchesse = "Renchesse: I'm a woman???";
    private string logan = "Logan: Did you know you snore at night?";
    private string mom = "Mom: Hey son! Glad to see you back! Go explore the world of Monsters of Dawn!";
    [SerializeField] private Text npc_text;
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
            GameObject.Find("NPC_text").GetComponent<Text>().enabled =true; 
            GameObject.Find("NPC_displ").GetComponent<Image>().enabled =true; 
            GameObject.Find("NPC_displ").GetComponent<Button>().enabled =true; 

            if (gameObject.name == "NPC_Gartner")
            {
                npc_text.text = gartner;
            }
            else if (gameObject.name == "NPC_Fox")
            {
                npc_text.text = fox;
            }
            else if (gameObject.name == "NPC_Piper")
            {
                npc_text.text = piper;
            }
            else if (gameObject.name == "NPC_Anderson")
            {
                npc_text.text = anderson;
            }
            else if (gameObject.name == "NPC_Baifield")
            {
                npc_text.text = baifield;
            }
            else if (gameObject.name == "NPC_Joseph")
            {
                npc_text.text = joseph;
            }
            else if (gameObject.name == "NPC_Alexander")
            {
                npc_text.text = alexander;
            }
            else if (gameObject.name == "NPC_Mbappee")
            {
                npc_text.text = mbappee;
            }
            else if (gameObject.name == "NPC_Renchesse")
            {
                npc_text.text = renchesse;
            }
            else if (gameObject.name == "NPC_Logan")
            {
                npc_text.text = logan;
            }
            else if (gameObject.name == "NPC_Mom")
            {
                StartCoroutine(DisplayMomText());         
            }
            
        }
    }

    IEnumerator DisplayMomText()
    {
        npc_text.text = mom;
        rb.bodyType = RigidbodyType2D.Static;
        yield return new WaitForSeconds(3);
        anim.SetBool("leave", true);
        rbMum.velocity = new Vector2(0, move_speed);
        rb.bodyType = RigidbodyType2D.Dynamic;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        removeNPCdispl();
    }

    public void shrugNPC()
    {
        removeNPCdispl();
    }

    private void removeNPCdispl()
    {
        GameObject.Find("NPC_text").GetComponent<Text>().enabled =false; 
        GameObject.Find("NPC_displ").GetComponent<Image>().enabled =false; 
        GameObject.Find("NPC_displ").GetComponent<Button>().enabled =false; 
    }
}
