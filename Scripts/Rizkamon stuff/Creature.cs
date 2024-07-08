using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature : MonoBehaviour
{
    // Auto-implemented properties
    public string Name { get; set; }
    public int HP { get; set; }
    public float AttackStat { get; set; }
    public float DefenceStat { get; set; }
    public Move Move1 { get; set; }
    public Move Move2 { get; set; }

    //Creatures
    public static Creature Bip;
    public static Creature Richard;
    public static Creature Punny;
    public static Creature Joe;

    // Constructor to initialize a new Creature object
    public Creature(string name, int hp, float attackStat, float defenceStat, Move move1, Move move2)
    {
        Name = name;
        HP = hp;
        AttackStat = attackStat;
        DefenceStat = defenceStat;
        Move1 = move1;
        Move2 = move2;
    }

    private void Start()
    {
        Creature Bip = new Creature("Bip", 20, 1, 1.5f, Move.Scratch, Move.Rizz);
        Creature Richard = new Creature("Richard", 25, 1, 1f, Move.Scratch, Move.Shout);
        Creature Punny = new Creature("Punny", 12, 2, 1f, Move.Shout, Move.Ballz);
        Creature Joe = new Creature("Joe", 30, 0.9f, 2f, Move.Shout, Move.Rizz);
    }
}
