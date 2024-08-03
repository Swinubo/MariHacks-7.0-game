using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
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
        Transform player = GameObject.Find("Player").GetComponent<Transform>();
        Transform rizzSpawn = GameObject.Find("SpawnPos Rizz").GetComponent<Transform>();
        Transform gyattSpawn = GameObject.Find("SpawnPos Gyatt").GetComponent<Transform>();

        if (displ_location.city_str == "Rizz city" || displ_location.city_str == null)
        {
            player.position = new Vector3(rizzSpawn.position.x, rizzSpawn.position.y, rizzSpawn.position.z);
        }
        else if (displ_location.city_str == "Gyatt city")
        {
            player.position = new Vector3(gyattSpawn.position.x, gyattSpawn.position.y, gyattSpawn.position.z);
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
}
