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
        deleteSumStuff();
        if (gym_leader == 0)
        {
            Change_to_battle.rizkamon = "rizz_city_boss";
            GameObject.Find("Rizz_city_boss_irnl").GetComponent<SpriteRenderer>().enabled =true; 
            GameObject.Find("Rizz_city_boss_irnl").GetComponent<BoxCollider2D>().enabled =true; 
        }
        // Unsubscribe from the event to prevent memory leaks
        SceneManager.sceneLoaded -= OnSceneLoaded;
    } 

    private void deleteSumStuff()
    {
        GameObject.Find("Battle").GetComponent<Camera>().enabled =true; 
        GameObject.Find("Main Camera").GetComponent<Camera>().enabled =false; 
        GetOutOfStart.OnStart();
        GameObject.Find("Battle").GetComponent<AudioSource>().enabled =true; 
        GameObject.Find("Player").GetComponent<AudioSource>().enabled =false; 
        GameObject.Find("ButtonToFlee").GetComponent<Image>().enabled =true; 
        GameObject.Find("ButtonToFlee").GetComponent<Button>().enabled =true; 
        GameObject.Find("TextForFlee").GetComponent<Text>().enabled =true; 
        GameObject.Find("PressSPCBAR").GetComponent<Text>().enabled =true;
        GameObject.Find("TapToShoot").GetComponent<Button>().enabled =true;
        GameObject.Find("Right").GetComponent<Image>().enabled =false;
        GameObject.Find("Left").GetComponent<Image>().enabled =false;
        GameObject.Find("Up").GetComponent<Image>().enabled =false;
        GameObject.Find("Down").GetComponent<Image>().enabled =false;
        GameObject.Find("Shift").GetComponent<Image>().enabled =false;
        GameObject.Find("Right").GetComponent<Button>().enabled =false;
        GameObject.Find("Left").GetComponent<Button>().enabled =false;
        GameObject.Find("Up").GetComponent<Button>().enabled =false;
        GameObject.Find("Down").GetComponent<Button>().enabled =false; 
        GameObject.Find("Shift").GetComponent<Button>().enabled =false; 
    }
}
