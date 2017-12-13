using System;
using System.Collections;

/// <summary>
/// 
/// Defines an instance of a character.
/// To be manipulated within the context of a <see cref="Game"/>.
/// 
/// </summary>
public class Character : Entity
{
    private int MaxMovement;
    private int MaxHealth;
    private int MaxArmor;
    private int MaxDamage;

    private int CurrentMovement;
    private int CurrentHealth;
    private int CurrentArmor;
    private int CurrentMax;
    private int CurrentDamage;
    
    private int CurrentLevel;
    private int StepsToLevel;

    private int Steps;
    private string Initials;

    private ArrayList OccuableTiles;
    private ArrayList AttackableCharacters;
    private ArrayList CollectedItems;

    /********** INITILIZATION LOGIC **********/
    /// <summary>
    /// Constructor for an instance of a Character.
    /// </summary>
    /// <param name="name_of_entity">Defines the name of the character.</param>
    /// <param name="class_of_entity">Defines the class/archetype of the character.</param>
    public Character(string name_of_entity, Archetype class_of_entity, Relation relation) : base(name_of_entity, class_of_entity)
    {
        InitializeCharacter();
        RELATION_OF_ENTITY = relation;
        IMAGE_OF_ENTITY = ImageManager.DetermineCharacterImage(CLASS_OF_ENTITY, RELATION_OF_ENTITY);
    }
    /// <summary>
    /// Initializes all of the members of a character.
    /// </summary>
    private void InitializeCharacter()
    {
        OccuableTiles = new ArrayList();
        AttackableCharacters = new ArrayList();

        MaxMovement = CLASS_OF_ENTITY.Movement;
        MaxHealth = CLASS_OF_ENTITY.Health;
        MaxArmor = CLASS_OF_ENTITY.Resist;
        MaxDamage = CLASS_OF_ENTITY.Damage;

        CurrentMovement = CLASS_OF_ENTITY.Movement;
        CurrentHealth = CLASS_OF_ENTITY.Health;
        CurrentArmor = CLASS_OF_ENTITY.Resist;
        CurrentDamage = CLASS_OF_ENTITY.Damage;

        CurrentLevel = 1;
    }

    /********** TILE LOGIC **********/
    /// <summary>
    /// Adds a tile in which this character may traverse to.
    /// </summary>
    /// <param name="tile">Tile to be added.</param>
    public void AddOccuableTile(Tile tile) { OccuableTiles.Add(tile); }
    /// <summary>
    /// Deletes a tile traversable by the character given an index.
    /// </summary>
    /// <param name="index">Index to delete.</param>
    public void DeleteOccuableTile(int index) { OccuableTiles.RemoveAt(index); }
    /// <summary>
    /// Clears all tiles traversable by the character.
    /// </summary>
    public void ClearOccuableTiles() { OccuableTiles.Clear(); }
    /// <summary>
    /// Gets the quantity of tiles traversable by the character.
    /// </summary>
    /// <returns></returns>
    public int GetOccuableTileQuantity() { return OccuableTiles.Count; }
    /// <summary>
    /// Gets a tile traversable by the character given an index.
    /// </summary>
    /// <param name="index">Index to retrieve the file from.</param>
    /// <returns></returns>
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


    /********** ATTACK LOGIC **********/
    /// <summary>
    /// Adds the given character to the list of attackable
    /// characters of the character.
    /// </summary>
    /// <param name="character">Character to be added.</param>
    public void AddAttackableCharacter(Character character) { AttackableCharacters.Add(character); }
    /// <summary>
    /// Clears the list of attackable characters of the character.
    /// </summary>
    public void ClearAttackableEntities() { AttackableCharacters.Clear(); }
    /// <summary>
    /// Gets the amount of attackable character of the character.
    /// </summary>
    /// <returns></returns>
    public int GetAttackableCharacterQuantity() { return AttackableCharacters.Count; }
    /// <summary>
    /// Gets an attaackable character of characters the character can attack.
    /// </summary>
    /// <param name="index">Index of the character.</param>
    /// <returns></returns>
    public Character GetAttackableEntity(int index) { return (Character)AttackableCharacters[index]; }


    /********** LEVELING LOGIC **********/
    private void CheckIfCanLevel()
    {
        if (Steps >= StepsToLevel)
        {
            CurrentLevel++;
            StepsToLevel = StepsToLevel * 2;
        }
    }

    /********** STRING VISUALIZATION LOGIC **********/
    private string HealtStatus() { return "[HP: " + CurrentHealth + "/" + MaxHealth + "]"; }
    private string EntityStatus() {  return "[NAME: " + NAME_OF_ENTITY + "]"; }
    private string ArcheStatus() { return "[CLS: " + CLASS_OF_ENTITY.Type + "]"; }
    private string LevelStatus() { return "[LVL: " + CurrentLevel + "]"; }
    public string Status()
    {
        return "[HEALTH: " + CurrentHealth + "/" + MaxHealth + " ][DAMAGE: " + CurrentDamage + " ][ARMOR: " + CurrentArmor + "]";
    }
    public override string ToString()
    {
        Tile t = TILE_OF_ENTITY;
        return "[Lvl: " + CurrentLevel + " ][Name: " + NAME_OF_ENTITY.ToString() + " the " + CLASS_OF_ENTITY.Type + " ][ " +  t.COL + "," + t.ROW + " ]";
    }
}