using System.Collections.Generic;

/// <summary>
/// 
/// Defines the different available archetypes.
/// Some of these archetypes include: Cleric, Monk, and Mage.
/// <see cref="Character"/> should reflect attributes of an <see cref="Archetype"/>.
/// 
/// </summary>
public class Archetype
{
    public static readonly Archetype ARCHER = new Archetype("Archer", 2, 100, 1, 1, 15, 4);
    public static readonly Archetype CLERIC = new Archetype("Cleric", 1, 100, 3, 1, 10, 3);
    public static readonly Archetype MAGE = new Archetype("Mage", 1, 100, 1, 1, 40, 3);
    public static readonly Archetype MONK = new Archetype("Monk", 5, 100, 2, 1, 15, 2);
    public static readonly Archetype ROGUE = new Archetype("Rogue", 3, 100, 1, 1, 30, 2);
    public static readonly Archetype WARRIOR = new Archetype("Warrior", 3, 100, 1, 10, 20, 1);
    
    public static readonly Archetype MONSTER = new Archetype("Monster", 1, 50, 1, 0, 0, 2);
    public static readonly Archetype GENERIC = new Archetype("Generic", 1, 50, 1, 0, 0, 2);
    
    private readonly string CLASS_TYPE;
    private readonly int BASE_MOVEMENT;
    private readonly int BASE_HEALTH;
    private readonly int BASE_REGEN;
    private readonly int BASE_ARMOR;
    private readonly int BASE_DAMAGE;
    private readonly int BASE_RANGE;

    /// <summary>
    /// Constructs an instance of an Archetype.
    /// </summary>
    /// <param name="class_type">The string representation of the class/archetype</param>
    /// <param name="base_movement">The base movement of the instance.</param>
    /// <param name="base_health">The base health of the instance.</param>
    /// <param name="base_regen">The base health regen of the instance.</param>
    /// <param name="base_resist">The base armor of the instance.</param>
    /// <param name="base_damage">The base damage of the instance.</param>
    /// <param name="base_range">The base range of the instance.</param>
    public Archetype(string class_type, int base_movement, int base_health, int base_regen, int base_armor, int base_damage, int base_range)
    {
        CLASS_TYPE = class_type;
        BASE_MOVEMENT = base_movement;
        BASE_HEALTH = base_health;
        BASE_REGEN = base_regen;
        BASE_ARMOR = base_armor;
        BASE_DAMAGE = base_damage;
        BASE_RANGE = base_range;
    }
    /// <summary>
    /// Offers an iterable collection of the Archetypes.
    /// </summary>
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
    /// <summary>
    /// Returns the type of the archetype represented by a string.
    /// </summary>
    public string Type { get { return CLASS_TYPE; } }
    /// <summary>
    /// Returns the movement of the archetype represented by an integer.
    /// </summary>
    public int Movement { get { return BASE_MOVEMENT; } }
    /// <summary>
    /// Returns health of the archetype represented by an integer.
    /// </summary>
    public int Health { get { return BASE_HEALTH; } }
    /// <summary>
    /// Returns the regeneration of the archetype represented by an integer.
    /// </summary>
    public int Regen { get { return BASE_REGEN; } }
    /// <summary>
    /// Returns the resistance of the archetype represented by an integer.
    /// </summary>
    public int Resist { get { return BASE_ARMOR; } }
    /// <summary>
    /// Returns the damage of the archetype represented by an integer.
    /// </summary>
    public int Damage { get { return BASE_DAMAGE; } }
    /// <summary>
    /// Returns the range of the archetype represented by an integer.
    /// </summary>
    public int Range { get { return BASE_RANGE; } }
    /// <summary>
    /// The basic representation of the Archetype. 
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        return "the " + CLASS_TYPE;
    }
}