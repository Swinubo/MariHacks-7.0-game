using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//script is to be attached to the Player
public class Timer : MonoBehaviour
{
    private Text timerText;
    private Transform pos;
    [SerializeField] private GameObject timer;
    private static int time = 600;
    private bool timerAdded = false;
    private GameObject canvas;
    [SerializeField] private Vector3 timerPosition;
    [SerializeField] private GameObject explosion;
    [SerializeField] private GameObject youDied;
    [SerializeField] private Vector3 deathPosition;
    private static Rigidbody2D rb;

    private void Start()
    {
        //references to gameobjects 
        pos = GameObject.Find("Names").GetComponent<Transform>();
        canvas = GameObject.Find("Canvas");
        timerText = timer.GetComponent<Text>();
        rb = GameObject.Find("Player").GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        //adding the timer to the scene when the variable addTimer is set to true
        //timerAdded is there to make sure the timer only gets added to the scene once and not infinitely 
        //(since the statement that adds the timer is inside the update call which runs infinitely throughout the game)
        if (Event4.addTimer && !timerAdded)
        {
            timerAdded = true;
            GameObject instantiatedTimer = Instantiate(timer, timerPosition, Quaternion.identity, canvas.transform);
            timerText = instantiatedTimer.GetComponent<Text>();  // Update the reference to the instantiated timer's Text component

            //starts the timer    
            StartCoroutine(Clock());
        }       
    }

    IEnumerator Clock()
    {
        while (time > 0)  // To ensure the countdown continues
        {
            time -= 1;
            timerText.text = time.ToString();
            yield return new WaitForSeconds(1f);
        }        StartCoroutine(liveOrDie("die", transform));
    }

    IEnumerator liveOrDie(string liveOrDie, Transform playerPos)
    {
        rb.bodyType = RigidbodyType2D.Static;
        Instantiate(explosion, playerPos.position, Quaternion.identity);
        yield return new WaitForSeconds(1f);
        GameObject youDiedText = Instantiate(youDied, deathPosition, Quaternion.identity, canvas.transform);
        GameObject.Find("you died text").GetComponent<Text>().text = "you " + liveOrDie + " lol";
        yield return new WaitForSeconds(10f);
        SceneManager.LoadScene(1);
    }
}
