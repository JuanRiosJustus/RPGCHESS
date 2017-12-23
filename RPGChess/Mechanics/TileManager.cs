using System;
using System.Collections.Generic;

public class TileManager
{
    protected TileManager()
    {
        // constructor
    }
    
    /// <summary>
    /// Given the movement, counts the available spaces to be traversed.
    /// </summary>
    /// <param name="movement">move of movement</param>
    /// <param name="count">iteration.</param>
    /// <returns></returns>
    private static int AvailableSteps(int movement, int count)
    {
        if (movement == 1)
        {
            return 9;
        }
        else
        {
            return AvailableSteps(movement - 1, ++count) + 8 * count--;
        }
    }
    /// <summary>
    /// Determines the denied steps for cases with one bounded side for their movement.
    /// </summary>
    /// <param name="movement">move of movement.</param>
    /// <param name="count">iteration</param>
    /// <returns></returns>
    public static int DeniedSteps(int movement, int count)
    {
        if (movement == 1)
        {
            return 3;
        }
        else
        {
            return DeniedSteps(movement - 1, count + 1) + 7 + (4 * (count - 1));
        }
    }
    /// <summary>
    /// Returns a tile based on a given string from the game.
    /// </summary>
    /// <param name="game">The game to get the tile rom.</param>
    /// <param name="str">The string to parse/related to the tile.</param>
    /// <returns></returns>
    public Tile ConvertStringToTile(Game game, string str)
    {
        throw new NotImplementedException("YOU NEED TO USE THIS YOU NOOB");
        bool isFormated = str.StartsWith("[") && str.Contains(",") && str.EndsWith("]");

        if (isFormated)
        {
            str = str.Substring(1, str.Length - 2).Replace(",", " ");

            int firstNum = Int32.Parse(str.Substring(0, str.IndexOf(" ")));

            int secondNum = Int32.Parse(str.Substring(str.IndexOf(" ")));

            return game.GetBoardTile(secondNum, firstNum);
        }
        throw new Exception("PARSING ERROR: NULL TILE.");
    }
    /// <summary>
    /// Returns the list of targetable entities of the given entity, based of the given map.
    /// </summary>
    /// <param name="map">map to check.</param>
    /// <param name="ent">entity to check for.</param>
    /// <returns></returns>
    public static List<Entity> TargetableEntities(Tile[,] map, Entity ent)
    {
        List<Entity> targetableEntities = new List<Entity>();
        
        int range = ent.CLASS_OF_ENTITY.RANGE;
        Tile currentTile = ent.TILE_OF_ENTITY;

        for (int row = currentTile.Row - range; row <= currentTile.Row + range; row++)
        {
            for (int col = currentTile.Column - range; col <= currentTile.Column + range; col++)
            {
                // check if in bounds.
                if (col < 0 || row < 0 || col > Global.Columns-1 || row > Global.Rows-1)
                {
                    continue;
                }
                Tile t = map[row, col];

                if (t.IsOccupied() == false)
                {
                    continue;
                }
                if(IsInHeight(currentTile, t) == false)
                {
                    continue;
                }

                Character c = (Character)t.Occupant;
                targetableEntities.Add(c);
            }
        }
        return targetableEntities;
    }
    /// <summary>
    /// Returns occuable tiles for an entity.
    /// </summary>
    /// <param name="map">mpa to locate tiles from.</param>
    /// <param name="ent">Entity to find tiles for</param>
    /// <returns></returns>
    public static List<Tile> GetOccuableTiles(Tile [,] map, Entity ent)
    {
        List<Tile> result = new List<Tile>();
        Stack<Tile> visiting = new Stack<Tile>();
        HashSet<Tile> visited = new HashSet<Tile>();
        visiting.Push(ent.TILE_OF_ENTITY);
        Tile start = ent.TILE_OF_ENTITY;
        int m = ent.CLASS_OF_ENTITY.MOVEMENT;

        while (visiting.Count > 0)
        {
            Tile tile = visiting.Pop();

            if (visited.Contains(tile)) { continue; }
            if (tile.Row < start.Row - m || tile.Row > start.Row + m ||
                tile.Column < start.Column - m || tile.Column > start.Column + m) { continue; }
            if (IsInHeight(start, tile) == false) { continue; }
            visited.Add(tile);
            result.Add(tile);

            // check relatives
            for (int row = tile.Row - 1; row <= tile.Row + 1; row++)
            {
                for (int col = tile.Column - 1; col <= tile.Column + 1; col++)
                {
                    if (IsInBounds(row, col) == false) { continue; }
                    Tile t = map[row, col];
                    if (IsInHeight(tile, t) == false) { continue; }
                    if (tile.IsRelative(t) == false) { continue; }

                    visiting.Push(t);
                }
            }
        }
        return result;
    }
    [System.Obsolete("TODO")]
    /// <summary>
    /// Returns occuable tiles for an entity.
    /// </summary>
    /// <param name="map">mpa to locate tiles from.</param>
    /// <param name="ent">Entity to find tiles for</param>
    /// <returns></returns>
    public static List<Tile> OccuableTiles(Tile[,] map, Entity ent)
    {
        List<Tile> occuableTiles = new List<Tile>();
        Queue<Tile> toVisit = new Queue<Tile>();
        HashSet<Tile> visited = new HashSet<Tile>();

        Tile tile = map[ent.TILE_OF_ENTITY.Row, ent.TILE_OF_ENTITY.Column];
        toVisit.Enqueue(tile);

        int row = tile.Row;
        int col = tile.Column;
        int ogrow = row;
        int ogcol = col;
        int moves = AvailableSteps(ent.CLASS_OF_ENTITY.MOVEMENT, 1);
        int max = ent.CLASS_OF_ENTITY.MOVEMENT;

        int maximumHeight = ent.TILE_OF_ENTITY.Height + Global.AHMI;

        // traverse tiles
        while (toVisit.Count > 0 && moves > 0)
        {
            bool above = false, right = false, left = false, below = false;
            tile = toVisit.Dequeue();

            // List of rules for skipping a particular tile.

            /********** RULES FOR BEING ABLE TO OCCUPY A TILES **********/
            if (visited.Contains(tile) || tile.Height - ent.TILE_OF_ENTITY.Height > Global.AHMI)
            {
                continue;
            }
            if (tile.Row > ogrow + max || tile.Row < ogrow - max)
            {
                continue;
            }
            if (tile.Column > ogcol + max || tile.Column < ogcol - max)
            {
                continue;
            }
            if (tile.Occupant != null && toVisit.Count != 0)
            {
                continue;
            }
            /********************/

            occuableTiles.Add(tile);
            visited.Add(tile);

            row = tile.Row;
            col = tile.Column;

            if (row > 0)
            {
                if (visited.Contains(map[row - 1, col]) == false)
                {
                    // MAKE SURE THE TILE IS THE SAME 
                    if (map[row - 1, col].Height <= maximumHeight)
                    {
                        toVisit.Enqueue(map[row - 1, col]);
                    }
                }
                above = true;
            }
            if (row < Global.Rows - 1)
            {
                if (visited.Contains(map[row + 1, col]) == false)
                {
                    if (map[row + 1, col].Height <= maximumHeight)
                    {
                        toVisit.Enqueue(map[row + 1, col]);
                    }
                }
                below = true;
            }
            // Check the right and left bounds.
            if (col > 0)
            {
                if (visited.Contains(map[row, col - 1]) == false)
                {
                    if (map[row, col - 1].Height <= maximumHeight)
                    {
                        toVisit.Enqueue(map[row, col - 1]);
                    }
                }
                left = true;
            }
            if (col < Global.Columns - 1)
            {
                if (visited.Contains(map[row, col + 1]) == false)
                {
                    if (map[row, col + 1].Height <= maximumHeight)
                    {
                        toVisit.Enqueue(map[row, col + 1]);
                    }
                }
                right = true;
            }

            if (below)
            {
                if (right && col > 0)
                {
                    if (visited.Contains(map[row + 1, col - 1]) == false)
                    {
                        if (map[row + 1, col - 1].Height <= maximumHeight)
                        {
                            toVisit.Enqueue(map[row + 1, col - 1]);
                        }
                    }
                }
                if (left && col < Global.Columns - 1)
                {
                    if (visited.Contains(map[row + 1, col + 1]) == false)
                    {
                        if (map[row + 1, col + 1].Height <= maximumHeight)
                        {
                            toVisit.Enqueue(map[row + 1, col + 1]);
                        }
                    }
                }
            }
            if (above)
            {
                if (right && row > 0)
                {
                    if (visited.Contains(map[row - 1, col + 1]) == false)
                    {
                        if (map[row - 1, col + 1].Height <= maximumHeight)
                        {
                            toVisit.Enqueue(map[row - 1, col + 1]);
                        }
                    }
                }
                if (left && row < Global.Rows - 1)
                {
                    if (visited.Contains(map[row - 1, col - 1]) == false)
                    {
                        if (map[row - 1, col - 1].Height <= maximumHeight)
                        {
                            toVisit.Enqueue(map[row - 1, col - 1]);
                        }
                    }
                }
            }
            moves--;
        }
        return occuableTiles;
    }
    /// <summary>
    /// Represents the check to check if a given tile can interact with another tile.
    /// </summary>
    /// <param name="from">Current tile</param>
    /// <param name="to">Tile to target.</param>
    /// <returns></returns>
    public static bool IsInHeight(Tile from, Tile to)
    {
        if (to.Height <= from.Height + Global.AHTI) { return true; }
        return false;
    }
    /// <summary>
    /// Returns true if the coordinate is within bounds of the global parameters asigned globally*
    /// </summary>
    /// <param name="row">row to check.</param>
    /// <param name="col">column to check.</param>
    /// <returns></returns>
    public static bool IsInBounds(int row, int col)
    {
        return (row >= 0 && row < Global.Rows && col >= 0 && col < Global.Columns);
    }
}