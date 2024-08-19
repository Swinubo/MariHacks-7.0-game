using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Event3 : MonoBehaviour
{
    private static bool triggered = false;

    private Text text_displ;
    [SerializeField] private string[] my_text;
    [SerializeField] private int when_move;
    [SerializeField] private GameObject[] skibidis;
    [SerializeField] private GameObject myEvent;
    private Rigidbody2D rb;
    private int currentText = 0;

    [SerializeField] private GameObject NPC;

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
                Destroy(NPC);
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
            currentText += 1;
            yield return new WaitForSeconds(0.5f);
            text_displ.text = "";

            if (currentText == when_move)
            {
                activateSkibidi(true);
                ActivateTextDispl(true);
            }
        }

        ActivateTextDispl(false);
        rb.bodyType = RigidbodyType2D.Dynamic;
        yield return new WaitForSeconds(3.5f);
        activateSkibidi(false);
        youDied(true);
        yield return new WaitForSeconds(5f);
        youDied(false);
        Destroy(myEvent);
        displ_location.location_str = "Rizzalations town";
        SceneManager.LoadScene(9);
    }

    private void ActivateTextDispl(bool OnOrOff)
    {
        text_displ.text = "";
        GameObject.Find("text").GetComponent<Text>().enabled =OnOrOff; 
        GameObject.Find("General_text").GetComponent<Image>().enabled =OnOrOff; 
        GameObject.Find("General_text").GetComponent<Button>().enabled =OnOrOff; 
    }

    private void activateSkibidi(bool OnOrOff)
    {
        foreach(GameObject skibidi in skibidis)
        {
            skibidi.GetComponent<WayPointFollower>().enabled = OnOrOff;
            skibidi.GetComponent<BoxCollider2D>().enabled = OnOrOff;
            skibidi.GetComponent<SpriteRenderer>().enabled = OnOrOff;
        }
    }

    private void youDied(bool OnOrOff)
    {
        GameObject.Find("you died").GetComponent<Image>().enabled = OnOrOff;
        GameObject.Find("you died text").GetComponent<Text>().enabled = OnOrOff;
    }
}
