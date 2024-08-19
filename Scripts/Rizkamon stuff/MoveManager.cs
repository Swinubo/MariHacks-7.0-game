using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MoveManager : MonoBehaviour
{
    private Camera mainCam;
    private Camera battleCam;
    private Rigidbody2D rb;
    private int moveFavoured; //if =0, move 1
    //if =1, move 2
    private Text attackStatus;
    public static Slider mySlider;
    public static Slider foeSlider;
    private void Start()
    {
        mainCam = GameObject.Find("Main Camera").GetComponent<Camera>();
        battleCam = GameObject.Find("Battle Camera").GetComponent<Camera>();

        rb = GameObject.Find("Player").GetComponent<Rigidbody2D>();

        attackStatus = GameObject.Find("Attack status").GetComponent<Text>();

        mySlider = GameObject.Find("My HP").GetComponent<Slider>();
        foeSlider = GameObject.Find("Foe HP").GetComponent<Slider>();

        //name, type, power, heal, attackenhance, defenceenhance
        Move.Scratch = new Move("SCRATCH", "Rizz", 5, 0, 0f, 0f);
        Move.Shout = new Move("SHOUT", "Swiftie", 0, 0, 1.5f, 1.5f);
        Move.Rizz = new Move("RIZZ", "Rizz", 0, 4, 3f, 0f);
        Move.Ballz = new Move("BALLZ", "Aura", 3, 3, 0f, 0f);
        Move.Watasigma = new Move("WATASIGMA", "Aura", 3, 0, 0f, 2f);
        Move.Drop = new Move("DROP", "Swiftie", 0, 0, 0f, 5f);
        Move.ThunderRizz = new Move("THUNDER RIZZ", "Rizz", 8, 0, 0f, 0f);
        Move.AuraHeal = new Move("AURA HEAL", "Aura", 0, 8, 8f, 5f);
        Move.SwiftSerenade = new Move("SWIFT SERENADE", "Swiftie", 1, 2, 1.5f, 1.5f);

        //skybidi
        Creature.Bip = new Creature("Bip", 20, 1, 1.5f, Move.Scratch, Move.Rizz);
        Creature.Richard = new Creature("Richard", 25, 1, 1f, Move.Scratch, Move.Shout);
        Creature.Punny = new Creature("Punny", 12, 2, 1f, Move.Shout, Move.Ballz);
        Creature.Joe = new Creature("Joe", 30, 0.9f, 2f, Move.Shout, Move.Rizz);

        //rizz
        Creature.AlvinJR = new Creature("AlvinJR", 28, 1, 2f, Move.Watasigma, Move.AuraHeal); // Slightly lower health, moderate speed
        Creature.Whale = new Creature("Whale", 35, 0.8f, 2f, Move.Ballz, Move.Watasigma); // Higher health, slower speed

        //edge
        Creature.Bellico = new Creature("Bellico", 27, 1.1f, 2.2f, Move.ThunderRizz, Move.Rizz); // Slightly lower health, faster speed
        Creature.Beeogee = new Creature("Beeogee", 22, 1.2f, 1.8f, Move.Scratch, Move.Scratch); // Moderate health, fast speed
        Creature.Terroc = new Creature("Terroc", 30, 0.9f, 2.5f, Move.Watasigma, Move.ThunderRizz); // Balanced health, moderate speed
        Creature.Quakor = new Creature("Quakor", 25, 1, 1.5f, Move.Ballz, Move.Scratch); // Moderate health and speed
        Creature.Jo = new Creature("Jo", 30, 0.95f, 2.3f, Move.SwiftSerenade, Move.Rizz); // Balanced health, moderate speed

        //start
        Creature.Aurasaurus = new Creature("Aurasaurus", 35, 0.85f, 2.5f, Move.AuraHeal, Move.Drop); // Higher health, slower speed
        Creature.Anky = new Creature("Anky", 26, 1.1f, 1.8f, Move.SwiftSerenade, Move.Shout); // Moderate health, faster speed
        Creature.Deviousussy = new Creature("Deviousussy", 28, 1.05f, 2.2f, Move.ThunderRizz, Move.Rizz); // Slightly lower health, moderate speed

        //gym
        Creature.Travis = new Creature("Travis", 33, 0.9f, 2.5f, Move.Drop, Move.Drop); // Balanced health, moderate speed
        Creature.Ligma = new Creature("Ligma", 29, 1, 2f, Move.Shout, Move.Rizz); // Moderate health and speed
    }

    public void Move1Play()
    {
        movePlay(Collector.currentRizkamon.Move1);
    }

    public void Move2Play()
    {
        movePlay(Collector.currentRizkamon.Move2);
    }

    private void movePlay(Move move)
    {
        Change_to_battle.rizkamon.Health -= move.Power;
        Collector.currentRizkamon.Health += move.Heal;

        updateSliders();

        if (Change_to_battle.rizkamon.Health <= 0)
        {   
            checkGym();
            /*attackStatus.text = "You won!";
            yield return new WaitForSeconds(2f);*/
            Flee.BattleActivation(mainCam, battleCam, false);
            rb.bodyType = RigidbodyType2D.Dynamic;
        }

        StartCoroutine(foePlay());
    }

    IEnumerator foePlay()
    {
        Change_to_battle.trans.raycastTarget = true;
        yield return new WaitForSeconds(3f);
        
        moveFavoured = Random.Range(0, 2);
        if (moveFavoured == 0)
        {
            StartCoroutine(moveFoe(Change_to_battle.rizkamon.Move1));
        }
        else if (moveFavoured == 1)
        {
            StartCoroutine(moveFoe(Change_to_battle.rizkamon.Move2));
        }
    }

    IEnumerator moveFoe(Move move)
    {
        attackStatus.enabled = true;
        attackStatus.text = "Opponent used " + move.Name + "!";
        yield return new WaitForSeconds(2f);
        Change_to_battle.trans.raycastTarget = false;
        attackStatus.enabled = false;

        Collector.currentRizkamon.Health -= move.Power;
        Change_to_battle.rizkamon.Health += move.Heal;

        updateSliders();

        if (Collector.currentRizkamon.Health <= 0)
        {
            attackStatus.enabled = true;
            attackStatus.text = "You died!";
            yield return new WaitForSeconds(2f);
            attackStatus.enabled = false;
            //Flee.BattleActivation(mainCam, battleCam, false);
            //rb.bodyType = RigidbodyType2D.Dynamic;  

            StartCoroutine(LoadRizzCenter());
        }
    }

    private IEnumerator LoadRizzCenter()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(6);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

    private void updateSliders()
    {
        mySlider.value = (float) Collector.currentRizkamon.Health / (float) Collector.initcurrentRizkamon.Health;
        foeSlider.value = (float)Change_to_battle.rizkamon.Health / (float)Collector.initFoeRizkamon.Health;
    }

    private void checkGym()
    {
        //checks if it is a win vs a gym pokemon
        if (send_to_gym_boss.gymBoi != null)
        {
            if (send_to_gym_boss.gymBoi == Creature.Travis)
            {
                Destroy(GameObject.Find("NPC_Gartner asi asi asi gana madrid siuuuu"));
                Collector.have_gymRizkamons.Add(Creature.Travis);
            }
            else if (send_to_gym_boss.gymBoi == Creature.Ligma)
            {
                Collector.have_gymRizkamons.Add(Creature.Ligma);
            }
            send_to_gym_boss.gymBoi = null;
        }
    }
}
