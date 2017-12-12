using System;
using System.Drawing;

/// <summary>
/// 
/// Defines the most basic form of a tile occupant.
/// 
/// </summary>
public class Entity
{
    /// <summary>
    /// Represents the name of the entity.
    /// </summary>
    protected internal readonly string NAME_OF_ENTITY;
    /// <summary>
    /// Represents the class-archetype of the entity.
    /// </summary>
    protected internal readonly Archetype CLASS_OF_ENTITY;
    /// <summary>
    /// The tile associated with the entity.
    /// </summary>
    protected internal Tile TILE_OF_ENTITY { get; private set; }
    /// <summary>
    /// The image associated with the entiy.
    /// </summary>
    protected internal Image IMAGE_OF_ENTITY;
    /// <summary>
    /// Represents if the entity is friendly or an enemy.
    /// </summary>
    protected internal readonly Relation RELATION_OF_ENTITY;
    /// <summary>
    /// Represents the x coordinate of the entity.
    /// </summary>
    protected internal int ScreenPositionX;
    /// <summary>
    /// Represents the y coordinate of the entity.
    /// </summary>
    protected internal int ScreenPositionY;

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="name_of_entity">Name representing the entity.</param>
    /// <param name="class_of_entity">Class represented by this entity.</param>
    public Entity(string name_of_entity, Archetype class_of_entity, Relation relation_of_enttiy)
    {
        NAME_OF_ENTITY = name_of_entity;
        CLASS_OF_ENTITY = class_of_entity;
        RELATION_OF_ENTITY = relation_of_enttiy;
    }
    /// <summary>
    /// Associates the entity with the given tile.
    /// </summary>
    /// <param name="tile">The tile to associate the entity with.</param>
    public virtual void SetTile(Tile tile)
    {
        this.TILE_OF_ENTITY = tile;
        this.ScreenPositionX = tile.COL + 15;
        this.ScreenPositionY = tile.ROW + 15;

        if (Object.ReferenceEquals(TILE_OF_ENTITY.Occupant, this) == false)
        {
            TILE_OF_ENTITY.SetOccupant(this);
        }
    }
    /// <summary>
    /// Basic string representation of the entity.
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        return NAME_OF_ENTITY + " the " + CLASS_OF_ENTITY.ToString();
    }
}
