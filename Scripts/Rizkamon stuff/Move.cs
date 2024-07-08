using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    // Properties of the move
    public string Name { get; set; }
    public string Type { get; set; }
    public int Power { get; set; }
    public int Heal { get; set; }
    public float AttackEnhance { get; set; }
    public float DefenceEnhance { get; set; }

    // Moves
    public static Move Scratch;
    public static Move Shout;
    public static Move Rizz;
    public static Move Ballz;
    public static Move Watasigma;
    public static Move Drop;

    // Constructor to initialize a new Move object
    public Move(string name, string type, int power, int heal, float attackEnhance, float defenceEnhance)
    {
        Name = name;
        Type = type;
        Power = power;
        Heal = heal;
        AttackEnhance = attackEnhance;
        DefenceEnhance = defenceEnhance;
    }

    private void Start()
    {
        Scratch = new Move("Scratch", "Rizz", 5, 0, 0f, 0f);
        Shout = new Move("Shout", "Swiftie", 0, 0, 1.5f, 1.5f);
        Rizz = new Move("Rizz", "Rizz", 0, 0, 3f, 0f);
        Ballz = new Move("Ballz", "Aura", 0, 8, 0f, 0f);
        Watasigma = new Move("Watasigma", "Aura", 3, 0, 0f, 2f);
        Drop = new Move("Drop", "Swiftie", 0, 0, 0f, 5f);
    }
}
