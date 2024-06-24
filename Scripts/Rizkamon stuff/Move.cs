using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move
{
    // Properties of the move
    public string Name { get; set; }
    public string Type { get; set; }
    public int Power { get; set; }
    public int Heal { get; set; }
    public float AttackEnhance { get; set; }
    public float DefenceEnhance { get; set; }
    

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
}

public class Creature
{
    // Auto-implemented properties
    public string Name { get; set; }
    public int HP { get; set; }
    public int attackStat { get; set; }
    public int defenceStat { get; set; }

    // Constructor to initialize a new Move object
    public Creature(string name, int hp, int attackStat, int defenceStat)
    {
        Name = name;
        HP = hp;
        Power = power;
        Heal = heal;
        AttackEnhance = attackEnhance;
        DefenceEnhance = defenceEnhance;
    }

}
