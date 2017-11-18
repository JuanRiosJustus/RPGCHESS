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
        private ArrayList list = new ArrayList();
        
        public void SetCharacter(Character character, int x, int y)
        {
            if (list.Contains(character) == false)
            {
                list.Add(character);
            }

            map[x, y].SetOccupant(character);
        }
        public void DeleteCharacter(Character character)
        {
            list.RemoveAt(list.IndexOf(character));
        }

        public void MoveCharacter(Character character, Direction direction)
        {
           // TODO
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
                    tiles[row, column].SetScreenXY((tiles[row, column].X * Universal.XYSpacing) + 10, (tiles[row, column].Y * Universal.XYSpacing) + 10);
                    tiles[row, column].SetSceenTileSize(Universal.BoxSize);
                    Console.Write(tiles[row, column].Height + " ");
                }
                Console.WriteLine();
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
