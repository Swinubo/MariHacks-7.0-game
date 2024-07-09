public class Move
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
    public static Move ThunderRizz;
    public static Move AuraHeal;
    public static Move SwiftSerenade;

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
