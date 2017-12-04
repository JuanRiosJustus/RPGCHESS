using System;
using System.Drawing;

class Entity
{
    /// <summary>
    /// Represents the name of the entity.
    /// </summary>
    protected internal string NAME_OF_ENTITY;
    /// <summary>
    /// Represents the class-archetype of the entity.
    /// </summary>
    protected internal Archetype CLASS_OF_ENTITY;
    /// <summary>
    /// The tile associated with the entity.
    /// </summary>
    protected internal Tile TILE_OF_ENTITY { get; private set; }
    /// <summary>
    /// The image associated with the entiy.
    /// </summary>
    protected internal Image IMAGE_OF_ENTITY;
    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="name_of_entity">Name representing the entity.</param>
    /// <param name="class_of_entity">Class represented by this entity.</param>
    public Entity(string name_of_entity, Archetype class_of_entity)
    {
        NAME_OF_ENTITY = name_of_entity;
        CLASS_OF_ENTITY = class_of_entity;
    }
    /// <summary>
    /// Associates the entity with the given tile.
    /// </summary>
    /// <param name="tile">The tile to associate the entity with.</param>
    public virtual void SetTile(Tile tile)
    {
        this.TILE_OF_ENTITY = tile;
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
