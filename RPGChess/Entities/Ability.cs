using System.Collections.Generic;

/// <summary>
/// The specialized ability of an archetype.
/// </summary>
public class Ability
{
    public static readonly Ability BasicAttack = new Ability("Basic Attack", Archetype.Generic, Relation.Foe, 0);
    public static readonly Ability Heal = new Ability("Heal", Archetype.Cleric, Relation.Friend, 20);
    public static readonly Ability Rend = new Ability("Rend", Archetype.Magician, Relation.Foe, 40);
    public static readonly Ability Flux = new Ability("Flux", Archetype.Monk, Relation.Foe, 60);
    public static readonly Ability Barrage = new Ability("Barrage", Archetype.Ranger, Relation.Foe, 40);
    public static readonly Ability Execute = new Ability("Execute", Archetype.Rogue, Relation.Foe, 40);
    public static readonly Ability Slam = new Ability("Slam", Archetype.Fighter, Relation.Friend, 40);
    
    private readonly string AbilityName;
    private readonly Archetype RelatedArchetype;
    private readonly Relation RelationToTarget;
    private readonly int ManaUsage;
    
    public string Name { get { return AbilityName; } }
    public Relation RelationToTheTarget { get { return RelationToTarget; } }
    public int Mana { get { return ManaUsage; } }

    /// <summary>
    /// Constructor for an ability.
    /// </summary>
    public Ability(string abilityName, Archetype associatedArchetype, Relation relationToTarget, int manaNeeded)
    {
        AbilityName = abilityName;
        RelatedArchetype = associatedArchetype;
        RelationToTarget = relationToTarget;
        ManaUsage = manaNeeded;
    }
    /// <summary>
    /// Returns the ability of the given archetype.
    /// </summary>
    public static Ability GetUniqueAbility(Archetype arc)
    {
        string str = arc.Name.ToLower();
        switch(str)
        {
            case "cleric": return Heal;
            case "magician": return Rend;
            case "monk": return Flux;
            case "ranger": return Barrage;
            case "rogue": return Execute;
            case "fighter": return Slam;
            default: return BasicAttack;
        }
    }
    /// <summary>
    /// Offers an iterable collection of the Archetypes.
    /// </summary>
    public static IEnumerable<Ability> Values
    {
        get
        {
            yield return BasicAttack;
            yield return Heal;
            yield return Rend;
            yield return Flux;
            yield return Barrage;
            yield return Execute;
            yield return Slam;
        }
    }
}