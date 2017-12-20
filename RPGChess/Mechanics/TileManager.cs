using System;
using System.Collections;
using System.Collections.Generic;

public class TileManager
{
    private static Singleton Logic = null;

    protected TileManager()
    {
        // constructor
    }
    private class Singleton
    {

        public Singleton()
        {
            // constructor
        }
        /// <summary>
        /// Given the movement, counts the available spaces to be traversed.
        /// </summary>
        /// <param name="movement"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public int ASteps(int movement, int count)
        {
            if (movement == 1)
            {
                return 9;
            }
            else
            {
                return ASteps(movement - 1, ++count) + 8 * count--;
            }
        }
        /// <summary>
        /// Determines the denied steps for cases with one bounded side for their movement.
        /// </summary>
        /// <param name="movement"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public int DSteps(int movement, int count)
        {
            if (movement == 1)
            {
                return 3;
            }
            else
            {
                return DSteps(movement - 1, count + 1) + 7 + (4 * (count - 1));
            }
        }
        /// <summary>
        /// Adds attackable entities to the character.
        /// </summary>
        /// <param name="map">Map used to check.</param>
        /// <param name="character">Character to check.</param>
        public void AAETE(Tile[,] map, Character character)
        {
            character.ClearAttackableEntities();
            int range = character.CLASS_OF_ENTITY.RANGE;
            Tile ct = character.TILE_OF_ENTITY;

            for (int row = ct.Row - range; row <= ct.Row + range; row++)
            {
                for (int col = ct.Column - range; col <= ct.Column + range; col++)
                {
                    if (col > -1 && row > -1 && col < Global.Columns && row < Global.Rows)
                    {
                        Tile t = map[row, col];
                        if (t.IsOccupied() && t != ct)
                        {
                            if (ct.Height - t.Height >= (Global.AHAI * -1))
                            {
                                Character c = (Character)t.Occupant;
                                character.AddAttackableCharacter(c);
                            }
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Given a map and character, adds tiles the player could potentially move to. 
        /// </summary>
        /// <param name="map"></param>
        /// <param name="character"></param>
        public void AOTTE(Tile[,] map, Character character)
        {
            character.ClearOccuableTiles();

            Queue<Tile> toVisit = new Queue<Tile>();
            HashSet<Tile> visited = new HashSet<Tile>();

            Tile tile = map[character.TILE_OF_ENTITY.Row, character.TILE_OF_ENTITY.Column];
            toVisit.Enqueue(tile);

            int row = tile.Row;
            int col = tile.Column;
            int ogrow = row;
            int ogcol = col;
            int moves = ASteps(character.CLASS_OF_ENTITY.MOVEMENT, 1);
            int max = character.CLASS_OF_ENTITY.MOVEMENT;

            int maximumHeight = character.TILE_OF_ENTITY.Height + Global.AHMI;

            // traverse tiles
            while (toVisit.Count > 0 && moves > 0)
            {
                bool above = false, right = false, left = false, below = false;
                tile = toVisit.Dequeue();

                if (visited.Contains(tile) || (tile.Row > ogrow + max || 
                   tile.Row < ogrow - max) ||
                   (tile.Column > ogcol + max || tile.Column < ogcol - max))
                {
                    continue;
                }
                if (tile.Height - character.TILE_OF_ENTITY.Height > Global.AHMI)
                {
                    continue;
                }

                character.AddOccuableTile(tile);
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
        /// <summary>
        /// Returns a tile based on a given string from the game.
        /// </summary>
        /// <param name="game">The game to get the tile rom.</param>
        /// <param name="str">The string to parse/related to the tile.</param>
        /// <returns></returns>
        public Tile CSTT(Game game, string str)
        {
            bool isFormated = str.StartsWith("[") && str.Contains(",") && str.EndsWith("]");

            if (isFormated)
            {
                str = str.Substring(1, str.Length - 2).Replace(",", " ");

                int firstNum = Int32.Parse(str.Substring(0, str.IndexOf(" ")));

                int secondNum = Int32.Parse(str.Substring(str.IndexOf(" ")));

                return game.GetBoardTile(secondNum, firstNum);
            }

            throw new Exception("CRITICAL PARSING ERROR: NULL TILE.");
        }
    }
    /// <summary>
    /// Checks that the character can move to the selected tile
    /// </summary>
    /// <param name="c"></param>
    /// <param name="t"></param>
    /// <returns></returns>
    public static bool MovableTo(Character c, Tile t)
    {
        for (int i = 0; i < c.GetOccuableTileQuantity(); i++)
        {
            Tile te = c.GetOccuableTile(i);
            if (te == t)
            {
                return true;
            }
        }
        return false;
    }
    /// <summary>
    /// Checks that the instance of the class has been created.
    /// </summary>
    /// <returns></returns>
    private static Singleton GetSingletonInstance()
    {
        if (Logic == null)
        {
            Logic = new Singleton();
        }
        return Logic;
    }
    /// <summary>
    /// Given the movement, counts the available spaces to be traversed.
    /// </summary>
    /// <param name="movement"></param>
    /// <param name="count"></param>
    /// <returns></returns>
    public static int AvailableSteps(int movement, int count)
    {
        GetSingletonInstance();
        return Logic.ASteps(movement, count);
    }
    /// <summary>
    /// Determines the denied steps for cases with one bounded side for their movement.
    /// </summary>
    /// <param name="movement"></param>
    /// <param name="count"></param>
    /// <returns></returns>
    public static int DeniedSteps(int movement, int count)
    {
        GetSingletonInstance();
        return Logic.DSteps(movement, count);
    }
    /// <summary>
    /// Returns a tile based on a given string from the game.
    /// </summary>
    /// <param name="game">The game to get the tile rom.</param>
    /// <param name="str">The string to parse/related to the tile.</param>
    /// <returns></returns>
    public Tile ConvertStringToTile(Game game, string str)
    {
        GetSingletonInstance();
        return Logic.CSTT(game, str);
    }
    /// <summary>
    /// Given a map and character, adds tiles the player could potentially move to. 
    /// </summary>
    /// <param name="map"></param>
    /// <param name="character"></param>
    public static void AddOccuableTilesToEntity(Tile[,] map, Character character)
    {
        GetSingletonInstance();
        Logic.AOTTE(map, character);
    }
    /// <summary>
    /// Adds attackable entities to the character.
    /// </summary>
    /// <param name="map">Map used to check.</param>
    /// <param name="character">Character to check.</param>
    public static void AddAttackableEntitiesToEntity(Tile[,] map, Character character)
    {
        GetSingletonInstance();
        Logic.AAETE(map, character);
    }
    public static List<Entity> TargetableEntities(Tile[,] map, Character cha)
    {
        List<Entity> targetableEntities = new List<Entity>();
        
        int range = cha.CLASS_OF_ENTITY.RANGE;
        Tile currentTile = cha.TILE_OF_ENTITY;

        for (int row = currentTile.Row - range; row <= currentTile.Row + range; row++)
        {
            for (int col = currentTile.Column - range; col <= currentTile.Column + range; col++)
            {
                if (col > -1 && row > -1 && col < Global.Columns && row < Global.Rows)
                {
                    Tile t = map[row, col];
                    if (t.IsOccupied() && t != currentTile)
                    {
                        if (currentTile.Height - t.Height >= (Global.AHAI * -1))
                        {
                            Character c = (Character)t.Occupant;
                            cha.AddAttackableCharacter(c);
                        }
                    }
                }
            }
        }

    }
    /// <summary>
    /// Returns occuable tiles determined by character movement and tile height.
    /// </summary>
    /// <param name="map">mpa to locate tiles from.</param>
    /// <param name="cha">Character to be search off of.</param>
    /// <returns></returns>
    public static List<Tile> OccuableTiles(Tile[,] map, Character cha)
    {
        List<Tile> occuableTiles = new List<Tile>();
        Queue<Tile> toVisit = new Queue<Tile>();
        HashSet<Tile> visited = new HashSet<Tile>();

        Tile tile = map[cha.TILE_OF_ENTITY.Row, cha.TILE_OF_ENTITY.Column];
        toVisit.Enqueue(tile);

        int row = tile.Row;
        int col = tile.Column;
        int ogrow = row;
        int ogcol = col;
        int moves = Logic.ASteps(cha.CLASS_OF_ENTITY.MOVEMENT, 1);
        int max = cha.CLASS_OF_ENTITY.MOVEMENT;

        int maximumHeight = cha.TILE_OF_ENTITY.Height + Global.AHMI;

        // traverse tiles
        while (toVisit.Count > 0 && moves > 0)
        {
            bool above = false, right = false, left = false, below = false;
            tile = toVisit.Dequeue();

            // List of rules for skipping a particular tile.

            /********** RULES FOR BEING ABLE TO OCCUPY A TILES **********/
            if (visited.Contains(tile) || tile.Height - cha.TILE_OF_ENTITY.Height > Global.AHMI)
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
        return occuableTiles;
    }
}