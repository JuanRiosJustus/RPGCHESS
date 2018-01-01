/// <summary>
/// Defines an Character.
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
        RelationOfEntity = relation;
        ImageOfEntity = ImageManager.DetermineCharacterImage(ClassOfEntity, relation);

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
        Stats.ExpendMana(ClassOfEntity.Ultimate.Mana);
    }
    /// <summary>
    /// Increases the amount of current health.
    /// </summary>
    /// <returns></returns>
    public int RegenHealth()
    {
        return Stats.GainHealth();
    }
    /// <summary>
    /// Returns the Level of the character.
    /// </summary>
    public int Level { get{ return Stats.GetCurrentLevel; } }
    /// <summary>
    /// Returns the last amount of experience gained by the character.
    /// </summary>
    public int ExpGained { get { return Stats.GetLastGainedExp; } }
    /// <summary>
    /// Returns the current amount of mana of the chrarcter.
    /// </summary>
    public int Mana { get { return Stats.GetCurrentMana; } }
    /// <summary>
    /// Returns the current damage of the character.
    /// </summary>
    public int Damage { get { return Stats.GetCurrentDamage; } }
    /// <summary>
    /// Returns the current armor of the character.
    /// </summary>
    public int Armor { get { return Stats.GetCurrentArmor; } }
    /// <summary>
    /// Returns the current amount of health of the character.
    /// </summary>
    public int Health { get { return Stats.GetCurrentHealth; } }
    /// <summary>
    /// Sets the current health of the character with respect to the damage taken
    /// </summary>
    public int TakeDamage
    {
        set
        {
            int damageDone = value;
            if (damageDone > 0)
            {
                Stats.SetCurrentHealth = Stats.GetCurrentHealth - value;
                if (Stats.GetCurrentHealth > Stats.GetMaxHealth)
                {
                    Stats.SetCurrentHealth = Stats.GetMaxHealth;
                }
            }
            else
            {
                Stats.SetCurrentHealth = Stats.GetCurrentHealth - 1;
                if (Stats.GetCurrentHealth > Stats.GetMaxHealth)
                {
                    Stats.SetCurrentHealth = Stats.GetMaxHealth;
                }
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
        if (TileOfEntity == null) { return ""; }
        Tile t = TileOfEntity;
        return "[TILE: " + t.ToPosition() + " ] " +
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
            "[NME: " + NameOfEntity + " (" + ClassOfEntity.Name + ") ]" + 
            "[HP: " + Stats.GetCurrentHealth + " / " + Stats.GetMaxHealth + " ]";
    }
    public string SelectedView()
    {
        return "[LVL: " + Stats.GetCurrentLevel + " ]" + 
            "[NME: " + NameOfEntity + " ] " +
            "[EXP: " + Stats.GetCurrentExp + "/" + Stats.GetCurrentExpNeeded + " ]" +
            "[MAN: " + Stats.GetCurrentMana + "/" + Stats.GetMaxMana + " ]";
    }
    public string NameEmphasized()
    {
        return "[ " + NameOfEntity + " ]";
    }
    public override string ToString()
    {
        return NameOfEntity;
    }
}