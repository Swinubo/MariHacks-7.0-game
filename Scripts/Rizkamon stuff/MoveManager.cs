using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveManager : MonoBehaviour
{
    private Camera mainCam;
    private Camera battleCam;
    private Rigidbody2D rb;
    private int moveFavoured; //if =0, move 1
    //if =1, move 2
    private void Start()
    {
        mainCam = GameObject.Find("Main Camera").GetComponent<Camera>();
        battleCam = GameObject.Find("Battle Camera").GetComponent<Camera>();

        rb = GameObject.Find("Player").GetComponent<Rigidbody2D>();

        //name, type, power, heal, attackenhance, defenceenhance
        Move.Scratch = new Move("SCRATCH", "Rizz", 5, 0, 0f, 0f);
        Move.Shout = new Move("SHOUT", "Swiftie", 0, 0, 1.5f, 1.5f);
        Move.Rizz = new Move("RIZZ", "Rizz", 0, 4, 3f, 0f);
        Move.Ballz = new Move("BALLZ", "Aura", 3, 3, 0f, 0f);
        Move.Watasigma = new Move("WATASIGMA", "Aura", 3, 0, 0f, 2f);
        Move.Drop = new Move("DROP", "Swiftie", 0, 0, 0f, 5f);
        Move.ThunderRizz = new Move("THUNDER RIZZ", "Rizz", 8, 0, 0f, 0f);
        Move.AuraHeal = new Move("AURA HEAL", "Aura", 0, 0, 8f, 5f);
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

        Debug.Log("Name of Bip: " + Creature.Bip.Name);

    }

    public void Move1Play()
    {
        movePlay(Collector.currentRizkamon.Move1);
        Debug.Log(Collector.currentRizkamon.Move1.Name);
    }

    public void Move2Play()
    {
        movePlay(Collector.currentRizkamon.Move2);
        Debug.Log(Collector.currentRizkamon.Move2.Name);
    }

    private void movePlay(Move move)
    {
        Change_to_battle.rizkamon.Health -= move.Power;
        Collector.currentRizkamon.Health += move.Heal;
        if (Change_to_battle.rizkamon.Health <= 0)
        {
            Flee.BattleActivation(mainCam, battleCam, false);
            rb.bodyType = RigidbodyType2D.Dynamic;
        }

        foePlay();
    }

    private void foePlay()
    {
        moveFavoured = Random.Range(0, 2);
        if (moveFavoured == 0)
        {
            moveFoe(Change_to_battle.rizkamon.Move1);
        }
        else if (moveFavoured == 1)
        {
            moveFoe(Change_to_battle.rizkamon.Move2);
        }
    }

    private void moveFoe(Move move)
    {
        Collector.currentRizkamon.Health -= move.Power;
        Change_to_battle.rizkamon.Health += move.Heal;

        if (Collector.currentRizkamon.Health <= 0)
        {
            Flee.BattleActivation(mainCam, battleCam, false);
            rb.bodyType = RigidbodyType2D.Dynamic;
        }
    }
}
