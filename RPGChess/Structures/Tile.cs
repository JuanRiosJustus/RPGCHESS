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
        Coordinate = new Point(Global.TileSize * Column, Global.TileSize * Row);
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
            BiomeSHORT = "DWTR";
            BiomeLONG = "deepwater";
        }
        else if (Height > -3 && Height <= -1)
        {
            // Swanp
            BiomeSHORT = "SWTR";
            BiomeLONG = "shallowwater";
        }
        else if (Height > -1 && Height <= 1)
        {
            // Plains
            BiomeSHORT = "SAND";
            BiomeLONG = "sand";
        }
        else if (Height > 1 && Height <= 4)
        {
            // Forest
            BiomeSHORT = "FRST";
            BiomeLONG = "forest";
        }
        else if (Height > 4 && Height <= 6)
        {
            // Hill
            BiomeSHORT = "HILL";
            BiomeLONG = "hill";
        }
        else
        {
            // Mountain
            BiomeSHORT = "MOTN";
            BiomeLONG = "mountain";
        }
    }
    /// <summary>
    /// Sets the association with the tile and given entity with one another.
    /// </summary>
    public void SetOccupant(Entity occupant)
    {
        Occupant = occupant;
        if (Object.ReferenceEquals(Occupant.TileOfEntity, this) == false)
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
    public void SetHeight(int height)
    {
        Height = height;
        AdjustBiome();
        TileImage = ImageManager.DetermineBiomeImage(BiomeLONG);
    }
    /// <summary>
    /// Returns a boolean value based on value of the current occupant.
    /// </summary>
    public bool IsOccupied()
    {
        return Occupant != null;
    }
    /// <summary>
    /// Returns the string representation of the coordinate for this tile.
    /// </summary>
    public string ToPosition()
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
    public override string ToString()
    {
        return ToPosition();
    }
    /// <summary>
    /// Determines if this tile is equivalent to the given tile.
    /// </summary>=
    public bool Equals(Tile t)
    {
        return t.Row == Row && t.Column == Column;
    }
    /// <summary>
    /// Determines if the given tile is related to the given tiles 
    /// where both should return true if done on one another.
    /// </summary>
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
    public int DistanceFrom(Tile t)
    {
        return (int)Math.Sqrt(((Row - t.Row) * 2) + ((Column - t.Column) * 2));
    }
}