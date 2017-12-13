using System;
using Apocrypha;
using System.Collections;

public class Board
{
    private Tile[,] Map;
    private Random random = new Random();
    private ArrayList list = new ArrayList();

    public Board()
    {
        GenerateMap(Global.Rows, Global.Columns);
    }
    public ArrayList GetBoardedCharacters()
    {
        return list;
    }
    /// <summary>
    /// <para>Adds a character to the list of characters contained by this board.
    /// If the list holds an instance of the given character, returns false
    /// and does not do anything.</para>
    /// 
    /// <para> If the tile is not already occupied, tile is set to the character.
    /// Otherwise, a random tile is selected.</para>
    /// </summary>
    /// <param name="character">Character to be added.</param>
    /// <param name="row">Row to add the character to.</param>
    /// <param name="col">Column to add the character to.</param>
    /// <returns></returns>
    public bool AddCharacterToBoard(Character character, int row, int col)
    {
        if (list.Contains(character) == false)
        {
            list.Add(character);

            Tile tile = Map[row, col];

            while (tile.IsOccupied())
            {
                row = random.Next(Global.Rows);
                col = random.Next(Global.Columns);
                tile = Map[row, col];
            }

            tile.SetOccupant(character);
            TileLogic.AddOccuableTilesToEntity(Map, character);
            Console.WriteLine(character.NAME_OF_ENTITY + " was added at " + tile.ToCoordinate());
            return true;
        }

        return false;
    }
    /// <summary>
    /// Removes the character from it's current tile and 
    /// sets it to a new tile.
    /// </summary>
    /// <param name="character">Character to be moved.</param>
    /// <param name="newTile">New tile to traverse to.</param>
    public void MoveCharacter(Character character, Tile newTile)
    {
        if (newTile == null) { return; }
        Tile tile = character.TILE_OF_ENTITY;
        tile.RemoveOccupant();

        newTile.SetOccupant(character);
        character.ClearOccuableTiles();
        TileLogic.AddOccuableTilesToEntity(Map, character);
        TileLogic.AddAttackableEntitiesToEntity(Map, character);
    }
    /// <summary>
    /// Gets the board size of the given dimension.
    /// </summary>
    /// <param name="dimension"></param>
    /// <returns></returns>
    public int GetBoardSize(int dimension)
    {
        return Map.GetLength(dimension);
    }
    /// <summary>
    /// Retrieves the tile of the given x and y????
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    public Tile GetTile(int x, int y)
    {
        return Map[x, y];
    }
    /// <summary>
    /// Generates a basic and the default map given a size.
    /// </summary>
    /// <param name="mapsize"></param>
    /// <returns></returns>
    private void GenerateMap(int map_rows, int map_cols)
    {
        Tile[,] tiles = new Tile[map_rows, map_cols];

        for (int row = 0; row < tiles.GetLength(0); row++)
        {
            for (int column = 0; column < tiles.GetLength(1); column++)
            {
                int height = random.Next(-1, 1);
                tiles[row, column] = new Tile(row, column, height);
            }
        }
        Map = tiles;
    }
    /// <summary>
    /// Develops terrain specifically at a given terrain
    /// given an intensity.
    /// </summary>
    /// <param name="row"></param>
    /// <param name="col"></param>
    /// <param name="intensity"></param>
    private void GenerateDevelopAt(int row, int col, int intensity)
    {
        BoardDesigner.DevelopAt(Map, row, col, intensity);
    }
    /// <summary>
    /// Generates a mountainous board.
    /// </summary>
    public void Mountainous()
    {
        Random rand = new Random();
        for (int i = 0; i < 270; i++)
        {
            int col = rand.Next(Global.Columns);
            int row = rand.Next(Global.Rows);
            int z = rand.Next(6);
            GenerateDevelopAt(row, col, z);
        }

        for (int i = 0; i < 10; i++)
        {
            int col = rand.Next(Global.Columns);
            int row = rand.Next(Global.Rows);
            int z = rand.Next(-6, 0);
            GenerateDevelopAt(row, col, z);
        }
    }
    /// <summary>
    /// Generates a oceanic board.
    /// </summary>
    public void Oceanic()
    {
        Random rand = new Random();
        for (int i = 0; i < 270; i++)
        {
            int col = rand.Next(Global.Columns);
            int row = rand.Next(Global.Rows);
            int z = rand.Next(-6, 0);
            GenerateDevelopAt(row, col, z);
        }

        for (int i = 0; i < 10; i++)
        {
            int col = rand.Next(Global.Columns);
            int row = rand.Next(Global.Rows);
            int z = rand.Next(6);
            GenerateDevelopAt(row, col, z);
        }
    }
}