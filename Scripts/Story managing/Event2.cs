using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Event2 : MonoBehaviour
{
    private Text text_displ;
    [SerializeField] private string[] my_text;
    [SerializeField] private int when_move;
    private int currentText = 0;
    private Rigidbody2D rb;
    private Rigidbody2D MomRb;
    private NPC MomNPC;
    private enum movement_state { idle, up, down, running }
    private static bool triggered = false;
    public static Animator anim;
    private SpriteRenderer sprite;

    private float dirX=0;
    private float dirY=0;
    [SerializeField] private float move_speed=200f;

    //0 = initially getting out of bed
    //1 = trying to leave the house but then mom calls

    private void Start()
    {
        text_displ = GameObject.Find("text").GetComponent<Text>(); 
        rb = GameObject.Find("Player").GetComponent<Rigidbody2D>();
        MomRb = GameObject.Find("NPC_Mom").GetComponent<Rigidbody2D>();
        anim = GameObject.Find("NPC_Mom").GetComponent<Animator>();
        sprite = GameObject.Find("NPC_Mom").GetComponent<SpriteRenderer>();
        MomNPC = GameObject.Find("NPC_Mom").GetComponent<NPC>();
    }

    private void Update()
    {
        MomRb.velocity = new Vector2(dirX * move_speed, dirY * move_speed);
        update_animations();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            if (!triggered)
            {
                triggered = true;
                rb.bodyType = RigidbodyType2D.Static;
                MomNPC.enabled = false;
                StartCoroutine(Typewriter());
            }
        }
    }

    IEnumerator Typewriter()
    {
        ActivateTextDispl(true);
        text_displ.text = "";
        foreach (string text in my_text)
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
            currentText += 1;
            yield return new WaitForSeconds(0.5f);
            text_displ.text = "";

            if (currentText == when_move)
            {
                dirY = -1;
                yield return new WaitForSeconds(1.3f);
                dirY = 0;
                ActivateTextDispl(true);
            }
        }

        dirY = 1;
        yield return new WaitForSeconds(1.3f);
        dirY = 0;

        ActivateTextDispl(false);
        rb.bodyType = RigidbodyType2D.Dynamic;
        MomNPC.enabled = true;

    }

    private void ActivateTextDispl(bool OnOrOff)
    {
        text_displ.text = "";
        GameObject.Find("text").GetComponent<Text>().enabled =OnOrOff; 
        GameObject.Find("General_text").GetComponent<Image>().enabled =OnOrOff; 
        GameObject.Find("General_text").GetComponent<Button>().enabled =OnOrOff; 
    }

    private void update_animations()
    {
        movement_state state;

        if (dirY > 0f)
        {
            state = movement_state.down;
        }
        else if (dirY < 0f)
        {
            state = movement_state.up;
        }
        else
        {
            state = movement_state.idle;
        }

        anim.SetInteger("state", (int)state);
    }
}