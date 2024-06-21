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
        player = GameObject.Find("Player")?.GetComponent<Transform>();
        if (player == null)
        {
            Debug.LogError("Player object not found.");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            if (SceneManager.GetActiveScene().buildIndex == 2 && player != null)
            {
                player_x = player.position.x;
                player_y = player.position.y;
            }

            StartCoroutine(LoadSceneAsync(sceneNum));
        }
    }

    private IEnumerator LoadSceneAsync(int sceneIndex)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneIndex);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
