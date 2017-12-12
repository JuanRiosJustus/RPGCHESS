
/// <summary>
/// 
/// Basic factory design for classes deriving from entity.
/// 
/// </summary>
public class EntityFactory
{
    /// <summary>
    /// Factory for character creation.
    /// </summary>
    /// <param name="name">Name of the character to be created.</param>
    /// <param name="class_of_entity">Class of the character to be created.</param>
    /// <returns></returns>
    public static Character BuildCharacter(string name, string class_of_entity, Relation relation)
    {
        switch (class_of_entity.ToLower())
        {
            case "archer": return new Character(name, Archetype.ARCHER);
            case "cleric": return new Character(name, Archetype.CLERIC);
            case "mage": return new Character(name, Archetype.MAGE);
            case "monk": return new Character(name, Archetype.MONK);
            case "rogue": return new Character(name, Archetype.ROGUE);
            case "warrior": return new Character(name, Archetype.WARRIOR);
            case "generic": return new Character(name, Archetype.GENERIC);
            default: return new Character(name, Archetype.MONSTER);
        }
    }
}