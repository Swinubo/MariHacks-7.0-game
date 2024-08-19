using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    /*private string gartner = "Gartner: I like apples, do you?";
    private string fox = "Fox: Aaaaaaargh! Woops, I'm just scared of my own name.";
    private string piper = "Piper: For the last time, I am NOT a Brawl Stars character!";
    private string anderson = "Annderson: Uhhhh, what I do... I play with CR7!";
    private string baifield = "Baifield: Only 7 monsters can be found here according to a certain mad scientist!";
    private string joseph = "Joseph: Don't disturb me, I'm mewing!";
    private string alexander = "Alexander: My uncle Robert lives in the middle east!";
    private string mbappee = "Mbappee: Don't walk on grass! Catalans will attack you!";
    private string renchesse = "Renchesse: I'm a woman???";
    private string logan = "Logan: Did you know you snore at night?";
    private string mom = "Mom: Hey son! Glad to see you back! Go explore the world of Monsters of Dawn!";*/
    [SerializeField] private string[] npc_text;
    [SerializeField] private bool statisize;

    private Text text_displ;
    private Rigidbody2D rb;

    private void Start()
    {
        text_displ = GameObject.Find("text").GetComponent<Text>(); 

        rb = GameObject.Find("Player").GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            ActivateTextDispl(true);
            StartCoroutine(Typewriter());
            //text_displ.text = npc_text; 
        }
    }

    IEnumerator Typewriter()
    {
        if (statisize)
        {
            rb.rb.bodyType = RigidbodyType2D.Static;
        }
        text_displ.text = "";
        foreach (string text in npc_text)
        {
            foreach (char letter in text)
            {
                text_displ.text += letter;

                if (letter == ':')
                {           
                    yield return new WaitForSeconds(0.2f);
                }
                else
                {
                    yield return new WaitForSeconds(0.05f);
                }

            }
            
            yield return new WaitForSeconds(0.5f);
            text_displ.text = "";
        }

        ActivateTextDispl(false);
        rb.bodyType = RigidbodyType2D.Dynamic;

    }

    //on leave events
    private void OnTriggerExit2D(Collider2D collision)
    {
        ActivateTextDispl(false);
    }

    public void shrugText()
    {
        ActivateTextDispl(false);
    }

    private void ActivateTextDispl(bool OnOrOff)
    {
        text_displ.text = "";
        GameObject.Find("text").GetComponent<Text>().enabled =OnOrOff; 
        GameObject.Find("General_text").GetComponent<Image>().enabled =OnOrOff; 
        GameObject.Find("General_text").GetComponent<Button>().enabled =OnOrOff; 
    }
}
