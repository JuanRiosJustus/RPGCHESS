public class BoardDesigner
{
    /// <summary>
    /// Develops the hight arount a certain cordinate on a given map.
    /// </summary>
    /// <param name="map"></param>
    /// <param name="row"></param>
    /// <param name="col"></param>
    /// <param name="intensity"></param>
    public static void DevelopAt(Tile[,] map, int row, int col, int intensity)
    {
        bool aboveBottomEdge = false, belowTopEdge = false, leftOfRightEdge = false, rightOfLeftEdge = false;
        map[row, col].SetHeight(map[row, col].Height + intensity);
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
}