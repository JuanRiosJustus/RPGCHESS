using RPGChess.Entities;
using RPGChess.Utility;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGChess.Overworld
{
    class Board
    {
        public enum View
        {
            Level,
            Topograph,
            Coordinate,
            Biome,
            Standard,
        };

        private Tile[,] map;
        private Random random = new Random();
        private SGLArrayList<Character> list = new SGLArrayList<Character>();
        
        public void AddCharacter(Character character, int row, int col)
        {
            if (list.Contains(character) == false)
            {
                Console.WriteLine("Adding new character: " + character.GetSurname());
                list.Add(character);
            }
            
            Tile tile = map[row, col];
            while(tile.IsOccupied() || tile.Biome.Equals("WTR"))
            {
                row = random.Next(Universal.Rows);
                col = random.Next(Universal.Columns);
                tile = map[row, col];
            }

            Console.WriteLine(character.GetSurname() + " was placed at: [" + col + "," + row + "]");
            map[row, col].SetOccupant(character);
            SetAvailableTiles(character);
            Console.WriteLine("With a height of " + character.EntityTile.ToTopograph());
            Console.WriteLine(character.TilesToString());
        }
        private void SetAvailableTiles(Character character)
        {
            //int moves = 8*1 + 1;//character.TYPE_OF_CLASS.Movement;
            //bool above = false, right = false, left = false, below = false;
            Queue<Tile> toVisit = new Queue<Tile>();
            HashSet<Tile> visited = new HashSet<Tile>();
            Tile tile = map[character.EntityTile.ROW, character.EntityTile.COL];
            toVisit.Enqueue(tile);
            int row = tile.ROW;
            int col = tile.COL;
            int moves = 8 * 3 - (row == 0 || col == 0 || row == Universal.Columns || col == Universal.Rows ? 3 : 0);
            while (toVisit.Count > 0 && moves > 0)
            {
                bool above = false, right = false, left = false, below = false;
                tile = toVisit.Dequeue();
                if (visited.Contains(tile) || tile.Height > character.EntityTile.Height + Universal.Allow || tile.Height < character.EntityTile.Height - Universal.Allow)
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
                        toVisit.Enqueue(map[row - 1, col]);
                    }
                    above = true;
                }
                if (row < map.GetLength(0) - 1)
                {
                    if (visited.Contains(map[row + 1, col]) == false)
                    {
                        toVisit.Enqueue(map[row + 1, col]);
                    }
                    below = true;
                }
                // Check the right and left bounds.
                if (col > 0)
                {
                    if (visited.Contains(map[row, col - 1]) == false)
                    {
                        toVisit.Enqueue(map[row, col - 1]);
                    }
                    left = true;
                }
                if (col < map.GetLength(1) - 1)
                {
                    if (visited.Contains(map[row, col + 1]) == false)
                    {
                        toVisit.Enqueue(map[row, col + 1]);
                    }
                    right = true;
                }

                if (below)
                {
                    if (right && col > 0)
                    {
                        if (visited.Contains(map[row + 1, col - 1]) == false)
                        {
                            toVisit.Enqueue(map[row + 1, col - 1]);
                        }
                    }
                    if (left && col < map.GetLength(1) - 1)
                    {
                        if (visited.Contains(map[row + 1, col + 1]) == false)
                        {
                            toVisit.Enqueue(map[row + 1, col + 1]);
                        }
                    }
                }
                if (above)
                {
                    if (right && row > 0)
                    {
                        if (visited.Contains(map[row - 1, col + 1]) == false)
                        {
                            toVisit.Enqueue(map[row - 1, col + 1]);
                        }
                    }
                    if (left && row < map.GetLength(0) - 1)
                    {
                        if(visited.Contains(map[row - 1,col - 1]) == false)
                        {
                            toVisit.Enqueue(map[row - 1, col - 1]);
                        }
                    }
                }
                moves--;
            }







            /*
            int moves = 2;//character.TYPE_OF_CLASS.Movement;
            //Tile tile = map[character.EntityTile.ROW, character.EntityTile.COL];
            Console.WriteLine("Currently on: " + character.EntityTile.ToCoordinate() + " with a range of : " + moves + " standing in " + character.EntityTile.ToBiome());
            
            for (int row = character.EntityTile.ROW - moves; row <= character.EntityTile.ROW + moves; row++)
            {
                if(row >= 0 && row <= Universal.Rows)
                {
                    for (int col = character.EntityTile.COL - moves; col <= character.EntityTile.ROW + moves; col++)
                    {
                        if (col >= 0 && col <= Universal.Columns)
                        {
                            
                            Tile tile = map[row, col];

                            if (tile.ToBiome().Equals("[WTR]") == false && tile.Height < character.EntityTile.Height + Universal.Allow)
                            {
                                Console.WriteLine(map[row, col].Biome + " IS NOT WTR AND IS ADDED");
                                character.AddTile(tile);
                            }
                        }
                    }
                }
            }*/
        }
        public void DeleteCharacter(Character character)
        {
            list.Delete(character);
            //list.RemoveAt(list.IndexOf(character));
        }

        public void MoveCharacter(Character character, Direction direction)
        {
            // TODO
            //Character charac = (Character)list[list.IndexOf(character)];
            //charac.SetTile(map[4, 4]);

        }
        public Tile PromptUserForTilePick(Character character)
        {
            //TODO
            return null;
        }
        public int GetBoardSize(int dimension)
        {
            return map.GetLength(dimension);
        }

        public Tile GetTile(int x, int y)
        {
            return map[x, y];
        }
        /// <summary>
        /// Generates a basic and the default map given a size.
        /// </summary>
        /// <param name="mapsize"></param>
        /// <returns></returns>
        public void GenerateMap(int map_rows, int map_cols)
        {
            Tile[,] tiles = new Tile[map_rows, map_cols];

            for (int row = 0; row < tiles.GetLength(0); row++)
            {
                for (int column = 0; column < tiles.GetLength(1); column++)
                {
                    int height = random.Next(-1, 1);
                    tiles[row, column] = new Tile(row, column, height, null);
                    tiles[row, column].SetScreenXY((tiles[row, column].ROW * Universal.XYSpacing) + 10, (tiles[row, column].COL * Universal.XYSpacing) + 10);
                    tiles[row, column].SetSceenTileSize(Universal.BoxSize);
                }
            }
            map = tiles;
        }
        
        public void GenerateDevelopAt(int row, int col, int intensity)
        {
            BoardDesigner.DevelopAt(map, row, col, intensity);
        }
        [System.Obsolete("GenerateAcross() is deprecated, use GenerateDevelopAt().")]
        public void GenerateAcross(int intensity, Option option)
        {
            BoardDesigner.DevelopAcross(map, intensity, option);
        }


        public void ToConsole(View view)
        {
            switch(view)
            {
                case View.Topograph:
                    {
                        Console.WriteLine("------------------------------");
                        Console.WriteLine("TOPOGRAPHICAL MAP");
                        Console.WriteLine("------------------------------");
                        Console.Write("  ");
                        for (int i = 0; i < map.GetLength(1); i++)
                        {
                            Console.Write(" " + i + (i >= 9 ? "" : " "));
                        }
                        Console.WriteLine();

                        for (int row = 0; row < map.GetLength(0); row++)
                        {
                            for (int column = 0; column < map.GetLength(1); column++)
                            {
                                Console.Write((column == 0 ? row + (row <= 9 ? " " : "") : ""));
                                Console.Write(map[column, row].ToTopograph());
                            }
                            Console.WriteLine();
                        }
                        break;
                    }
                case View.Level:
                    {
                        Console.WriteLine("------------------------------");
                        Console.WriteLine("LEVEL MAP");
                        Console.WriteLine("------------------------------");
                        Console.Write("  ");
                        for (int i = 0; i < map.GetLength(1); i++)
                        {
                            Console.Write(" " + i + (i >= 9 ? "" : " "));
                        }
                        Console.WriteLine();

                        for (int row = 0; row < map.GetLength(0); row++)
                        {
                            for (int column = 0; column < map.GetLength(1); column++)
                            {
                                Console.Write((column == 0 ? row + (row <= 9 ? " " : "") : ""));
                                Console.Write(map[column, row].ToLevel());
                            }
                            Console.WriteLine();
                        }
                        break;
                    }
                case View.Coordinate:
                    {
                        Console.WriteLine("------------------------------");
                        Console.WriteLine("COORDINATE MAP");
                        Console.WriteLine("------------------------------");
                        Console.Write("  ");
                        for (int i = 0; i < map.GetLength(1); i++)
                        {
                            Console.Write(" " + i + (i >= 9 ? "" : " "));
                        }
                        Console.WriteLine();

                        for (int row = 0; row < map.GetLength(0); row++)
                        {
                            for (int column = 0; column < map.GetLength(1); column++)
                            {
                                Console.Write((column == 0 ? row + (row <= 9 ? " " : "") : ""));
                                Console.Write(map[column, row].ToCoordinate());
                            }
                            Console.WriteLine();
                        }
                    }
                    break;
                case View.Biome:
                    {
                        Console.WriteLine("------------------------------");
                        Console.WriteLine("COORDINATE MAP");
                        Console.WriteLine("------------------------------");
                        Console.Write("  ");
                        for (int i = 0; i < map.GetLength(1); i++)
                        {
                            Console.Write(" " + i + (i >= 9 ? "" : " "));
                        }
                        Console.WriteLine();

                        for (int row = 0; row < map.GetLength(0); row++)
                        {
                            for (int column = 0; column < map.GetLength(1); column++)
                            {
                                Console.Write((column == 0 ? row + (row <= 9 ? " " : "") : ""));
                                Console.Write(map[column, row].ToBiome());
                            }
                            Console.WriteLine();
                        }
                    }
                    break;
                case View.Standard:
                    {
                        Console.WriteLine("------------------------------");
                        Console.WriteLine("STANDARD MAP");
                        Console.WriteLine("------------------------------");
                        Console.Write("  ");
                        for (int i = 0; i < map.GetLength(1); i++)
                        {
                            Console.Write(" " + i + (i >= 9 ? "" : " "));
                        }
                        Console.WriteLine();

                        for (int row = 0; row < map.GetLength(0); row++)
                        {
                            for (int column = 0; column < map.GetLength(1); column++)
                            {
                                Console.Write((column == 0 ? row + (row <= 9 ? " " : "") : ""));
                                Console.Write(map[column, row].ToStandard());
                            }
                            Console.WriteLine();
                        }
                    }
                    break;
            }
        }
    }
}
