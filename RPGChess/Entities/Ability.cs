using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Ability
{
    public static readonly Ability BASICATTACK = new Ability("Basic Attack", Archetype.GENERIC, Relation.Foe, 0, 1);
    public static readonly Ability HEAL = new Ability("Heal", Archetype.CLERIC, Relation.Friend, 50, 20);
    public static readonly Ability COSMICFIRE = new Ability("Cosmic Fire", Archetype.MAGE, Relation.Foe, 100, 40);
    public static readonly Ability PULSEPALM = new Ability("Pulse Palm", Archetype.MONK, Relation.Foe, 25, 25);
    public static readonly Ability SNIPE = new Ability("Snipe", Archetype.RANGER, Relation.Foe, 50, 20);
    public static readonly Ability CLOAK = new Ability("Cloak", Archetype.ROGUE, Relation.Friend, 50, 0);
    public static readonly Ability BOLSTER = new Ability("Bolster", Archetype.WARRIOR, Relation.Friend, 50, 0);
    
    private readonly string ABILITY_NAME;
    private readonly Archetype ASSOCIATED_ARCHETYPE;
    private readonly Relation RELATION_TO_TARGET;
    private readonly int NEEDED_MANA;
    private readonly int BASE_POTENCY;

    /// <summary>
    /// Returns the name of the ability represented by a string.
    /// </summary>
    public string NAME { get { return ABILITY_NAME; } }
    /// <summary>
    /// Returns the relation of the target the ability is to be used on.
    /// </summary>
    public Relation RELATIONTOTARGET { get { return RELATION_TO_TARGET; } }
    /// <summary>
    /// Returns the amount of mana needed to use the ability.
    /// </summary>
    public int MANA { get { return NEEDED_MANA; } }
    /// <summary>
    /// Returns the potency of the ability.
    /// </summary>
    public int POTENCY { get { return BASE_POTENCY; } }

    /// <summary>
    /// Constructor for an ability.
    /// </summary>
    /// <param name="ability_name">Name of the ability.</param>
    /// <param name="associated_archetype">archetype associated with ability.</param>
    /// <param name="relation_to_target">abilities relation to its target.</param>
    /// <param name="needed_mana">amount of mana needed to use the ability.</param>
    /// <param name="base_potency">potency of the ability.</param>
    public Ability(string ability_name, Archetype associated_archetype, Relation relation_to_target, int needed_mana, int base_potency)
    {
        ABILITY_NAME = ability_name;
        ASSOCIATED_ARCHETYPE = associated_archetype;
        RELATION_TO_TARGET = relation_to_target;
        NEEDED_MANA = needed_mana;
        BASE_POTENCY = base_potency;
    }
    /// <summary>
    /// retrieves the abilit for the given archetype.
    /// </summary>
    /// <param name="archetype">archetype to look up.</param>
    /// <returns></returns>
    public static Ability GetUniqueAbility(Archetype arc)
    {
        string str = arc.NAME.ToLower();
        switch(str)
        {
            case "cleric": return HEAL;
            case "mage": return COSMICFIRE;
            case "monk": return PULSEPALM;
            case "ranger": return SNIPE;
            case "cloak": return CLOAK;
            case "bolster": return BOLSTER;
            default: return BASICATTACK;
        }
    }
    /// <summary>
    /// Offers an iterable collection of the Archetypes.
    /// </summary>
    public static IEnumerable<Ability> Values
    {
        get
        {
            yield return BASICATTACK;
            yield return HEAL;
            yield return COSMICFIRE;
            yield return PULSEPALM;
            yield return SNIPE;
            yield return CLOAK;
            yield return BOLSTER;
        }
    }
}