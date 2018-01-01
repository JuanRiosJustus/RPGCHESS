using System.Collections.Generic;

/// <summary>
/// Defines the available archetypes for an entity.
/// </summary>
public class Archetype
{
    /// <summary>
    /// The Fighter archetype, associated with High health and armor.
    /// </summary>
    public static readonly Archetype Fighter = new Archetype("Fighter", 2, 100, 30, 1, 10, 12);
    /// <summary>
    /// The Magician archetype, associated with ranged, high damage.
    /// </summary>
    public static readonly Archetype Magician = new Archetype("Magician", 1, 60, 50, 3, 5, 20);
    /// <summary>
    /// The Ranger archetype, associated with high damage from afar.
    /// </summary>
    public static readonly Archetype Ranger = new Archetype("Ranger", 1, 60, 50, 4, 5, 12);
    /// <summary>
    /// The Cleric archetype, associated with restoration and ranged damage,
    /// </summary>
    public static readonly Archetype Cleric = new Archetype("Cleric", 1, 60, 50, 2, 5, 8);
    /// <summary>
    /// The Monk archetype, associated close range along with agility.
    /// </summary>
    public static readonly Archetype Monk = new Archetype("Monk", 3, 80, 40, 1, 7, 10);
    /// <summary>
    /// The Rogue archetype, assoiated with close range and high damage.
    /// </summary>
    public static readonly Archetype Rogue = new Archetype("Rogue", 2, 80, 40, 1, 7, 18);
    /// <summary>
    /// The Generic archetype, default.
    /// </summary>
    public static readonly Archetype Generic = new Archetype("Generic", 1, 100, 50, 2, 10, 5);
    /// <summary>
    /// Default archetype for comp...
    /// </summary>
    public static readonly Archetype Bystander = new Archetype("Bystander", 1, 50, 10, 1, 1, 1);
    /// <summary>
    /// The Monster archetype, asociate with large stats, for large enemies
    /// </summary>
    public static readonly Archetype Monster = new Archetype("Monster", 1, 200, 10, 5, 15, 30);

    private readonly string BaseName;
    private readonly int BaseMovement;
    private readonly int BaseHealth;
    private readonly int BaseMana;
    private readonly int BaseRange;
    private readonly int BaseArmor;
    private readonly int BaseDamage;
    private readonly Ability BaseAbility;
    
    /// <summary>
    /// Constructor for Archetype instance.
    /// </summary>
    public Archetype(string name, int movement, int health, int mana, int range, int armor, int damage)
    {
        BaseName = name;
        BaseMovement = movement;
        BaseHealth = health;
        BaseMana = mana;
        BaseArmor = armor;
        BaseDamage = damage;
        BaseRange = range;
        BaseAbility= Ability.GetUniqueAbility(this);
    }
    /// <summary>
    /// Offers an iterable collection of the archetypes.
    /// </summary>
    public static IEnumerable<Archetype> Values
    {
        get
        {
            yield return Fighter;
            yield return Magician;
            yield return Ranger;
            yield return Cleric;
            yield return Monk;
            yield return Rogue;
            yield return Generic;
            yield return Bystander;
            yield return Monster;
        }
    }
    /// <summary>
    /// Returns the name of the archetype.
    /// </summary>
    public string Name { get { return BaseName; } }
    /// <summary>
    /// Returns the movement of the archetype.
    /// </summary>
    public int Movement { get { return BaseMovement; } }
    /// <summary>
    /// Returns the health of the archetype.
    /// </summary>
    public int Health { get { return BaseHealth; } }
    /// <summary>
    /// Returns the mana of the archetype.
    /// </summary>
    public int Mana { get { return BaseMana; } }
    /// <summary>
    /// Returns the armor of the archetype.
    /// </summary>
    public int Armor { get { return BaseArmor; } }
    /// <summary>
    /// Retunrnst the damage of the archetype.
    /// </summary>
    public int Damage { get { return BaseDamage; } }
    /// <summary>
    /// Returns the range of the archetype.
    /// </summary>
    public int Range { get { return BaseRange; } }
    /// <summary>
    /// Returns the ability associated witht he archetype.
    /// </summary>
    public Ability Ultimate { get { return BaseAbility; } }
    /// <summary>
    /// Returns the name of the archetype.
    /// </summary>
    public override string ToString()
    {
        return BaseName;
    }
}