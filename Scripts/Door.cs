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
        Vector3 newPosition = new Vector3(change_scene.player_x, change_scene.player_y-5, player.position.z);
        player.position = newPosition;
        GetOutOfStart.OnStart();
        Debug.Log("Player position updated.");
        
        // Unsubscribe from the event to prevent memory leaks
        SceneManager.sceneLoaded -= OnSceneLoaded;
    } 
}
