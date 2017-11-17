using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGChess.Overworld
{
    class Board
    {
        private Tile[,] map;
        private Random random;

        public Board()
        {
            random = new Random();
        }

        /// <summary>
        /// Generates a basic and the default map give a size.
        /// </summary>
        /// <param name="mapsize"></param>
        /// <returns></returns>
        public void GenerateMap(int mapsize, string biome)
        {
            Tile[,] tiles = new Tile[mapsize, mapsize];

            for (int row = 0; row < tiles.GetLength(0); row++)
            {
                for (int column = 0; column < tiles.GetLength(1); column++)
                {
                    tiles[column,row] = new Tile(column, row, random.Next(3), biome, null);
                }
                Console.WriteLine();
            }
            map = tiles;
        }
        
        public void GenerateDevelopAt(int x, int y, int intensity)
        {
            BoardDesigner.DevelopAt(map, x, y, intensity);
        }
        public void GenerateAcross(int intensity, Option option)
        {
            BoardDesigner.DevelopAcross(map, intensity, option);
        }



        //-----------------------------------------------------------------------------
        public void TopographToConsole()
        {
            Console.WriteLine("===========================================");
            Console.WriteLine("===========================================");
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
                    Console.Write(map[column, row].PrintTopograph());
                }
                Console.WriteLine();
            }
        }

        public void GeneralToConsole()
        {
            Console.WriteLine("===========================================");
            Console.WriteLine("===========================================");
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
                    Console.Write(map[column, row].PrintStandard());
                }
                Console.WriteLine();
            }
        }
    }
}
