using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Event1 : MonoBehaviour
{
    private Text text_displ;
    [SerializeField] private string[] my_text;
    private Rigidbody2D rb;

    private static bool triggered = false;

    //0 = initially getting out of bed
    //1 = trying to leave the house but then mom calls

    private void Start()
    {
        text_displ = GameObject.Find("text").GetComponent<Text>(); 
        rb = GameObject.Find("Player").GetComponent<Rigidbody2D>();
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

    }

    private void ActivateTextDispl(bool OnOrOff)
    {
        text_displ.text = "";
        GameObject.Find("text").GetComponent<Text>().enabled =OnOrOff; 
        GameObject.Find("General_text").GetComponent<Image>().enabled =OnOrOff; 
        GameObject.Find("General_text").GetComponent<Button>().enabled =OnOrOff; 
    }
}
