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

    private Text gen_text;
    private int messageCount;
    private Animator anim;
    public static Image trans;
    public static Creature gymBoi;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
            SceneManager.LoadScene(2);
        }
    }

    private void StartInNewScene()
    {
        mainCam = GameObject.Find("Main Camera").GetComponent<Camera>();
        battleCam = GameObject.Find("Battle Camera").GetComponent<Camera>();

        gen_text = GameObject.Find("text").GetComponent<Text>();

        anim = GameObject.Find("Arm").GetComponent<Animator>();

        trans = GameObject.Find("trans BGRND").GetComponent<Image>();
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        StartInNewScene();
        updatePos();
        if (gym_leader == 0)
        {
            Change_to_battle.rizkamon = Creature.Travis;
        }
        else if (gym_leader == 1)
        {
            Change_to_battle.rizkamon = Creature.Ligma;
        }

        gymBoi =Change_to_battle.rizkamon;

        sendBattle();
        // Unsubscribe from the event to prevent memory leaks
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void updatePos()
    {
        Transform player = GameObject.Find("Player").GetComponent<Transform>();          
        Vector3 newPosition = new Vector3(change_scene.player_x, change_scene.player_y-5, player.position.z);
        player.position = newPosition;
    }

    private void sendBattle()
    {
        GameObject.Find(Change_to_battle.rizkamon.Name + "_irnl").GetComponent<SpriteRenderer>().enabled = true;
        GameObject.Find(Change_to_battle.rizkamon.Name + "_irnl").GetComponent<BoxCollider2D>().enabled = true;

        Flee.BattleActivation(mainCam, battleCam, true);

        GameObject.Find("Move1Text").GetComponent<Text>().text = Collector.currentRizkamon.Move1.Name;
        GameObject.Find("Move2Text").GetComponent<Text>().text = Collector.currentRizkamon.Move2.Name;

        Change_to_battle.inBattle = true;

        GameObject.Find(Collector.currentRizkamon.Name + "_irnly").GetComponent<SpriteRenderer>().enabled = true;

        Collector.initFoeRizkamon = new Creature(Change_to_battle.rizkamon);

    }
}
