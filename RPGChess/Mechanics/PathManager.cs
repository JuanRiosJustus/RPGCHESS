
using System;
using System.Collections.Generic;

/// <summary>
/// Class that manages the means of traversal by an entity.
/// </summary>
public class PathManager
{
    protected PathManager() { }

    /// <summary>
    /// Returns occuable tiles for an entity.
    /// </summary>
    /// <param name="map">mpa to locate tiles from.</param>
    /// <param name="ent">Entity to find tiles for</param>
    /// <returns></returns>
    public static List<Tile> BasicPath2(Tile[,] map, Entity ent)
    {
        List<Tile> result = new List<Tile>();
        Queue<Tile> visiting = new Queue<Tile>();
        HashSet<Tile> visited = new HashSet<Tile>();
        Tile start = ent.TileOfEntity;
        visiting.Enqueue(ent.TileOfEntity);
        visiting.Enqueue(null);
        int bounds = 0;
        while (visiting.Count > 0)
        {
            Tile tile = visiting.Dequeue();
            if (bounds == ent.ClassOfEntity.Movement + 1) { continue; }
            if (tile == null) { visiting.Enqueue(null); bounds++; continue; }
            if (visited.Contains(tile)) { continue; }
            if (TileManager.IsInHeight(start, tile) == false) { continue; }
            if (TileManager.IsInMovementRange(map, tile, ent) == false) { continue; }

            // add tile to available tiles and search for relatives.
            visited.Add(tile);
            result.Add(tile);
            // check relatives
            for (int row = tile.Row - 1; row <= tile.Row + 1; row++)
            {
                for (int col = tile.Column - 1; col <= tile.Column + 1; col++)
                {
                    // get the tile.
                    int realrow = TileManager.WrapNumber(row, Global.Rows);
                    int realcol = TileManager.WrapNumber(col, Global.Columns);
                    Tile t = map[realrow, realcol];
                    if (TileManager.IsInHeight(tile, t, 2) == false) { continue; }
                    // add relative to queue.
                    visiting.Enqueue(t);
                }
            }
        }
        return result;
    }
    [System.Obsolete("Unused")]
    /// <summary>
    /// Returns occuable tiles for an entity.
    /// </summary>
    /// <param name="map">mpa to locate tiles from.</param>
    /// <param name="ent">Entity to find tiles for</param>
    /// <returns></returns>
    public static List<Tile> BasicPath1(Tile[,] map, Entity ent)
    {
        List<Tile> occuableTiles = new List<Tile>();
        Queue<Tile> toVisit = new Queue<Tile>();
        HashSet<Tile> visited = new HashSet<Tile>();

        Tile tile = map[ent.TileOfEntity.Row, ent.TileOfEntity.Column];
        toVisit.Enqueue(tile);

        int row = tile.Row;
        int col = tile.Column;
        int ogrow = row;
        int ogcol = col;
        int moves = TileManager.AvailableSteps(ent.ClassOfEntity.Movement, 1);
        int max = ent.ClassOfEntity.Movement;

        int maximumHeight = ent.TileOfEntity.Height + Global.HeightIncreasePerTurn;

        // traverse tiles
        while (toVisit.Count > 0 && moves > 0)
        {
            bool above = false, right = false, left = false, below = false;
            tile = toVisit.Dequeue();

            // List of rules for skipping a particular tile.

            /********** RULES FOR BEING ABLE TO OCCUPY A TILES **********/
            if (visited.Contains(tile) || tile.Height - ent.TileOfEntity.Height > Global.HeightIncreasePerTurn)
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
}