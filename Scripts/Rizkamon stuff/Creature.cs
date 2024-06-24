using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature : MonoBehaviour
{
    // Auto-implemented properties
    public string Name { get; set; }
    public int HP { get; set; }
    public int AttackStat { get; set; }
    public int DefenceStat { get; set; }
    public Move Move { get; set; }


    // Constructor to initialize a new Move object
    public Creature(string name, int hp, int attackStat, int defenceStat, Move move)
    {
        Name = name;
        HP = hp;
        Heal = heal;
        AttackEnhance = attackEnhance;
        DefenceEnhance = defenceEnhance;
        Move = move;
    }

}