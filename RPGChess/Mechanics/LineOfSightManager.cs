using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class LineOfSightManager
{
    /// <summary>
    /// Returns the list of targetable entities of the given entity, based of the given map.
    /// </summary>
    /// <param name="map">map to check.</param>
    /// <param name="ent">entity to check for.</param>
    /// <returns></returns>
    public static List<Entity> TargetableEntities(Tile[,] map, Entity ent)
    {
        List<Entity> targetableEntities = new List<Entity>();

        int range = ent.CLASS_OF_ENTITY.RANGE;
        Tile currentTile = ent.TILE_OF_ENTITY;

        for (int row = currentTile.Row - range; row <= currentTile.Row + range; row++)
        {
            for (int col = currentTile.Column - range; col <= currentTile.Column + range; col++)
            {
                int realrow = TileManager.WrapNumber(row, Global.ROWS);
                int realcol = TileManager.WrapNumber(col, Global.COLUMNS);
                Tile t = map[realrow, realcol];

                if (t.IsOccupied() == false)
                {
                    continue;
                }
                if (TileManager.IsInHeight(currentTile, t) == false)
                {
                    continue;
                }

                Character c = (Character)t.Occupant;
                targetableEntities.Add(c);
            }
        }
        return targetableEntities;
    }
}