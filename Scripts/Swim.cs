using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swim : MonoBehaviour
{
    private Transform player;
    public static bool in_water = false;
    public static float player_x, player_y;
    private PolygonCollider2D[] colliders;

    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<Transform>(); 
        colliders = GetComponentsInChildren<PolygonCollider2D>();

        if (get_swim.have_swim)
        {
            // Iterate through each PolygonCollider2D and set isTrigger to true
            foreach (PolygonCollider2D collider in colliders)
            {
                collider.isTrigger = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collision!");
        if (collision.gameObject.name == "Player")
        Debug.Log("Collision with player!");
        {
            if (get_swim.have_swim)
            {
                Player_Movement.move_speed = Player_Movement.move_speed + Player_Movement.swim_decrease;
                in_water = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {   
            if (in_water)
            {
                Player_Movement.move_speed = Player_Movement.move_speed - Player_Movement.swim_decrease;
                in_water = false;
            }
        }
    }
}
