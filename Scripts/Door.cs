using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public static string whereSpawn;
    private Transform player;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
            SceneManager.LoadScene(2);
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        player = GameObject.Find("Player").GetComponent<Transform>();
        Transform rizzSpawn = GameObject.Find("SpawnPos Rizz").GetComponent<Transform>();
        Transform gyattSpawn = GameObject.Find("SpawnPos Gyatt").GetComponent<Transform>();
        Transform skibidiSpawn = GameObject.Find("SpawnPos Skibidi").GetComponent<Transform>();
        Transform rizzalationsSpawn = GameObject.Find("SpawnPos Rizzalations").GetComponent<Transform>();

        if (whereSpawn == "Sky-bidi forest")
        {
            updatePos(skibidiSpawn);
        }
        else if (whereSpawn == "Rizzalations town")
        {
            updatePos(rizzalationsSpawn);
        }
        else if (whereSpawn == "Rizz city")
        {
            updatePos(rizzSpawn);
        }
        else if (whereSpawn == "Gyatt city")
        {
            updatePos(gyattSpawn);
        }
        else
        {
            player.position = new Vector3(change_scene.player_x, change_scene.player_y - 5, player.position.z);
        }

        GetOutOfStart.OnStart();
        Debug.Log("Player position updated.");

        // Unsubscribe from the event to prevent memory leaks
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void updatePos(Transform Spawn)
    {
        player.position = new Vector3(Spawn.position.x, Spawn.position.y, Spawn.position.z);
        whereSpawn = null;
    }
}
