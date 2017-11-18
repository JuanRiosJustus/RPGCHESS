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
        public static void DevelopAt(Tile[,] map, int x, int y, int intensity, string biome)
        {
            bool aboveBottomEdge = false, belowTopEdge = false, leftOfRightEdge = false, rightOfLeftEdge = false;
            map[x, y].SetHeight(map[x, y].Height + intensity);
            if (x >= 1)
            {
                map[x - 1, y].SetHeight(map[x - 1, y].Height + intensity / 2);
                map[x - 1, y].SetBiome(biome);
                rightOfLeftEdge = true;
            }
            if (x <= map.GetLength(0) - 2)
            {
                map[x + 1, y].SetHeight(map[x + 1, y].Height + intensity / 2);
                map[x + 1, y].SetBiome(biome);
                leftOfRightEdge = true;
            }
            if (y >= 1)
            {
                map[x, y - 1].SetHeight(map[x, y - 1].Height + intensity / 2);
                map[x, y - 1].SetBiome(biome);
                belowTopEdge = true;
            }
            if (y <= map.GetLength(1) - 2)
            {
                map[x, y + 1].SetHeight(map[x, y + 1].Height + intensity / 2);
                map[x, y + 1].SetBiome(biome);
                aboveBottomEdge = true;
            }

            if (belowTopEdge)
            {
                if (leftOfRightEdge)
                {
                    map[x - 1, y - 1].SetHeight(map[x - 1, y - 1].Height + intensity / 2);
                    map[x - 1, y - 1].SetBiome(biome);
                }
                if (rightOfLeftEdge)
                {
                    map[x + 1, y - 1].SetHeight(map[x + 1, y - 1].Height + intensity / 2);
                    map[x + 1, y - 1].SetBiome(biome);
                }
            }
            if (aboveBottomEdge)
            {
                if (leftOfRightEdge)
                {
                    map[x + 1, y + 1].SetHeight(map[x + 1, y + 1].Height + intensity / 2);
                    map[x + 1, y + 1].SetBiome(biome);
                }
                if (rightOfLeftEdge)
                {
                    map[x - 1, y + 1].SetHeight(map[x - 1, y + 1].Height + intensity / 2);
                    map[x - 1, y + 1].SetBiome(biome);
                }
            }
        }
        public static void DevelopAcross(Tile[,] map, int intensity, Option option, string biome)
        {
            switch(option)
            {
                case Option.ONE:
                    for (int i = 0; i < map.GetLength(0) - 1; i++)
                    {
                        DevelopAt(map, map.GetLength(0) - 1 - i, i, intensity, biome);
                    }
                    break;
                case Option.TWO:
                    for (int i = 0; i < map.GetLength(0) - 1; i++)
                    {
                        DevelopAt(map, i, i, intensity, biome);
                    }
                    break;
                case Option.THREE:
                    for (int i = 1; i < map.GetLength(0) - 1; i++)
                    {
                        DevelopAt(map, i, (map.GetLength(0) -2) / 2, intensity, biome);
                    }
                    break;
                case Option.FOUR:
                    for (int i = 1; i < map.GetLength(1) - 1; i++)
                    {
                        DevelopAt(map, (map.GetLength(0) - 2) / 2, i, intensity, biome);
                    }
                    break;
            }
        }
    }
}
