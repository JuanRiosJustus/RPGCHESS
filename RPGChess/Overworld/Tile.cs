using RPGChess.Entities;
using RPGChess.Entities.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGChess.Overworld
{
    class Tile
    {
        public class ScreenObject
        {
            private int X;
            private int Y;
            private int WH;

            public int GetX() { return X; }
            public int GetY() { return Y; }
            public int GetWH() { return WH; }
            public void SetX(int x) { X = x; }
            public void SetY(int y) { Y = y; }
            public void SetWH(int wh) { WH = wh; }
        }

        public readonly int ROW;
        public readonly int COL;
        public int Height { get; private set; }
        public string Biome { get; private set; }
        public Item Loot { get; private set; }
        public Entity Occupant { get; private set; }

        public ScreenObject Screen{ get; private set; }
        
        

        public Tile(int row, int col, int height, Entity occupant)
        {
            ROW = row;
            COL = col;
            //Height = height;
            SetHeight(height);
            Occupant = occupant;
            Screen = new ScreenObject();
        }
        private void AdjustBiome()
        {
            if (this.Height <= -3)
            {
                // Water
                Biome = "WTR";
            }
            else if (this.Height > -3 && this.Height <= -1)
            {
                // Lowlands
                Biome = "LWL";
            }
            else if (this.Height > -1 && this.Height <= 1)
            {
                // Plains
                Biome = "PLN";
            }
            else if(this.Height > 1 && this.Height <= 3)
            {
                // Forest
                Biome = "FRS";
            }
            else if (this.Height > 3 && this.Height <= 5)
            {
                // Hill
                Biome = "HLL";
            }
            else if (this.Height > 5)
            {
                // Mountain
                Biome = "MTN";
            }
        }
        public void SetScreenXY(int x, int y)
        {
            // swapped values, for drawing only
            Screen.SetX(y);
            Screen.SetY(x);
        }
        public void SetSceenTileSize(int wh)
        {
            Screen.SetWH(wh);
        }
        public int GetScreenWH() { return Screen.GetWH(); }
        public int GetScreenX() { return Screen.GetX(); }
        public int GetScreenY() { return Screen.GetY(); }

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
        /// Sets the item of the tile.
        /// </summary>
        /// <param name="loot"></param>
        public void SetLoot(Item loot)
        {
            Loot = loot;
        }
        public Item LootTile()
        {
            Item temp = Loot;
            Loot = null;
            return temp;
        }
        /// <summary>
        /// Sets the height for the current tile.
        /// </summary>
        /// <param name="height"></param>
        public void SetHeight(int height)
        {
            Height = height;
            AdjustBiome();
        }
        /// <summary>
        /// Returns true if and only if the current tile already has another occupant.
        /// </summary>
        /// <returns></returns>
        public bool IsOccupied()
        {
            return (Occupant == null ? false : true);
        }

        public string ToCoordinate()
        {
            return "[" + COL + "," + ROW + "]";
        }
        public string ToTopograph()
        {
            return "[" + Height + "]";
        }
        public string ToBiome()
        {
            return "[" + Biome + "]";
        }
        public string ToLevel()
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
        }
        public string ToStandard()
        {
            if (IsOccupied())
            {
                return "[XXX]";
            }
            else
            {
                return ToBiome();
            }
        }
        public string ToScreen()
        {
            return (IsOccupied() ? "[X]" : ToTopograph());
        }
        public override string ToString()
        {
            return ToCoordinate();//Height + "";
        }
    }
}
