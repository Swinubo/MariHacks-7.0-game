using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skates : MonoBehaviour
{
    private Transform player;
    private bool in_ice = false;
    public static float player_x, player_y;

    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<Transform>(); 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collision!");
        if (collision.gameObject.name == "Player")
        Debug.Log("Collision with player!");
        {
            if (get_skates.have_skates)
            {
                Player_Movement.move_speed = Player_Movement.move_speed + Player_Movement.skate_increase;
                in_ice = true;
            }
            else
            {
                Vector3 newPosition = player.position;
                newPosition.y += 50;
                player.position = newPosition;
                Debug.Log("Inside else!");
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {   
            if (in_ice)
            {
                Player_Movement.move_speed = Player_Movement.move_speed - Player_Movement.skate_increase;
                in_ice = false;
            }
        }
    }

    private void Update()
    {
        Debug.Log(get_skates.have_skates);
    }
}
