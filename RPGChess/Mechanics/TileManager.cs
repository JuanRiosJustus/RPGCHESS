using System;
using System.Collections.Generic;

/// <summary>
/// Class which manages holds the different functions 
/// to be used on tiles.
/// </summary>
public class TileManager
{
    protected TileManager() { }
    
    /// <summary>
    /// Given the movement, counts the available spaces to be traversed.
    /// </summary>
    /// <param name="movement">move of movement</param>
    /// <param name="count">iteration.</param>
    /// <returns></returns>
    public static int AvailableSteps(int movement, int count)
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
    public static bool HasOccuableRelatives(Tile[,] map, Tile tile)
    {
        throw new NotImplementedException();
        for (int row = tile.Row - 1; row <= tile.Row + 1; row++)
        {
            for (int col = tile.Column - 1; col <= tile.Column + 1; col++)
            {
                // get the tile.
                int realrow = WrapNumber(row, Global.Rows);
                int realcol = WrapNumber(col, Global.Columns);
                Tile t = map[realrow, realcol];

                if (IsNeighbor(tile, t) == false) { continue; }
                if (IsInHeight(tile, t) == false) { continue; }
                return true;
            }
        }
        return false;
    }
    public static bool IsNeighbor(Tile a, Tile b)
    {
        for (int row = a.Row - 1; row <= a.Row + 1; row++)
        {
            for (int col = a.Column - 1; col <= a.Column + 1; col++)
            {
                // get the tile.
                int realrow = WrapNumber(row, Global.Rows);
                int realcol = WrapNumber(col, Global.Columns);
                
                if (realcol == b.Column || realrow == b.Row) { return true; }
            }
        }
        return false;
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
    /// Returns occuable tiles for an entity.
    /// </summary>
    /// <param name="map">mpa to locate tiles from.</param>
    /// <param name="ent">Entity to find tiles for</param>
    /// <returns></returns>
    public static List<Tile> GetOccuableTiles(Tile [,] map, Entity ent)
    {
        List<Tile> result = new List<Tile>();
        Queue<Tile> visiting = new Queue<Tile>();
        HashSet<Tile> visited = new HashSet<Tile>();
        Tile start = ent.TileOfEntity;
        visiting.Enqueue(ent.TileOfEntity);

        while (visiting.Count > 0)
        {
            Tile tile = visiting.Dequeue();

            if (visited.Contains(tile)) { continue;  }
            if (IsInHeight(start, tile) == false) { continue; }
            if (IsInMovementRange(map, tile, ent) == false) { continue; }

            // add tile to available tiles and search for relatives.
            visited.Add(tile);
            result.Add(tile);
            
            // check relatives
            for (int row = tile.Row - 1; row <= tile.Row + 1; row++)
            {
                for (int col = tile.Column - 1; col <= tile.Column + 1; col++)
                {
                    // get the tile.
                    int realrow = WrapNumber(row, Global.Rows);
                    int realcol = WrapNumber(col, Global.Columns);
                    Tile t = map[realrow, realcol];

                    // add relative to queue.
                    visiting.Enqueue(t);
                }
            }
        }
        return result;
    }
    /// <summary>
    /// Develops the hight arount a certain cordinate on a given map.
    /// </summary>
    public static void DevelopAt(Tile[,] map, int row, int col, int intensity)
    {
        bool aboveBottomEdge = false, belowTopEdge = false, leftOfRightEdge = false, rightOfLeftEdge = false;
        map[row, col].SetHeight(map[row, col].Height + intensity);
        // Check to top and bottom bounds
        if (row > 0)
        {
            map[row - 1, col].SetHeight(map[row - 1, col].Height + intensity / 2);
            belowTopEdge = true;
        }
        if (row < map.GetLength(0) - 1)
        {
            map[row + 1, col].SetHeight(map[row + 1, col].Height + intensity / 2);
            aboveBottomEdge = true;
        }
        // Check the right and left bounds.
        if (col > 0)
        {
            map[row, col - 1].SetHeight(map[row, col - 1].Height + intensity / 2);
            rightOfLeftEdge = true;
        }
        if (col < map.GetLength(1) - 1)
        {
            map[row, col + 1].SetHeight(map[row, col + 1].Height + intensity / 2);
            leftOfRightEdge = true;
        }

        if (aboveBottomEdge)
        {
            if (leftOfRightEdge && col > 0)
            {
                map[row + 1, col - 1].SetHeight(map[row + 1, col - 1].Height + intensity / 2);
            }
            if (rightOfLeftEdge && col < map.GetLength(1) - 1)
            {
                map[row + 1, col + 1].SetHeight(map[row + 1, col + 1].Height + intensity / 2);
            }
        }
        if (belowTopEdge)
        {
            if (leftOfRightEdge && row > 0)
            {
                map[row - 1, col + 1].SetHeight(map[row - 1, col + 1].Height + intensity / 2);
            }
            if (rightOfLeftEdge && row < map.GetLength(0) - 1)
            {
                map[row - 1, col - 1].SetHeight(map[row - 1, col - 1].Height + intensity / 2);
            }
        }
    }
    /// <summary>
    /// Checks to see if the given entity can potentially move to the given tile
    /// </summary>
    /// <param name="map">map to check.</param>
    /// <param name="to">tile to check.</param>
    /// <param name="ent">entity given.</param>
    /// <returns></returns>
    public static bool IsInMovementRange(Tile[,] map, Tile to, Entity ent)
    {
        Character c = (Character)ent;
        Tile from = c.TileOfEntity;
        int cMove = c.ClassOfEntity.Movement;

        for (int row = from.Row - cMove; row <= from.Row + cMove; row++)
        {
            for (int col = from.Column - cMove; col <= from.Column + cMove; col++)
            {
                Tile current = map[WrapNumber(row, Global.Rows), WrapNumber(col, Global.Columns)];

                if (to == current)
                {
                    return true;
                }
            }
        }
        return false;
    }
    /// <summary>
    /// Returns a list of all possible tiles an entity may move to.
    /// </summary>
    /// <param name="map">map to check.</param>
    /// <param name="ent">entity to base check off of.</param>
    /// <returns></returns>
    public static List<Tile> AllPossibleTiles(Tile[,] map,Entity ent)
    {
        List<Tile> tiles = new List<Tile>();
        Character c = (Character)ent;
        Tile from = c.TileOfEntity;
        int cMove = c.ClassOfEntity.Movement;
        // check row and column

        for (int row = from.Row - cMove; row <= from.Row + cMove; row++)
        {
            for (int col = from.Column - cMove; col <= from.Column + cMove; col++)
            {
                Tile current = map[WrapNumber(row, Global.Rows), WrapNumber(col, Global.Columns)];
                tiles.Add(current);
            }
        }
        return tiles;
    }
    /// <summary>
    /// Returns the distance of the two tiles.
    /// </summary>
    /// <param name="t1"></param>
    /// <param name="t2"></param>
    /// <returns></returns>
    public static int Distance(Tile t1, Tile t2)
    {
        int rowSquared = (t1.Row - t2.Row) * 2;
        int colSquared = (t1.Column - t2.Column) * 2;
        return (int)Math.Sqrt(colSquared + rowSquared);
    }
    /// <summary>
    /// Wraps the number given a total.
    /// </summary>
    /// <param name="num">number to wrap.</param>
    /// <param name="total">wrap base</param>
    /// <returns></returns>
    public static int WrapNumber(int num, int total)
    {
        if (num < 0) return num + total;
        else if (num >= total) return num % total;
        else return num;
    }
    /// <summary>
    /// the  check if a given tile can interact with another tile.
    /// </summary>
    /// <param name="from">Current tile</param>
    /// <param name="to">Tile to target.</param>
    /// <returns></returns>
    public static bool IsInHeight(Tile from, Tile to)
    {
        if (to.Height <= from.Height + Global.AttackableHeightPerTurn) { return true; }
        return false;
    }
    /// <summary>
    /// The check if a given tile can interact with another tile.
    /// </summary>
    /// <param name="from">starting tile.</param>
    /// <param name="to">ending tile</param>
    /// <param name="limit">limit to not exceed.</param>
    /// <returns></returns>
    public static bool IsInHeight(Tile from, Tile to, int limit)
    {
        if (to.Height <= from.Height + limit) { return true; }
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