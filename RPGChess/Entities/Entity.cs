using System;
using System.Drawing;

/// <summary>
/// Defines the most basic form of an occupant.
/// </summary>
public class Entity
{
    protected internal readonly string NameOfEntity;
    protected internal readonly Archetype ClassOfEntity;
    protected internal Tile TileOfEntity { get; private set; }
    protected internal Image ImageOfEntity;
    protected internal Relation RelationOfEntity;

    /// <summary>
    /// Constructor for Entity instance.
    /// </summary>
    public Entity(string nameOfEntity, Archetype classOfEntity)
    {
        if (nameOfEntity.Length > 9) { NameOfEntity = nameOfEntity.Substring(0, 9); }
        else { NameOfEntity = nameOfEntity; }
        ClassOfEntity = classOfEntity;
    }
    /// <summary>
    /// Associates the entity with the given tile.
    /// </summary>
    public virtual void SetTile(Tile tile)
    {
        this.TileOfEntity = tile;

        if (Object.ReferenceEquals(TileOfEntity.Occupant, this) == false)
        {
            this.TileOfEntity.SetOccupant(this);
        }
    }
    /// <summary>
    /// Sets the relation of entity.
    /// </summary>
    public virtual void SetRelation(Relation relation)
    {
        this.RelationOfEntity = relation;
    }
    /// <summary>
    /// Basic string representation of the entity.
    /// </summary>
    public override string ToString()
    {
        return this.NameOfEntity;
    }
}
