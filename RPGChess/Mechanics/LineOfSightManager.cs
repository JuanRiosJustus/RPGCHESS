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

        int range = ent.ClassOfEntity.Range;
        Tile currentTile = ent.TileOfEntity;

        for (int row = currentTile.Row - range; row <= currentTile.Row + range; row++)
        {
            for (int col = currentTile.Column - range; col <= currentTile.Column + range; col++)
            {
                int realrow = TileManager.WrapNumber(row, Global.Rows);
                int realcol = TileManager.WrapNumber(col, Global.Columns);
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