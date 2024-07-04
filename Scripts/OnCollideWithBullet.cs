using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnCollideWithBullet : MonoBehaviour
{
    private Camera mainCam;
    private Camera battleCam;

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
    public static GameObject ball;
    private bool ballOscilation;

    private Animator anim;
    private GameObject emptyAnimPlace;

    void Start()
    {
        mainCam = GameObject.Find("Main Camera").GetComponent<Camera>();
        battleCam = GameObject.Find("Battle Camera").GetComponent<Camera>();

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
        if (ball != null)
        {
            Vector3 ballPos = ball.transform.position;
            Vector3 animPos = emptyAnimPlace.transform.position;

            animPos.y = ballPos.y + 200;
            animPos.x = ballPos.x;
            emptyAnimPlace.transform.position = animPos;
        }
    }
 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            Debug.Log("Collided");

            StartCoroutine(WaitForOscilation(collision));
        }
    }

    IEnumerator WaitForOscilation(Collider2D collision)
    {
        ballCC2D = GameObject.Find(collision.gameObject.name).GetComponent<CircleCollider2D>();
        ballRB2D = GameObject.Find(collision.gameObject.name).GetComponent<Rigidbody2D>();

        ballCC2D.isTrigger = false;
        GameObject.Find(collision.gameObject.name).GetComponent<Rotate>().enabled = false;
        ballRB2D.gravityScale = 150;
        ballRB2D.velocity = new Vector2(0, 500);

        ball = GameObject.Find(collision.gameObject.name);

        ballOscilation = true;
        yield return new WaitForSeconds(3);
        ballOscilation = false;

        anim.SetBool("IsFlickering", true);

    }


}
