using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnCollideWithBullet : MonoBehaviour
{
    private Camera mainCam;
    private Camera battleCam;

    private Rigidbody2D rb;

    private CircleCollider2D ballCC2D;
    private Rigidbody2D ballRB2D;

    [SerializeField] private float speed_shot = 0.42f;

    // Amplitude of the rotation (maximum rotation angle)
    public float amplitude = 15f;
    // Speed of the oscillation
    public float speed_oscilate = 2f;
    // Axis of rotation
    public Vector3 rotationAxis = Vector3.up;
    private Quaternion initialRotation;
    private GameObject ball;
    private bool ballOscilation;

    private Animator anim;
    private GameObject emptyAnimPlace;

    void Start()
    {
        mainCam = GameObject.Find("Main Camera").GetComponent<Camera>();
        battleCam = GameObject.Find("Battle Camera").GetComponent<Camera>();

        rb = GameObject.Find("Player").GetComponent<Rigidbody2D>();

        anim = GameObject.Find("BallCatch").GetComponent<Animator>();
        emptyAnimPlace = GameObject.Find("BallCatch");

        initialRotation = transform.rotation;
    }

    void Update()
    {
        if (ballOscilation)
        {
            // Calculate the new rotation angle
            float angle = amplitude * Mathf.Sin(Time.time * speed_oscilate);
            // Create a rotation based on the angle and axis
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            // Apply the rotation while maintaining the initial rotation as the base
            ball.transform.rotation = initialRotation * rotation;
            Debug.Log("Oscilating");
        }
    }
 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            Debug.Log("Collided");
            ballCC2D = GameObject.Find(collision.gameObject.name).GetComponent<CircleCollider2D>();
            ballRB2D = GameObject.Find(collision.gameObject.name).GetComponent<Rigidbody2D>();

            ballCC2D.isTrigger = false;
            GameObject.Find(collision.gameObject.name).GetComponent<Rotate>().enabled = false;
            ballRB2D.gravityScale = 150;
            ballRB2D.velocity = new Vector2(0, 500);

            ball = GameObject.Find(collision.gameObject.name);

            ballOscilation = true;
            StartCoroutine(WaitForOscilation());
        }
    }

    IEnumerator WaitForOscilation()
    {
        yield return new WaitForSeconds(3);
        ballOscilation = false;

        Vector3 ballPos = ball.transform.position;
        Vector3 animPos = emptyAnimPlace.transform.position;

        animPos.y = ballPos.y + 200;
        animPos.x = ballPos.x;
        emptyAnimPlace.transform.position = animPos;

        anim.SetBool("IsRotating", true);
        ball.name = "";
        Debug.Log("Played");

    }

    private void AddRizkamon()
    {
        Flee.BattleActivation(mainCam, battleCam, true);
        rb.bodyType = RigidbodyType2D.Dynamic;

        foreach (var item in Collector.rizkamons)
        {
            GameObject.Find(item.name).GetComponent<SpriteRenderer>().enabled =false;
            GameObject.Find(item.name).GetComponent<BoxCollider2D>().enabled =false;
        }

        Collector.have_rizkamons.Add(Change_to_battle.rizkamon);
        Debug.Log("Added rizkamon: " + Change_to_battle.rizkamon);

        anim.SetBool("IsRotating", false);
    }
}
