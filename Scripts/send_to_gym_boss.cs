using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class send_to_gym_boss : MonoBehaviour
{   
    private Camera mainCam;
    private Camera battleCam;
    [SerializeField] private int gym_leader;
    //0 = Rizz city gym leader
    //1 = Gyatt city gym leader

    private Image TapToShoot;

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
        deleteSumStuff();
        if (gym_leader == 0)
        {
            Change_to_battle.rizkamon = "travis";
            GameObject.Find("Travis_irnl").GetComponent<SpriteRenderer>().enabled =true; 
            GameObject.Find("Travis_irnl").GetComponent<BoxCollider2D>().enabled =true; 
        }
        else if (gym_leader == 1)
        {
            Change_to_battle.rizkamon = "ligma";
            GameObject.Find("Ligma_irnl").GetComponent<SpriteRenderer>().enabled =true; 
            GameObject.Find("Ligma_irnl").GetComponent<BoxCollider2D>().enabled =true; 
        }
        // Unsubscribe from the event to prevent memory leaks
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void deleteSumStuff()
    {
        Transform player = GameObject.Find("Player").GetComponent<Transform>();          
        Vector3 newPosition = new Vector3(change_scene.player_x, change_scene.player_y-5, player.position.z);
        player.position = newPosition;
        GameObject.Find("Battle").GetComponent<Camera>().enabled =true; 
        GameObject.Find("Main Camera").GetComponent<Camera>().enabled =false; 
        GetOutOfStart.OnStart();
        GameObject.Find("Battle").GetComponent<AudioSource>().enabled =true; 
        GameObject.Find("Player").GetComponent<AudioSource>().enabled =false; 
        GameObject.Find("ButtonToFlee").GetComponent<Image>().enabled =true; 
        GameObject.Find("ButtonToFlee").GetComponent<Button>().enabled =true; 
        GameObject.Find("TextForFlee").GetComponent<Text>().enabled =true; 
        GameObject.Find("PressSPCBAR").GetComponent<Text>().enabled =true;
        TapToShoot = GameObject.Find("TapToShoot").GetComponent<Image>();
        TapToShoot.raycastTarget = true;
    }
}
