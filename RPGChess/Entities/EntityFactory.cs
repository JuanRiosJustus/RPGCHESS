
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
    public static Character BuildCharacter(string name, string class_of_entity, Relation relation_of_entity)
    {
        switch (class_of_entity.ToLower())
        {
            case "archer": return new Character(name, Archetype.ARCHER, relation_of_entity);
            case "cleric": return new Character(name, Archetype.CLERIC, relation_of_entity);
            case "mage": return new Character(name, Archetype.MAGE, relation_of_entity);
            case "monk": return new Character(name, Archetype.MONK, relation_of_entity);
            case "rogue": return new Character(name, Archetype.ROGUE, relation_of_entity);
            case "warrior": return new Character(name, Archetype.WARRIOR, relation_of_entity);
            case "generic": return new Character(name, Archetype.GENERIC, relation_of_entity);
            default: return new Character(name, Archetype.MONSTER, relation_of_entity);
        }
    }
}