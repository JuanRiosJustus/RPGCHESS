using System;
using System.Collections;

class Character : Entity
{
    private int MaxMovement;
    private int MaxHealth;
    private int MaxResist;
    private int MaxDamage;

    private int CurrentMovement;
    private int CurrentHealth;
    private int CurrentResist;
    private int CurrentMax;



    private int CurrentLevel;
    private int StepsToLevel;

    private int Steps;
    private string Initials;
    
    /// <summary>
    /// Represents the list of tiles available to the character.
    /// </summary>
    private ArrayList OccuableTiles;
    /// <summary>
    /// Represents the list of attackable characters available to the character.
    /// </summary>
    private ArrayList AttackableEntities;
    private ArrayList CollectedItems;

    /// <summary>
    /// Constructor for the character object.
    /// </summary>
    /// <param name="name_of_entity"></param>
    /// <param name="class_of_entity"></param>
    public Character(string name_of_entity, Archetype class_of_entity) : base(name_of_entity, class_of_entity)
    {
        OccuableTiles = new ArrayList();
        
        CalculateBaseStats();
        CurrentLevel = 1;

        IMAGE_OF_ENTITY = ImageManager.DetermineCharacterImage(CLASS_OF_ENTITY);
    }
    private void CalculateBaseStats()
    {
        MaxMovement = CLASS_OF_ENTITY.Movement;
        MaxHealth = CLASS_OF_ENTITY.Health;
        MaxResist = CLASS_OF_ENTITY.Resist;
        MaxDamage = CLASS_OF_ENTITY.Damage;
    }
    public void AddOccuableTile(Tile tile) { OccuableTiles.Add(tile); }
    public void ClearOccuableTiles() { OccuableTiles.Clear(); }
    public int GetOccuableTileQuantity() { return OccuableTiles.Count; }
    public Tile GetOccuableTile(int index) { return (Tile)OccuableTiles[index]; }

    /// <summary>
    /// Returns a string format of available tiles from this character.
    /// </summary>
    /// <returns></returns>
    public string OccuableTilesToString()
    {
        string list = "";
        for (int i = 0; i < OccuableTiles.Count; i++)
        {
            list = list + (Tile)OccuableTiles[i];
        }
        return list;
    }

    public void AddAttackableEntity(Character entity) { AttackableEntities.Add(entity); }
    public void ClearAttackableEntities() { AttackableEntities.Clear(); }
    public int GetAttackableEntityQuantity() { return AttackableEntities.Count; }
    public Character GetAttackableEntity(int index) { return (Character)AttackableEntities[index]; }

    public void CheckIfCanLevel()
    {
        if (Steps >= StepsToLevel)
        {
            CurrentLevel++;
            StepsToLevel = StepsToLevel * 2;
        }
    }

    private string HealtStatus() { return "[HP: " + CurrentHealth + "/" + MaxHealth + "]"; }
    private string EntityStatus() {  return "[NAME: " + NAME_OF_ENTITY + "]"; }
    private string ArcheStatus() { return "[CLS: " + CLASS_OF_ENTITY.Type + "]"; }
    private string LevelStatus() { return "[LVL: " + CurrentLevel + "]"; }
    public string Status()
    {
        return LevelStatus() + EntityStatus() + "\t\t" + HealtStatus() + ArcheStatus(); 
    }
    public override string ToString()
    {
        return "[N:" + NAME_OF_ENTITY.ToString() + "][L:" + CurrentLevel + "][C:" + CLASS_OF_ENTITY.Type + "]";
    }
}