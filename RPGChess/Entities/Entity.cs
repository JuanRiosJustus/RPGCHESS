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
    protected internal Relation RELATION_OF_ENTITY;
    protected internal Point COORDINATE_OF_ENTITY;

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="name_of_entity">Name representing the entity.</param>
    /// <param name="class_of_entity">Class represented by this entity.</param>
    public Entity(string name_of_entity, Archetype class_of_entity)
    {
        if (name_of_entity.Length > 9)
        {
            NAME_OF_ENTITY = name_of_entity.Substring(0, 9);
        }
        else
        {
            NAME_OF_ENTITY = name_of_entity;
        }
        CLASS_OF_ENTITY = class_of_entity;
        COORDINATE_OF_ENTITY = new Point(0, 0);
    }
    /// <summary>
    /// Associates the entity with the given tile.
    /// </summary>
    /// <param name="tile">The tile to associate the entity with.</param>
    public virtual void SetTile(Tile tile)
    {
        this.TILE_OF_ENTITY = tile;
        this.COORDINATE_OF_ENTITY.X = tile.Coordinate.X;
        this.COORDINATE_OF_ENTITY.Y = tile.Coordinate.Y;

        if (Object.ReferenceEquals(TILE_OF_ENTITY.Occupant, this) == false)
        {
            this.TILE_OF_ENTITY.SetOccupant(this);
        }
    }
    /// <summary>
    /// Sets the relation of enttiy.
    /// </summary>
    /// <param name="relation"></param>
    public virtual void SetRelation(Relation relation)
    {
        this.RELATION_OF_ENTITY = relation;
    }
    /// <summary>
    /// Basic string representation of the entity.
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        return this.NAME_OF_ENTITY;
    }
}
