using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cave_passing : MonoBehaviour
{
    private int normalLayer = 1;
    private int underLayer = -2;
    private SpriteRenderer playerSprite;
    [SerializeField] private PolygonCollider2D edge;

    private void Start()
    {
        playerSprite = GameObject.Find("Player").GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            playerSprite.sortingOrder = underLayer;
            edge.enabled = false;

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            playerSprite.sortingOrder = normalLayer;
            edge.enabled = true;
        }
    }
}
