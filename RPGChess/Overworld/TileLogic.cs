using RPGChess.Entities;
using RPGChess.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGChess.Overworld
{
    static class TileLogic
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
        [System.Obsolete("UGHH, TODO NEED TO GET NEXT MOST TILE WHERE THE FDUFFERENCE IS ONLY ONE")]
        public static Tile ListRespectingDirection(Tile currentTile, SGLArrayList<Tile> availableTiles, Direction direction)
        {
            Tile tile = null;

            switch(direction)
            {
                case Direction.NORTH:
                    {
                        for (int i = 0; i < availableTiles.Length(); i++)
                        {
                            if (availableTiles.Get(i).ROW+1 == currentTile.ROW && availableTiles.Get(i).COL == currentTile.COL)
                            {
                                tile = availableTiles.Get(i);
                            }
                        }
                    }
                    break;
                case Direction.EAST:
                    {
                        for (int i = 0; i < availableTiles.Length(); i++)
                        {
                            if (availableTiles.Get(i).COL == currentTile.COL+1 && availableTiles.Get(i).ROW == currentTile.ROW)
                            {
                                tile = availableTiles.Get(i);
                            }
                        }
                    }
                    break;
                case Direction.SOUTH:
                    {
                        for (int i = 0; i < availableTiles.Length(); i++)
                        {
                            if (availableTiles.Get(i).ROW == currentTile.ROW+1 && availableTiles.Get(i).COL == currentTile.COL)
                            {
                                tile = availableTiles.Get(i);
                            }
                        }
                    }
                    break;
                case Direction.WEST:
                    {
                        for (int i = 0; i < availableTiles.Length(); i++)
                        {
                            if (availableTiles.Get(i).COL == currentTile.COL-1 && availableTiles.Get(i).ROW == currentTile.ROW)
                            {
                                tile = availableTiles.Get(i);
                            }
                        }
                    }
                    break;
            }

            return tile;
        }
        /// <summary>
        /// Finds the appropriate tiles for the selleted plaer to traverse
        /// TODO CLASS MOEBVEMENT
        /// </summary>
        /// <param name="map"></param>
        /// <param name="character"></param>
        public static void AddTraversableTilesToEntity(Tile[,] map, Character character)
        {
            //int moves = 8*1 + 1;//character.TYPE_OF_CLASS.Movement;
            //bool above = false, right = false, left = false, below = false;
            Queue<Tile> toVisit = new Queue<Tile>();
            HashSet<Tile> visited = new HashSet<Tile>();

            Tile tile = map[character.EntityTile.ROW, character.EntityTile.COL];
            toVisit.Enqueue(tile);

            int row = tile.ROW;
            int col = tile.COL;
            int ogrow = row;
            int ogcol = col;

            int count = TileLogic.AvailableSteps(2, 1);

            Console.WriteLine("Available steps: " + count + " ");

            int moves = count;
            
            while (toVisit.Count > 0 && moves > 0)
            {
                bool above = false, right = false, left = false, below = false;
                tile = toVisit.Dequeue();
                int maximumHeight = character.EntityTile.Height + Universal.Allow;
                if (visited.Contains(tile) || (tile.ROW > ogrow + 2 || tile.ROW < ogrow - 2) || (tile.COL > ogcol + 2 || tile.COL < ogcol - 2))
                {
                    continue;
                }
                character.AddTile(tile);
                Console.WriteLine(tile.ToCoordinate() + " " + tile.Height + " " + tile.Biome);
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
}
