/// <summary>
/// Defines an instance of a character.
/// To be manipulated within the context of a <see cref="Game"/>.
/// </summary>
public class Character : Entity
{
    private readonly Statistics Stats;
    
    /********** INITILIZATION LOGIC **********/
    /// <summary>
    /// Constructor for an instance of a Character.
    /// </summary>
    /// <param name="name_of_entity">Defines the name of the character.</param>
    /// <param name="class_of_entity">Defines the class/archetype of the character.</param>
    /// <param name="relation">Defines the relation of this entity.</param>
    public Character(string name_of_entity, Archetype class_of_entity, Relation relation) : base(name_of_entity, class_of_entity)
    {
        RELATION_OF_ENTITY = relation;
        IMAGE_OF_ENTITY = ImageManager.DetermineCharacterImage(CLASS_OF_ENTITY, RELATION_OF_ENTITY);

        Stats = new Statistics(class_of_entity);
    }

    /********** TILE LOGIC **********/
    /// <summary>
    /// Sets the tile of the character.
    /// </summary>
    /// <param name="tile">tile to change to.</param>
    public override void SetTile(Tile tile)
    {
        base.SetTile(tile);
        Stats.GainExperience();
        Stats.GainMana();
    }
    /*********** STATS LOGIC AND GETTERS **********/
    /// <summary>
    /// Increases the experience of the character.
    /// </summary>
    /// <param name="exp">exp to be gained.</param>
    public void GainExp(int exp)
    {
        Stats.GainExperience(exp);
    }
    /// <summary>
    /// Increases the amount of mana of the character.
    /// </summary>
    public void GainMana()
    {
        Stats.GainMana();
    }
    /// <summary>
    /// Lowers the amount of mana based onthe use of an ultimate.
    /// </summary>
    public void ExpendManaForUltimate()
    {
        Stats.ExpendMana(CLASS_OF_ENTITY.ULTIMATE.MANA);
    }
    /// <summary>
    /// Increases the amount of current health.
    /// </summary>
    /// <returns></returns>
    public int RegenHealth()
    {
        return Stats.RegenHealth();
    }
    /// <summary>
    /// Returns the current level of the character.
    /// </summary>
    public int LEVEL { get{ return Stats.GetCurrentLevel; } }
    /// <summary>
    /// Returns the last amount of experience gained by the character.
    /// </summary>
    public int EXPGAINED { get { return Stats.GetLastGainedExp; } }
    /// <summary>
    /// Returns the current amount of mana crom the chrarcter.
    /// </summary>
    public int MANA { get { return Stats.GetCurrentMana; } }
    /// <summary>
    /// Returns the current damage of the character.
    /// </summary>
    public int DAMAGE { get { return Stats.GetCurrentDamage; } }
    /// <summary>
    /// Returns the current armor of the character.
    /// </summary>
    public int ARMOR { get { return Stats.GetCurrentArmor; } }
    /// <summary>
    /// Returns the current amount of health of the character.
    /// </summary>
    public int HEALTH { get { return Stats.GetCurrentHealth; } }
    /// <summary>
    /// Sets the current health of the character with respect to the damage taken
    /// </summary>
    public int TAKEDAMAGE
    {
        set
        {
            Stats.SetCurrentHealth =  Stats.GetCurrentHealth - value;
            if (Stats.GetCurrentHealth > Stats.GetMaxHealth)
            {
                Stats.SetCurrentHealth = Stats.GetMaxHealth;
            }
        }
    }
    /// <summary>
    /// Returns true if and only if the characterhas no remaining health.
    /// </summary>
    /// <returns></returns>
    public bool IsDead()
    {
        return Stats.GetCurrentHealth <= 0;
    }


    /********** STRING VISUALIZATION LOGIC **********/
    public string TileView()
    {
        if (TILE_OF_ENTITY == null) { return ""; }
        Tile t = TILE_OF_ENTITY;
        return "[TILE: " + t.ToCoordinate() + " ] " +
                "[BIOME: " + t.ToBiome() + " ] " +
                "[TOPO: " + t.ToTopograph() + " ] ";
    }
    public string StatusView()
    {
        return "[LVL: " + Stats.GetCurrentLevel + " ] " +
               "[HP: " + Stats.GetCurrentHealth + "/" + Stats.GetMaxHealth + " ] " + 
               "[DMG: " + Stats.GetCurrentDamage + " ] [ARM: " + Stats.GetCurrentArmor + "]";
    }
    public string TeamView()
    {
        return "[LVL: " + Stats.GetCurrentLevel + " ]" + 
            "[NME: " + NAME_OF_ENTITY + " the " + CLASS_OF_ENTITY.NAME + " ]" + 
            "[HP: " + Stats.GetCurrentHealth + " / " + Stats.GetMaxHealth + " ]";
    }
    public string SelectedView()
    {
        return "[LVL: " + Stats.GetCurrentLevel + " ]" + 
            "[NME: " + NAME_OF_ENTITY + " ] " +
            "[EXP: " + Stats.GetCurrentExp + "/" + Stats.GetCurrentExpNeeded + " ]" +
            "[MAN: " + Stats.GetCurrentMana + "/" + Stats.GetMaxMana + " ]";
    }
    public override string ToString()
    {
        return NAME_OF_ENTITY;
    }
}