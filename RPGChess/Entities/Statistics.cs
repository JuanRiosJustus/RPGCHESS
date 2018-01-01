
using System;

/// <summary>
/// Defines the stats of an entity.
/// </summary>
public class Statistics
{
    private readonly int MaxMovement;
    private int MaxMana;
    private int MaxHealth;
    private readonly int MaxArmor;
    private readonly int MaxDamage;
    private readonly int MaxRange;

    private readonly int CurrentMovement;
    private int CurrentMana;
    private int CurrentHealth;
    private int CurrentArmor;
    private int CurrentDamage;
    private readonly int CurrentRange;

    private int CurrentExp;
    private int CurrentExpNeededToLevel;
    private int LastGainedExp;

    private int CurrentLevel;
    private Archetype CurrentArchetype;
    private Random randomNumGenerator;
    
    public int GetMaxHealth { get { return MaxHealth; } }
    public int GetCurrentHealth { get { return CurrentHealth; } }
    public int GetCurrentArmor { get { return CurrentArmor; } }
    public int GetCurrentDamage { get { return CurrentDamage; } }
    public int GetCurrentExp { get { return CurrentExp; } }
    public int GetCurrentExpNeeded { get { return CurrentExpNeededToLevel; } }
    public int GetCurrentLevel { get { return CurrentLevel; } }
    public int GetLastGainedExp { get { return LastGainedExp; } }
    public int GetCurrentMana { get { return CurrentMana; } }
    public int GetMaxMana { get { return MaxMana; } }
    public int SetCurrentHealth { set { CurrentHealth = value; } }

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="arc">Used to construct stats.</param>
    public Statistics(Archetype arc)
    {
        MaxMovement = arc.Movement;
        MaxMana = arc.Mana;
        MaxHealth = arc.Health;
        MaxArmor = arc.Armor;
        MaxDamage = arc.Damage;
        MaxRange = arc.Range;

        CurrentMovement = arc.Movement;
        CurrentMana = 0;
        CurrentHealth = arc.Health;
        CurrentArmor = arc.Armor;
        CurrentDamage = arc.Damage;
        CurrentRange = arc.Range;

        CurrentArchetype = arc;

        CurrentExp = 0;
        CurrentLevel = 1;
        LastGainedExp = 0;
        CurrentExpNeededToLevel = 4;
        randomNumGenerator = new Random(585);
    }
    /// <summary>
    /// Increases the amount of current health.
    /// </summary>
    public int GainHealth()
    {
        CurrentHealth = CurrentHealth + randomNumGenerator.Next(CurrentLevel) + 1;
        if (CurrentHealth > MaxHealth)
        {
            CurrentHealth = MaxHealth;
        }
        return CurrentHealth;
    }
    /// <summary>
    /// Increases the amount of current mana.
    /// </summary>
    public int GainMana()
    {
        CurrentMana = CurrentMana + randomNumGenerator.Next(CurrentLevel) + 1;
        if (CurrentMana > MaxMana)
        {
            CurrentMana = MaxMana;
        }
        return CurrentMana;
    }
    /// <summary>
    /// Decreases amount of current mana.
    /// </summary>
    public int ExpendMana(int man)
    {
        CurrentMana = CurrentMana - man;
        return man;
    }
    /// <summary>
    /// Increases the amount of experience by the amount given.
    /// </summary>
    public int GainExperience(int exp)
    {
        LastGainedExp = exp;
        CurrentExp = CurrentExp + exp;
        CheckForLevelUp();
        return exp;
    }
    /// <summary>
    /// Increases the amount of experience (ambient).
    /// </summary>
    public int GainExperience()
    {
        LastGainedExp = new Random().Next(CurrentLevel) + 1;
        CurrentExp = CurrentExp + LastGainedExp;
        CheckForLevelUp();
        return LastGainedExp;
    }
    /// <summary>
    /// Checks to see if can level up.
    /// </summary>
    private bool CheckForLevelUp()
    {
        // check if can level up.
        if (CurrentExp >= CurrentExpNeededToLevel)
        {
            int remainder = CurrentExp % CurrentExpNeededToLevel;
            CurrentExp = remainder + new Random().Next(CurrentLevel);
            CurrentLevel++;
            CurrentExpNeededToLevel = CurrentExpNeededToLevel * 2;
            IncreaseStatistics(CurrentArchetype);
            return true;
        }
        return false;
    }
    /// <summary>
    /// Increases stats respective of archetype.
    /// </summary>
    private void IncreaseStatistics(Archetype arc)
    {
        string str = arc.Name.ToLower();
        switch(str)
        {
            case "cleric": IncreaseAsCleric(); break;
            case "magician": IncreaseAsMagician(); break;
            case "monk": IncreaseAsMonk(); break;
            case "ranger": IncreaseAsRanger(); break;
            case "rogue": IncreaseAsRogue(); break;
            case "fighter": IncreaseAsFighter(); break;
            case "generic": IncreaseAsGeneric(); break;
            case "bystander": IncreaseAsBystander(); break;
            default: IncreaseAsMonster(); break;
        }
    }
    /// <summary>
    /// Increases stats for a cleric.
    /// </summary>
    private void IncreaseAsCleric()
    {
        MaxMana = MaxMana + 20;
        MaxHealth = MaxHealth + 50;

        CurrentHealth = CurrentHealth + 50;
        CurrentArmor = CurrentArmor + randomNumGenerator.Next(2);
        CurrentDamage = CurrentDamage + 2 + randomNumGenerator.Next(2);
    }
    /// <summary>
    /// Increases stats for a magician.
    /// </summary>
    private void IncreaseAsMagician()
    {
        MaxMana = MaxMana + 50;
        MaxHealth = MaxHealth + 25;

        CurrentHealth = CurrentHealth + 25;
        CurrentArmor = CurrentArmor + randomNumGenerator.Next(2);
        CurrentDamage = CurrentDamage + 10 + randomNumGenerator.Next(10);
    }
    /// <summary>
    /// Increases stats for a monk
    /// </summary>
    private void IncreaseAsMonk()
    {
        MaxMana = MaxMana + 10;
        MaxHealth = MaxHealth + 50;
        
        CurrentHealth = CurrentHealth + 50;
        CurrentArmor = CurrentArmor + randomNumGenerator.Next(3);
        CurrentDamage = CurrentDamage + 5 + +randomNumGenerator.Next(5);
    }
    /// <summary>
    /// Increases stats for a ranger.
    /// </summary>
    private void IncreaseAsRanger()
    {
        MaxMana = MaxMana + 10;
        MaxHealth = MaxHealth + 25;

        CurrentHealth = CurrentHealth + 25;
        CurrentArmor = CurrentArmor + randomNumGenerator.Next(2);
        CurrentDamage = CurrentDamage + 7 + randomNumGenerator.Next(7);
    }
    /// <summary>
    /// Increases stats for a rogue.
    /// </summary>
    private void IncreaseAsRogue()
    {
        MaxMana = MaxMana + 15;
        MaxHealth = MaxHealth + 25;

        CurrentHealth = CurrentHealth + 25;
        CurrentArmor = CurrentArmor + randomNumGenerator.Next(3);
        CurrentDamage = CurrentDamage + 9 + randomNumGenerator.Next(9);
    }
    /// <summary>
    /// Increases stats for a fighter.
    /// </summary>
    private void IncreaseAsFighter()
    {
        MaxMana = MaxMana + 5;
        MaxHealth = MaxHealth + 50;

        CurrentHealth = CurrentHealth + 50;
        CurrentArmor = CurrentArmor + 1 + randomNumGenerator.Next(5);
        CurrentDamage = CurrentDamage + 5 + randomNumGenerator.Next(5);
    }
    /// <summary>
    /// Increases stats for a generic or default.
    /// </summary>
    private void IncreaseAsGeneric()
    {
        MaxMana = MaxMana + 5;
        MaxHealth = MaxHealth + 25;

        CurrentHealth = CurrentHealth + 25;
        CurrentArmor = CurrentArmor + randomNumGenerator.Next(5);
        CurrentDamage = CurrentDamage + randomNumGenerator.Next(5);
    }
    /// <summary>
    /// Increases stats for a monster.
    /// </summary>
    private void IncreaseAsMonster()
    {
        MaxMana = MaxMana + 50;
        MaxHealth = MaxHealth + 200;

        CurrentHealth = CurrentHealth + 200;
        CurrentArmor = CurrentArmor + 1 + randomNumGenerator.Next(CurrentLevel);
        CurrentDamage = CurrentDamage + 25 + randomNumGenerator.Next(CurrentLevel);
    }
    /// <summary>
    /// Increases stats for a generic or default.
    /// </summary>
    private void IncreaseAsBystander()
    {
        MaxMana = MaxMana + 5;
        MaxHealth = MaxHealth + 25;

        CurrentHealth = CurrentHealth + 10;
        CurrentArmor = CurrentArmor + 1;
        CurrentDamage = CurrentDamage + 1;
    }
}