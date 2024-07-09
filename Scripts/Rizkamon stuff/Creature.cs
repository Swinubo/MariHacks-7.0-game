public class Creature
{
    //Properties of creature
    public string Name { get; private set; }
    public int Health { get; private set; }
    public float Attack { get; private set; }
    public float Defence { get; private set; }
    public Move Move1 { get; private set; }
    public Move Move2 { get; private set; }

    //Creatures
    public static Creature Bip;
    public static Creature Richard;
    public static Creature Punny;
    public static Creature Joe;

    /*public static Creature AlvinJR;
    public static Creature Whale;

    public static Creature AlvinJR;
    public static Creature Whale;
    public static Creature AlvinJR;
    public static Creature Whale;
    public static Creature AlvinJR;*/

    public Creature(string name, int health, float attack, float defence, Move move1, Move move2)
    {
        Name = name;
        Health = health;
        Attack = attack;
        Defence = defence;
        Move1 = move1;
        Move2 = move2;
    }

    public override string ToString()
    {
        return $"Creature: {Name}, Health: {Health}, Attack: {Attack}, Defence: {Defence}, Move1: {Move1.Name}, Move2: {Move2.Name}";
    }
}
