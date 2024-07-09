using UnityEngine;

public class MoveManager : MonoBehaviour
{

    private void Start()
    {
        Move.Scratch = new Move("SCRATCH", "Rizz", 5, 0, 0f, 0f);
        Move.Shout = new Move("SHOUT", "Swiftie", 0, 0, 1.5f, 1.5f);
        Move.Rizz = new Move("RIZZ", "Rizz", 0, 0, 3f, 0f);
        Move.Ballz = new Move("BALLZ", "Aura", 0, 8, 0f, 0f);
        Move.Watasigma = new Move("WATASIGMA", "Aura", 3, 0, 0f, 2f);
        Move.Drop = new Move("DROP", "Swiftie", 0, 0, 0f, 5f);

        Creature.Bip = new Creature("Bip", 20, 1, 1.5f, Move.Scratch, Move.Rizz);
        Creature.Richard = new Creature("Richard", 25, 1, 1f, Move.Scratch, Move.Shout);
        Creature.Punny = new Creature("Punny", 12, 2, 1f, Move.Shout, Move.Ballz);
        Creature.Joe = new Creature("Joe", 30, 0.9f, 2f, Move.Shout, Move.Rizz);

        Debug.Log(Creature.Bip);
    }
}
