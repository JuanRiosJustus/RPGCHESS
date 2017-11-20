using RPGChess.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGChess.Overworld
{
    
    class BoardDesigner
    {
        public static void DevelopAt(Tile[,] map, int row, int col, int intensity)
        {
            bool aboveBottomEdge = false, belowTopEdge = false, leftOfRightEdge = false, rightOfLeftEdge = false;
            map[row, col].SetHeight(map[row, col].Height + intensity);
            //Console.WriteLine(map[row, col].Height + " is th eheight");
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
        public static void DevelopAcross(Tile[,] map, int intensity, Option option)
        {
            int x = map.GetLength(1) - 1;
            switch(option)
            {
                case Option.ONE:
                    for (int i = 0; i < map.GetLength(1) - 2; i++)
                    {
                        DevelopAt(map, x - i, i, intensity);
                    }
                    break;
                case Option.TWO:
                    for (int i = 0; i < map.GetLength(1) - 1; i++)
                    {
                        DevelopAt(map, i , i, intensity);
                    }
                    break;
                case Option.THREE:
                    for (int i = 1; i < map.GetLength(0) - 1; i++)
                    {
                        DevelopAt(map, i, (map.GetLength(0) -2) / 2, intensity);
                    }
                    break;
                case Option.FOUR:
                    for (int i = 1; i < map.GetLength(1) - 1; i++)
                    {
                        DevelopAt(map, (map.GetLength(1) / 2), i, intensity);
                    }
                    break;
            }
        }
    }
}
