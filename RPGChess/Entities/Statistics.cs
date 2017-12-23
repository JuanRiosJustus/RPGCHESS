
using System;

/// <summary>
/// Defines the stats of an entity.
/// </summary>

public class Statistics
{
    private readonly int MaxMovement;
    private int MaxMana;
    private int MaxHealth;
    private readonly int MaxRegen;
    private readonly int MaxArmor;
    private readonly int MaxDamage;
    private readonly int MaxRange;

    private readonly int CurrentMovement;
    private int CurrentMana;
    private int CurrentHealth;
    private int CurrentRegen;
    private int CurrentArmor;
    private int CurrentDamage;
    private readonly int CurrentRange;

    private int CurrentExp;
    private int CurrentExpNeededToLevel;
    private int LastGainedExp;
    

    private int CurrentLevel;
    private Archetype CurrentArchetype;
    
    public int GetMaxHealth { get { return MaxHealth; } }
    public int GetCurrentHealth { get { return CurrentHealth; } }
    public int GetCurrentRegen { get { return CurrentRegen; } }
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
        MaxMovement = arc.MOVEMENT;
        MaxMana = arc.MANA;
        MaxHealth = arc.HEALTH;
        MaxRegen = arc.REGEN;
        MaxArmor = arc.ARMOR;
        MaxDamage = arc.DAMAGE;
        MaxRange = arc.RANGE;

        CurrentMovement = arc.MOVEMENT;
        CurrentMana = 0;
        CurrentHealth = arc.HEALTH;
        CurrentRegen = arc.REGEN;
        CurrentArmor = arc.ARMOR;
        CurrentDamage = arc.DAMAGE;
        CurrentRange = arc.RANGE;

        CurrentArchetype = arc;

        CurrentExp = 0;
        CurrentLevel = 1;
        LastGainedExp = 0;
        CurrentExpNeededToLevel = 4;
    }
    /// <summary>
    /// Increases the amount of current health is applicable.
    /// </summary>
    /// <returns></returns>
    public int RegenHealth()
    {
        CurrentHealth = CurrentHealth + CurrentRegen;
        if (GetCurrentHealth > MaxHealth) { CurrentHealth = MaxHealth; }
        return CurrentRegen;
    }
    /// <summary>
    /// Increases the amount of current mana.
    /// </summary>
    /// <returns></returns>
    public bool GainMana()
    {
        if (CurrentMana < MaxMana)
        {
            CurrentMana = CurrentMana + new Random().Next(5);
            return true;
        }
        return false;
    }
    /// <summary>
    /// Decreases amount of mana.
    /// </summary>
    /// <param name="man"></param>
    /// <returns></returns>
    public int ExpendMana(int man)
    {
        CurrentMana = CurrentMana - man;
        return man;
    }
    /// <summary>
    /// Increases the amount of experience by the amount given.
    /// </summary>
    /// <param name="exp"></param>
    /// <returns></returns>
    public int GainExperience(int exp)
    {
        LastGainedExp = exp;
        CurrentExp = CurrentExp + exp;
        LevelUp();
        return exp;
    }
    /// <summary>
    /// Increases the amount of experience (default).
    /// </summary>
    public int GainExperience()
    {
        LastGainedExp = new Random().Next(CurrentLevel) + 1;
        CurrentExp = CurrentExp + LastGainedExp;
        LevelUp();
        return LastGainedExp;
    }
    /// <summary>
    /// Checks to see if can level up.
    /// </summary>
    private bool LevelUp()
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
    /// <param name="arc">archetype to respect.</param>
    private void IncreaseStatistics(Archetype arc)
    {
        string str = arc.NAME.ToLower();
        switch(str)
        {
            case "cleric": IncreaseAsCleric(); break;
            case "mage": IncreaseAsMage(); break;
            case "monk": IncreaseAsMonk(); break;
            case "ranger": IncreaseAsRanger(); break;
            case "rogue": IncreaseAsRogue(); break;
            case "warrior": IncreaseAsWarrior(); break;
            case "generic": IncreaseAsGeneric(); break;
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
        CurrentRegen = CurrentRegen + 5;
        CurrentArmor = CurrentArmor + 1 + BONUSVARIANCE();
        CurrentDamage = CurrentDamage + 5 + BONUSVARIANCE();
    }
    /// <summary>
    /// Increases stats for a mage.
    /// </summary>
    private void IncreaseAsMage()
    {
        MaxMana = MaxMana + 50;
        MaxHealth = MaxHealth + 25;

        CurrentHealth = CurrentHealth + 25;
        CurrentRegen = CurrentRegen + 1;
        CurrentArmor = CurrentArmor + 1 + BONUSVARIANCE();
        CurrentDamage = CurrentDamage + 20 + BONUSVARIANCE();
    }
    /// <summary>
    /// Increases stats for a monk
    /// </summary>
    private void IncreaseAsMonk()
    {
        MaxMana = MaxMana + 10;
        MaxHealth = MaxHealth + 50;
        
        CurrentHealth = CurrentHealth + 50;
        CurrentRegen = CurrentRegen + 3;
        CurrentArmor = CurrentArmor + 3 + BONUSVARIANCE();
        CurrentDamage = CurrentDamage + 10 + BONUSVARIANCE();
    }
    /// <summary>
    /// Increases stats for a ranger.
    /// </summary>
    private void IncreaseAsRanger()
    {
        MaxMana = MaxMana + 10;
        MaxHealth = MaxHealth + 25;

        CurrentHealth = CurrentHealth + 25;
        CurrentRegen = CurrentRegen + 1;
        CurrentArmor = CurrentArmor + 1 + BONUSVARIANCE();
        CurrentDamage = CurrentDamage + 10 + BONUSVARIANCE();
    }
    /// <summary>
    /// Increases stats for a rogue.
    /// </summary>
    private void IncreaseAsRogue()
    {
        MaxMana = MaxMana + 15;
        MaxHealth = MaxHealth + 25;

        CurrentHealth = CurrentHealth + 25;
        CurrentRegen = CurrentRegen + 1;
        CurrentArmor = CurrentArmor + 2 + BONUSVARIANCE();
        CurrentDamage = CurrentDamage + 15 + BONUSVARIANCE();
    }
    /// <summary>
    /// Increases stats for a warrior.
    /// </summary>
    private void IncreaseAsWarrior()
    {
        MaxMana = MaxMana + 5;
        MaxHealth = MaxHealth + 50;

        CurrentHealth = CurrentHealth + 50;
        CurrentRegen = CurrentRegen + 1;
        CurrentArmor = CurrentArmor + 5 + BONUSVARIANCE();
        CurrentDamage = CurrentDamage + 10 + BONUSVARIANCE();
    }
    /// <summary>
    /// Increases stats for a genric or default.
    /// </summary>
    private void IncreaseAsGeneric()
    {
        MaxMana = MaxMana + 5;
        MaxHealth = MaxHealth + 25;

        CurrentHealth = CurrentHealth + 25;
        CurrentRegen = CurrentRegen + 2;
        CurrentArmor = CurrentArmor + 2;
        CurrentDamage = CurrentDamage + 5;
    }
    /// <summary>
    /// Increases stats for a monster.
    /// </summary>
    private void IncreaseAsMonster()
    {
        Random rand = new Random();
        MaxMana = MaxMana + 50;
        MaxHealth = MaxHealth + 200;

        CurrentHealth = CurrentHealth + 200;
        CurrentRegen = CurrentRegen + 1 + rand.Next(CurrentLevel);
        CurrentArmor = CurrentArmor + 1 + rand.Next(CurrentLevel);
        CurrentDamage = CurrentDamage + 50 + rand.Next(CurrentLevel);
    }
    public int BONUSVARIANCE()
    {
        return new Random().Next(Global.VARIANCE * -1,Global.VARIANCE);
    }
}