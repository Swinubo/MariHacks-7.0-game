using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class change_scene : MonoBehaviour
{
    [SerializeField] private int sceneNum;
    private Transform player;
    public static float player_x, player_y;

    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<Transform>(); 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            player_x = player.position.x;
            player_y = player.position.y;
            SceneManager.LoadScene(sceneNum);
        }
    }
}
