using System;
using System.Drawing;

public class Tile
{
    /// <summary>
    /// Represents the row the tile is occupying.
    /// </summary>
    public readonly int ROW;
    /// <summary>
    /// Represents the column the tile is occupying.
    /// </summary>
    public readonly int COL;
    /// <summary>
    /// Represents the X position where the tile is drawn at on the window.
    /// </summary>
    public readonly int X;
    /// <summary>
    /// Represents the Y position where the tile is drawn at on the window.
    /// </summary>
    public readonly int Y;
    /// <summary>
    /// Represents the topological height of the tile.
    /// </summary>
    public int Height { get; private set; }
    /// <summary>
    /// Represents the type of biome the tile is.
    /// </summary>
    public string Biome { get; private set; }

    public Item Loot { get; private set; }

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
        ROW = row;
        COL = col;
        X = Global.STD * COL;
        Y = Global.STD * ROW;
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
            Biome = "WTR";
        }
        else if (Height > -3 && Height <= -1)
        {
            // Swanp
            Biome = "SWP";
        }
        else if (Height > -1 && Height <= 1)
        {
            // Plains
            Biome = "PLN";
        }
        else if (Height > 1 && Height <= 3)
        {
            // Forest
            Biome = "FRS";
        }
        else if (Height > 3 && Height <= 5)
        {
            // Hill
            Biome = "HLL";
        }
        else if (Height > 5)
        {
            // Mountain
            Biome = "MTN";
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
    /// Sets the item of the tile.
    /// </summary>
    /// <param name="loot"></param>
    public void SetLoot(Item loot)
    {
        Loot = loot;
    }
    public Item LootTile()
    {
        Item temp = Loot;
        Loot = null;
        return temp;
    }
    /// <summary>
    /// Sets the height for the tile.
    /// </summary>
    /// <param name="height">The height to repsect when adjusting the height.</param>
    public void SetHeight(int height)
    {
        Height = height;
        AdjustBiome();
        TileImage = ImageManager.DetermineBiomeImage(Biome);
    }
    /// <summary>
    /// Returns a boolean value based on the current affiliation the tile has with an entity.
    /// </summary>
    /// <returns></returns>
    public bool IsOccupied()
    {
        return (Occupant == null ? false : true);
    }
    /// <summary>
    /// Returns the string representation of the coordinate for this tile.
    /// </summary>
    /// <returns></returns>
    public string ToCoordinate()
    {
        return "[" + COL + "," + ROW + "]";
    }
    public string ToTopograph()
    {
        return "[" + Height + "]";
    }
    public string ToBiome()
    {
        return "[" + Biome + "]";
    }
    public string ToLevel()
    {
        if (Height < 0)
        {
            return "[" + "L" + "]";
        }
        else if (Height < 5)
        {
            return "[" + "M" + "]";
        }
        else
        {
            return "[" + "H" + "]";
        }
    }
    public string ToStandard()
    {
        if (IsOccupied())
        {
            return "[XXX]";
        }
        else
        {
            return ToBiome();
        }
    }
    public override string ToString()
    {
        return ToCoordinate();//Height + "";
    }
    /// <summary>
    /// Determines if this tile is equivalent to the given tile.
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public bool Equals(Tile obj)
    {
        return obj.ROW == ROW && obj.COL == COL;
    }
}