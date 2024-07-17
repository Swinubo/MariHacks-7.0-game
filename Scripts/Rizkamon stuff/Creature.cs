public class Creature
{
    //Properties of creature
    public string Name { get; set; }
    public int Health { get; set; }
    public float Attack { get; set; }
    public float Defence { get; set; }
    public Move Move1 { get; set; }
    public Move Move2 { get; set; }

    //Creatures
    public static Creature Bip;
    public static Creature Richard;
    public static Creature Punny;
    public static Creature Joe;

    public static Creature AlvinJR;
    public static Creature Whale;

    public static Creature Bellico;
    public static Creature Beeogee;
    public static Creature Quakor;
    public static Creature Terroc;
    public static Creature Jo;

    public static Creature Aurasaurus;
    public static Creature Deviousussy;
    public static Creature Anky;

    //gym
    public static Creature Travis;
    public static Creature Ligma;

    public Creature(string name, int health, float attack, float defence, Move move1, Move move2)
    {
        Name = name;
        Health = health;
        Attack = attack;
        Defence = defence;
        Move1 = move1;
        Move2 = move2;
    }

    /*public override string ToString()
    {
        return $"Creature: {Name}, Health: {Health}, Attack: {Attack}, Defence: {Defence}, Move1: {Move1.Name}, Move2: {Move2.Name}";
    }*/
}
