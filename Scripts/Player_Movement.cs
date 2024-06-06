using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    public static Animator anim;
    public static float dirX = 0;
    public static float dirY = 0;
    private SpriteRenderer sprite;
    public static float move_speed = 200f;
    public static float init_speed = 200f;
    public static float speed_increase = 350f;
    public static float skate_increase = 900f;
    //[SerializeField] private AudioSource jumpSoundEffect;

    private enum movement_state { idle, running, running_up, running_down, toBattle, skating }
    public static bool use_buttons = true;
    public static bool playToBattle = false;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (!use_buttons)
        {
            dirX = Input.GetAxisRaw("Horizontal");
            dirY = Input.GetAxisRaw("Vertical");     
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                move_speed += speed_increase;
            }
            else if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                move_speed -= speed_increase;
            }
        }
        rb.velocity = new Vector2(dirX * move_speed, dirY * move_speed);
        update_animations();
    }

    private void update_animations()
    {

        movement_state state;

        if (dirX > 0f)
        {
            state = movement_state.running;
            sprite.flipX = true;
        }
        else if (dirX < 0f)
        {
            state = movement_state.running;
            sprite.flipX = false;
        }
        else if (dirY > 0f)
        {
            state = movement_state.running_up;
        }
        else if (dirY < 0f)
        {
            state = movement_state.running_down;
        }
        else
        {
            state = movement_state.idle;
        }
        if (Skates.in_ice)
        {
            state = movement_state.skating;
        }
        if (playToBattle)
        {
            state = movement_state.toBattle;
        }

        anim.SetInteger("state", (int)state);
    }
}
