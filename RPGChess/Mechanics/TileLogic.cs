using System;
using System.Collections;
using System.Collections.Generic;

public static class TileLogic
{
    /// <summary>
    /// Given the movement, counts the available spaces to be traversed.
    /// </summary>
    /// <param name="movement"></param>
    /// <param name="count"></param>
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
    /// <param name="movement"></param>
    /// <param name="count"></param>
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
    /// Given a current tile, list of available tiles, and a direction;
    /// locates the next available tile in that location.
    /// </summary>
    /// <param name="currentTile"></param>
    /// <param name="availableTiles"></param>
    /// <param name="direction"></param>
    /// <returns></returns>
    public static Tile TileRespectingDirection(Tile currentTile, ArrayList availableTiles, Direction direction)
    {
        Tile tile = null;

        switch (direction)
        {
            case Direction.NORTH:
                {
                    for (int i = 0; i < availableTiles.Count; i++)
                    {
                        Tile t = (Tile)availableTiles[i];
                        if (t.ROW + 1 == currentTile.ROW && t.COL == currentTile.COL)
                        {
                            tile = t;
                        }
                    }
                }
                break;
            case Direction.EAST:
                {
                    for (int i = 0; i < availableTiles.Count; i++)
                    {
                        Tile t = (Tile)availableTiles[i];
                        if (t.COL == currentTile.COL + 1 && t.ROW == currentTile.ROW)
                        {
                            tile = t;
                        }
                    }
                }
                break;
            case Direction.SOUTH:
                {
                    for (int i = 0; i < availableTiles.Count; i++)
                    {
                        Tile t = (Tile)availableTiles[i];
                        if (t.ROW == currentTile.ROW + 1 && t.COL == currentTile.COL)
                        {
                            tile = t;
                        }
                    }
                }
                break;
            case Direction.WEST:
                {
                    for (int i = 0; i < availableTiles.Count; i++)
                    {
                        Tile t = (Tile)availableTiles[i];
                        if (t.COL == currentTile.COL - 1 && t.ROW == currentTile.ROW)
                        {
                            tile = t;
                        }
                    }
                }
                break;
        }

        return tile;
    }
    /// <summary>
    /// Adds attackable entities to the character.
    /// </summary>
    /// <param name="map">Map used to check.</param>
    /// <param name="character">Character to check.</param>
    public static void AddAttackableEntitiesToEntity(Tile[,] map, Character character)
    {
        character.ClearAttackableEntities();
        int cr = character.CLASS_OF_ENTITY.Range;
        Tile ct = character.TILE_OF_ENTITY;

        for (int row = ct.ROW - cr; row < ct.ROW + cr; row++)
        {
            for (int col = ct.COL - cr; col < ct.COL + cr; col++)
            {
                if (col > -1 && row > -1)
                {
                    Tile t = map[row, col];
                    if (t.IsOccupied() && (Character)t.Occupant != character)
                    {
                        Character c = (Character)t.Occupant;
                        Console.WriteLine(c + " has been detected");
                        character.AddAttackableCharacter(c);
                    }
                }
            }
        }
    }
    /// <summary>
    /// Returns a tile based on a given string from the game.
    /// </summary>
    /// <param name="game">The game to get the tile rom.</param>
    /// <param name="str">The string to parse/related to the tile.</param>
    /// <returns></returns>
    public static Tile ConvertStringToTile (Game game, string str)
    {
        if (str.Length > 2 && str.Contains(",") && str.Contains("]") & str.Contains("["))
        {
            int firstCoord = Convert.ToInt32(str.Substring(1, str.IndexOf(',') - 1));
            int secCoord = Int32.Parse(str.Substring(str.IndexOf(',') + 1, str.IndexOf(']') - 3));
            return game.GetBoardTile(secCoord, firstCoord);
        }

        throw new Exception("CRITICAL PARSING ERROR: NULL TILE.");
    }
    /// <summary>
    /// Given a map and character, adds tiles the player could potentially move to. 
    /// </summary>
    /// <param name="map"></param>
    /// <param name="character"></param>
    public static void AddOccuableTilesToEntity(Tile[,] map, Character character)
    {
        Queue<Tile> toVisit = new Queue<Tile>();
        HashSet<Tile> visited = new HashSet<Tile>();

        Tile tile = map[character.TILE_OF_ENTITY.ROW, character.TILE_OF_ENTITY.COL];
        toVisit.Enqueue(tile);

        int row = tile.ROW;
        int col = tile.COL;
        int ogrow = row;
        int ogcol = col;
        int moves = TileLogic.AvailableSteps(character.CLASS_OF_ENTITY.Movement, 1);
        int max = character.CLASS_OF_ENTITY.Movement;

        while (toVisit.Count > 0 && moves > 0)
        {
            bool above = false, right = false, left = false, below = false;
            tile = toVisit.Dequeue();
            int maximumHeight = character.TILE_OF_ENTITY.Height + Global.AHI;
            if (visited.Contains(tile) || (tile.ROW > ogrow + max || tile.ROW < ogrow - max) || (tile.COL > ogcol + max || tile.COL < ogcol - max))
            {
                continue;   
            }
            character.AddOccuableTile(tile);
            //Console.WriteLine(tile.ToCoordinate() + " " + tile.Height + " " + tile.Biome);
            visited.Add(tile);

            row = tile.ROW;
            col = tile.COL;

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
            if (row < map.GetLength(0) - 1)
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
            if (col < map.GetLength(1) - 1)
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
                if (left && col < map.GetLength(1) - 1)
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
                if (left && row < map.GetLength(0) - 1)
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
    }
}