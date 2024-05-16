using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class passing_through : MonoBehaviour
{
    private int normalLayer = 1;
    private int underLayer = -2;
    private SpriteRenderer playerSprite;

    private void Start()
    {
        playerSprite = GameObject.Find("Player").GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            playerSprite.sortingOrder = underLayer;
        }
    }

        private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            playerSprite.sortingOrder = normalLayer;
        }
    }
}