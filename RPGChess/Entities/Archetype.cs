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
    public static readonly Archetype CLERIC = new Archetype("Cleric", 1, 120, 100, 5, 5, 15, 3);
    public static readonly Archetype MAGE = new Archetype("Mage", 1, 100, 150, 1, 5, 40, 3);
    public static readonly Archetype MONK = new Archetype("Monk", 4, 120, 110, 1, 7, 15, 1);
    public static readonly Archetype RANGER = new Archetype("Ranger", 2, 100, 100, 1, 5, 15, 4);
    public static readonly Archetype ROGUE = new Archetype("Rogue", 2, 100, 100, 1, 7, 30, 1);
    public static readonly Archetype WARRIOR = new Archetype("Warrior", 3, 150, 100, 1, 10, 20, 1);
    
    public static readonly Archetype MONSTER = new Archetype("Monster", 1, 200, 100, 5, 20, 30, 3);
    public static readonly Archetype GENERIC = new Archetype("Generic", 1, 50, 50, 1, 0, 0, 2);
    public static readonly Archetype BYSTANDER = new Archetype("Bystander", 1, 50, 50, 1, 0, 0, 2);

    /// <summary>
    /// Represents the name of the class.
    /// </summary>
    private readonly string CLASS_NAME;
    /// <summary>
    /// Represents the base value of tiles that can be traversed.
    /// </summary>
    private readonly int BASE_MOVEMENT;
    /// <summary>
    /// Represents the base  total amount of health.
    /// </summary>
    private readonly int BASE_HEALTH;
    /// <summary>
    /// Represents the base total amount of mana.
    /// </summary>
    private readonly int BASE_MANA;
    /// <summary>
    /// Represents the base amount of health that will can be regenerated.
    /// </summary>
    private readonly int BASE_REGEN;
    /// <summary>
    /// Represents the base total mount of damage that will be mitigated.
    /// </summary>
    private readonly int BASE_ARMOR;
    /// <summary>
    /// Represents the base amount of damage being done.
    /// </summary>
    private readonly int BASE_DAMAGE;
    /// <summary>
    /// Represents the base range of the archetype.
    /// </summary>
    private readonly int BASE_RANGE;
    /// <summary>
    /// The unique ability of the archtype.
    /// </summary>
    private readonly Ability BASE_ABILITY;
    
    
    /// <summary>
    /// Constructs an instance of an Archetype.
    /// </summary>
    /// <param name="class_name">The string representation of the class/archetype</param>
    /// <param name="base_movement">The base movement of the instance.</param>
    /// <param name="base_health">The base health of the instance.</param>
    /// <param name="base_mana">The base mana of the instance.</param>
    /// <param name="base_regen">The base health regen of the instance.</param>
    /// <param name="base_armor">The base armor of the instance.</param>
    /// <param name="base_damage">The base damage of the instance.</param>
    /// <param name="base_range">The base range of the instance.</param>
    public Archetype(string class_name, int base_movement, int base_health, int base_mana, int base_regen, int base_armor, int base_damage, int base_range)
    {
        CLASS_NAME = class_name;
        BASE_MOVEMENT = base_movement;
        BASE_HEALTH = base_health;
        BASE_MANA = base_mana;
        BASE_REGEN = base_regen;
        BASE_ARMOR = base_armor;
        BASE_DAMAGE = base_damage;
        BASE_RANGE = base_range;
        BASE_ABILITY= Ability.GetUniqueAbility(this);
    }
    /// <summary>
    /// Offers an iterable collection of the Archetypes.
    /// </summary>
    public static IEnumerable<Archetype> Values
    {
        get
        {
            yield return CLERIC;
            yield return MAGE;
            yield return MONK;
            yield return RANGER;
            yield return ROGUE;
            yield return WARRIOR;
            yield return MONSTER;
            yield return GENERIC;
            yield return BYSTANDER;
        }
    }
    /// <summary>
    /// Returns the type of the archetype represented by a string.
    /// </summary>
    public string NAME { get { return CLASS_NAME; } }
    /// <summary>
    /// Returns the movement of the archetype represented by an integer.
    /// </summary>
    public int MOVEMENT { get { return BASE_MOVEMENT; } }
    /// <summary>
    /// Returns health of the archetype represented by an integer.
    /// </summary>
    public int HEALTH { get { return BASE_HEALTH; } }
    /// <summary>
    /// Returns the mana of the archetype represented by an integer.
    /// </summary>
    public int MANA { get { return BASE_MANA; } }
    /// <summary>
    /// Returns the regeneration of the archetype represented by an integer.
    /// </summary>
    public int REGEN { get { return BASE_REGEN; } }
    /// <summary>
    /// Returns the resistance of the archetype represented by an integer.
    /// </summary>
    public int ARMOR { get { return BASE_ARMOR; } }
    /// <summary>
    /// Returns the damage of the archetype represented by an integer.
    /// </summary>
    public int DAMAGE { get { return BASE_DAMAGE; } }
    /// <summary>
    /// Returns the range of the archetype represented by an integer.
    /// </summary>
    public int RANGE { get { return BASE_RANGE; } }
    /// <summary>
    /// Returns the ability of the archetype.
    /// </summary>
    public Ability ULTIMATE { get { return BASE_ABILITY; } }
    /// <summary>
    /// The basic representation of the Archetype. 
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        return CLASS_NAME;
    }
}