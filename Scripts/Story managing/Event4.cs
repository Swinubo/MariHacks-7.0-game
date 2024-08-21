using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Event4 : MonoBehaviour
{
    private static bool triggered = false;

    private Text text_displ;
    [SerializeField] private string[] my_text;
    private Rigidbody2D rb;
    private Rigidbody2D dRrb;
    private Animator anim;

    private float dirX=0;
    private float dirY=0;
    [SerializeField] private float move_speed=200f;

    private enum movement_state { idle, up, down, running }

    public static bool addTimer = false;

    private void Start()
    {
        text_displ = GameObject.Find("text").GetComponent<Text>(); 
        rb = GameObject.Find("Player").GetComponent<Rigidbody2D>();
        dRrb = GameObject.Find("Dr Rizz").GetComponent<Rigidbody2D>();
        anim = GameObject.Find("Dr Rizz").GetComponent<Animator>();
    }

    private void Update()
    {
        dRrb.velocity = new Vector2(dirX * move_speed, dirY * move_speed);
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
                StartCoroutine(Typewriter());
            }
        }
    }

    IEnumerator Typewriter()
    {
        dirY = -1;
        yield return new WaitForSeconds(2.5f);
        dirY = 0;

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

            yield return new WaitForSeconds(0.5f);
            text_displ.text = "";
        }

        ActivateTextDispl(false);
        rb.bodyType = RigidbodyType2D.Dynamic;
        Door.whereSpawn = "Rizzalations town";

        addTimer = true;

        dirY = 1;
        yield return new WaitForSeconds(2.5f);
        dirY = 0;
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
            state = movement_state.up;
        }
        else if (dirY < 0f)
        {
            state = movement_state.down;
        }
        else
        {
            state = movement_state.idle;
        }

        anim.SetInteger("state", (int)state);
    }
}
