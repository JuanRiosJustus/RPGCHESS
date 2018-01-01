
/// <summary>
/// Basic factory design for classes deriving from entity.
/// </summary>
public class EntityFactory
{
    /// <summary>
    /// Factory for character creation.
    /// </summary>
    public static Character BuildCharacter(string name, string classOfEntity, Relation relationOfEntity)
    {
        switch (classOfEntity.ToLower())
        {
            case "ranger": return new Character(name, Archetype.Ranger, relationOfEntity);
            case "cleric": return new Character(name, Archetype.Cleric, relationOfEntity);
            case "magician": return new Character(name, Archetype.Magician, relationOfEntity);
            case "monk": return new Character(name, Archetype.Monk, relationOfEntity);
            case "rogue": return new Character(name, Archetype.Rogue, relationOfEntity);
            case "fighter": return new Character(name, Archetype.Fighter, relationOfEntity);
            case "generic": return new Character(name, Archetype.Generic, relationOfEntity);
            default: return new Character(name, Archetype.Monster, relationOfEntity);
        }
    }
    public Creature BuildCreature(string name, string class_of_entity, Relation relation)
    {
        return null;
    }
}