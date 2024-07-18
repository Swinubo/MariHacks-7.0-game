using UnityEngine;

public class MoveManager : MonoBehaviour
{

    private void Start()
    {
        Move.Scratch = new Move("SCRATCH", "Rizz", 5, 0, 0f, 0f);
        Move.Shout = new Move("SHOUT", "Swiftie", 0, 0, 1.5f, 1.5f);
        Move.Rizz = new Move("RIZZ", "Rizz", 0, 0, 3f, 0f);
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
        Creature.AlvinJR = new Creature("Alvin JR", 30, 0.9f, 2f, Move.Watasigma, Move.AuraHeal);
        Creature.Whale = new Creature("Whale", 30, 0.9f, 2f, Move.Ballz, Move.Watasigma);

        //edge
        Creature.Bellico = new Creature("Bellico", 30, 0.9f, 2f, Move.ThunderRizz, Move.Rizz);
        Creature.Beeogee = new Creature("Joe", 30, 0.9f, 2f, Move.Scratch, Move.Scratch);
        Creature.Terroc = new Creature("Terroc", 30, 0.9f, 2f, Move.Watasigma, Move.ThunderRizz);
        Creature.Quakor = new Creature("Quakor", 30, 0.9f, 2f, Move.Ballz, Move.Scratch);
        Creature.Jo = new Creature("Jo", 30, 0.9f, 2f, Move.SwiftSerenade, Move.Rizz);

        //start
        Creature.Aurasaurus = new Creature("Aurasaurus", 30, 0.9f, 2f, Move.AuraHeal, Move.Drop);
        Creature.Anky = new Creature("Anky", 30, 0.9f, 2f, Move.SwiftSerenade, Move.Shout);
        Creature.Deviousussy = new Creature("Deviousussy", 30, 0.9f, 2f, Move.ThunderRizz, Move.Rizz);

        //gym
        Creature.Travis = new Creature("Travis", 30, 0.9f, 2f, Move.Drop, Move.Drop);
        Creature.Ligma = new Creature("Ligma", 30, 0.9f, 2f, Move.Shout, Move.Rizz);

        Debug.Log("Name of Bip: " + Creature.Bip.Name);
    }
}
