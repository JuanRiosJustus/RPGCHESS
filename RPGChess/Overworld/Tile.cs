using RPGChess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGChess.Overworld
{
    class Tile
    {
        public readonly int X;
        public readonly int Y;
        public int Height { get; private set; }
        public string Biome { get; private set; }
        public Entity Occupant { get; private set; }

        public Tile(int x, int y, int height, string biome, Entity occupant)
        {
            X = x;
            Y = y;
            Height = height;
            Biome = biome;
            Occupant = occupant;
        }

        /// <summary>
        /// Sets the current occupant of the tile. Which also sets the
        /// occupants tile reference to this tile.
        /// </summary>
        /// <param name="occupant"></param>
        public void SetOccupant(Entity occupant)
        {
            Occupant = occupant;
            if (Object.ReferenceEquals(Occupant.EntityTile, this) == false)
            {
                Occupant.SetTile(this);
            }
        }
        /// <summary>
        /// Sets the biome of the current tile.
        /// </summary>
        /// <param name="biome"></param>
        public void SetBiome(string biome)
        {
            Biome = biome;
        }
        /// <summary>
        /// Sets the height for the current tile.
        /// </summary>
        /// <param name="height"></param>
        public void SetHeight(int height)
        {
            Height = height;
        }
        /// <summary>
        /// Returns true if and only if the current tile already has another occupant.
        /// </summary>
        /// <returns></returns>
        public bool IsOccupied()
        {
            return (Occupant == null ? false : true);
        }

        public string PrintCoordinate()
        {
            return "[" + X + "," + Y + "]";
        }
        public string PrintTopograph()
        {
            return "[" + Height + "]";
        }
        public string PrintBiome()
        {
            return "[" + Biome + "]";
        }
        public string PrintStandard()
        {
            if (Height < 0)
            {
                return "[" + "L" + "]";
            }
            else if (Height < 5)
            {
                return "[" + "M" + "]";
            }
            else
            {
                return "[" + "H" + "]";
            }
            //return "[" + Height + Biome[0] + (IsOccupied() ? "X" : "O") + "]";
        }

        public override string ToString()
        {
            return Height + "";
        }
    }
}
