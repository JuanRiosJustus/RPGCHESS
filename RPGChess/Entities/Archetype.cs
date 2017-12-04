using System.Collections.Generic;

class Archetype
{
    public static readonly Archetype ARCHER = new Archetype("Archer", 0, 0, 0, 0, 0, 0);
    public static readonly Archetype CLERIC = new Archetype("Cleric", 0, 0, 0, 0, 0, 0);
    public static readonly Archetype MAGE = new Archetype("Mage", 0, 0, 0, 0, 0, 0);
    public static readonly Archetype MONK = new Archetype("Monk", 0, 0, 0, 0, 0, 0);
    public static readonly Archetype ROGUE = new Archetype("Rogue", 0, 0, 0, 0, 0, 0);
    public static readonly Archetype WARRIOR = new Archetype("Warrior", 0, 0, 0, 0, 0, 0);
    
    public static readonly Archetype MONSTER = new Archetype("Monster", 0, 0, 0, 0, 0, 0);
    public static readonly Archetype GENERIC = new Archetype("Generic", 0, 0, 0, 0, 0, 0);

    private readonly string CLASS_TYPE;
    private readonly int BASE_MOVEMENT;
    private readonly int BASE_HEALTH;
    private readonly int BASE_REGEN;
    private readonly int BASE_RESIST;
    private readonly int BASE_DAMAGE;
    private readonly int BASE_RANGE;

    public Archetype(string class_type, int base_movement, int base_health, int base_regen, int base_resist, int base_damage, int base_range)
    {
        CLASS_TYPE = class_type;
        BASE_MOVEMENT = base_movement;
        BASE_HEALTH = base_health;
        BASE_REGEN = base_regen;
        BASE_RESIST = base_resist;
        BASE_DAMAGE = base_damage;
        BASE_RANGE = base_range;
    }

    public static IEnumerable<Archetype> Values
    {
        get
        {
            yield return ARCHER;
            yield return CLERIC;
            yield return MAGE;
            yield return MONK;
            yield return ROGUE;
            yield return WARRIOR;
            yield return MONSTER;
            yield return GENERIC;
        }
    }

    public string Type { get { return CLASS_TYPE; } }
    public int Movement { get { return BASE_MOVEMENT; } }
    public int Health { get { return BASE_HEALTH; } }
    public int Regen { get { return BASE_REGEN; } }
    public int Resist { get { return BASE_RESIST; } }
    public int Damage { get { return BASE_DAMAGE; } }
    public int Range { get { return BASE_RANGE; } }

    public override string ToString()
    {
        return "the " + CLASS_TYPE;
    }
}