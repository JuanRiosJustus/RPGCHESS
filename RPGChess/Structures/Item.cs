using System.Collections.Generic;

public class Item
{
    public static readonly Item ARCHMAGES_STAFF = new Item("Archmage's Staff", Archetype.MAGE, 0, 0, 0, 0, 0);
    public static readonly Item ARTYOMS_TRUEBLADE = new Item("Artyom's Trueblade", Archetype.WARRIOR, 0, 0, 0, 0, 0);
    public static readonly Item AEGIS_OF_APOLLO = new Item("Aegis of Apollo", Archetype.GENERIC, 0, 0, 0, 0, 0);
    public static readonly Item SAVANTES_RING = new Item("Savante's Ring", Archetype.GENERIC, 0, 0, 0, 0, 0);

    private readonly string NAME;
    private readonly Archetype REQUIRED_CLASS;
    private readonly int MOVEMENT;
    private readonly int HEALTH;
    private readonly int RESIST;
    private readonly int DAMAGE;
    private readonly int RANGE;

    public Item(string name, Archetype required_class, int movement, int health, int resist, int damage, int range)
    {
        NAME = name;
        REQUIRED_CLASS = required_class;
        MOVEMENT = movement;
        HEALTH = health;
        RESIST = resist;
        DAMAGE = damage;
        RANGE = range;
    }

    public static IEnumerable<Item> Values
    {
        get
        {
            yield return ARCHMAGES_STAFF;
            yield return ARTYOMS_TRUEBLADE;
            yield return AEGIS_OF_APOLLO;
            yield return SAVANTES_RING;
        }
    }

    public string Name { get { return NAME; } }
    public string Type { get { return REQUIRED_CLASS.Type; } }
    public int Movement { get { return MOVEMENT; } }
    public int Health { get { return HEALTH; } }
    public int Resist { get { return RESIST; } }
    public int Damage { get { return DAMAGE; } }
    public int Range { get { return RANGE; } }

    public override string ToString()
    {
        return NAME;
    }
}