using System;
using System.Drawing;

public class Tile
{
    /// <summary>
    /// Represents the row the tile is occupying.
    /// </summary>
    public readonly int Row;
    /// <summary>
    /// Represents the column the tile is occupying.
    /// </summary>
    public readonly int Column;
    /// <summary>
    /// Represents the tile's point on the screen.
    /// </summary>
    public readonly Point Coordinate;
    /// <summary>
    /// Represents the topological height of the tile.
    /// </summary>
    public int Height { get; private set; }
    /// <summary>
    /// Represents the type of biome the tile is in shortest format..
    /// </summary>
    public string BiomeSHORT { get; private set; }
    /// <summary>
    /// Represents the type of biome the tile is in longest format.
    /// </summary>
    public string BiomeLONG { get; private set; }
    /// <summary>
    /// Represents the Character the tile is associated with.
    /// </summary>
    public Entity Occupant { get; private set; }
    /// <summary>
    /// The associated image of the tile.
    /// </summary>
    public Image TileImage { get; private set; }
    
    /// <summary>
    /// Contstructor for the tile.
    /// </summary>
    /// <param name="row">The row associated with the tile.</param>
    /// <param name="col">The column associated with the tile.</param>
    /// <param name="height">The topological height of the tile.</param>
    public Tile(int row, int col, int height)
    {
        Row = row;
        Column = col;
        Height = height;
        Coordinate = new Point(Global.MULTIPLIER * Column, Global.MULTIPLIER * Row);
        SetHeight(height);
    }
    /// <summary>
    /// Adjusts the Biome of the tile respective to the height.
    /// </summary>
    private void AdjustBiome()
    {
        if (Height <= -3)
        {
            // Water
            BiomeSHORT = "WTR";
            BiomeLONG = "water";
        }
        else if (Height > -3 && Height <= -1)
        {
            // Swanp
            BiomeSHORT = "SWP";
            BiomeLONG = "swamp";
        }
        else if (Height > -1 && Height <= 1)
        {
            // Plains
            BiomeSHORT = "PLN";
            BiomeLONG = "plain";
        }
        else if (Height > 1 && Height <= 3)
        {
            // Forest
            BiomeSHORT = "FRS";
            BiomeLONG = "forest";
        }
        else if (Height > 3 && Height <= 5)
        {
            // Hill
            BiomeSHORT = "HLL";
            BiomeLONG = "hill";
        }
        else if (Height > 5)
        {
            // Mountain
            BiomeSHORT = "MTN";
            BiomeLONG = "mountain";
        }
    }
    /// <summary>
    /// Sets the association with the tile and given entity with one another.
    /// </summary>
    /// <param name="occupant">The entity to be associated with the tile.</param>
    public void SetOccupant(Entity occupant)
    {
        Occupant = occupant;
        if (Object.ReferenceEquals(Occupant.TILE_OF_ENTITY, this) == false)
        {
            Occupant.SetTile(this);
        }
    }
    /// <summary>
    /// Removes the current affiliation between the tile's occupant and itself.
    /// </summary>
    public void RemoveOccupant()
    {
        Occupant = null;
    }
    /// <summary>
    /// Sets the height for the tile.
    /// </summary>
    /// <param name="height">The height to repsect when adjusting the height.</param>
    public void SetHeight(int height)
    {
        Height = height;
        AdjustBiome();
        TileImage = ImageManager.DetermineBiomeImage(BiomeLONG);
    }
    /// <summary>
    /// Returns a boolean value based on the current affiliation the tile has with an entity.
    /// </summary>
    /// <returns></returns>
    public bool IsOccupied()
    {
        return Occupant != null;
    }
    /// <summary>
    /// Returns the string representation of the coordinate for this tile.
    /// </summary>
    /// <returns></returns>
    public string ToCoordinate()
    {
        return "[" + Column + "," + Row + "]";
    }
    public string ToTopograph()
    {
        return "[" + Height + "]";
    }
    public string ToBiome()
    {
        return "[" + BiomeSHORT + "]";
    }
    /// <summary>
    /// Returns the coordinate position of the given tile.
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        return ToCoordinate();
    }
    /// <summary>
    /// Determines if this tile is equivalent to the given tile.
    /// </summary>
    /// <param name="t"></param>
    /// <returns></returns>
    public bool Equals(Tile t)
    {
        return t.Row == Row && t.Column == Column;
    }
    /// <summary>
    /// Determines if the given tile is related to the given tiles 
    /// where both should return true if done on one another.
    /// </summary>
    /// <param name="t">tile to check.</param>
    /// <returns></returns>
    public bool IsRelative(Tile t)
    {
        if (Row == t.Row + 1 || Row == t.Row || Row == t.Row - 1)
        {
            if (Column == t.Column + 1 || Column == t.Column || Column == t.Column - 1)
            {
                return true;
            }
        }
        return false;
    }
    /// <summary>
    /// returns the distance between the tile and the given tile.
    /// </summary>
    /// <param name="t">tile to get to.</param>
    /// <returns></returns>
    public int DistanceFrom(Tile t)
    {
        return (int)Math.Sqrt(((Row - t.Row) * 2) + ((Column - t.Column) * 2));
    }
}