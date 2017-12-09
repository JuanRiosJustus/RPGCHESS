using System;
using Apocrypha;
using System.Collections;

class Board
{
    private Tile[,] map;
    private Random random = new Random();
    private ArrayList list = new ArrayList();

    public ArrayList GetBoardedCharacters()
    {
        return list;
    }
    /// <summary>
    /// Adds a character to the list of characters contained by this board.
    /// </summary>
    /// <param name="character"></param>
    /// <param name="row"></param>
    /// <param name="col"></param>
    public void AddCharacter(Character character, int row, int col)
    {
        if (list.Contains(character) == false)
        {
            list.Add(character);
        }

        Tile tile = map[row, col];
        while (tile.IsOccupied() || tile.Biome.Equals("WTR"))
        {
            row = random.Next(Global.Rows);
            col = random.Next(Global.Columns);
            tile = map[row, col];
        }
        
        map[row, col].SetOccupant(character);
        TileLogic.AddOccuableTilesToEntity(map, character);
    }
    /// <summary>
    /// Used on game start to initialize a characte rand place them on board.
    /// </summary>
    /// <param name="name_of_entity"></param>
    /// <param name="class_of_entity"></param>
    /// <param name="row"></param>
    /// <param name="col"></param>
    public Character InitCharacter(string name_of_entity, string class_of_entity, int row, int col)
    {
        Character charac = EntityFactory.BuildCharacter(name_of_entity, class_of_entity);

        Console.WriteLine(charac.Status() + " has joined the field. AT@[" + col + "," + row + "]");

        this.AddCharacter(charac, row, col);

        return charac;
    }
    /// <summary>
    /// Removes the character from it's current tile and 
    /// sets it to a new tile.
    /// </summary>
    /// <param name="character"></param>
    /// <param name="newTile"></param>
    public void MoveCharacter(Character character, Tile newTile)
    {
        if (newTile == null) { return; }
        Tile tile = character.TILE_OF_ENTITY;
        tile.RemoveOccupant();

        newTile.SetOccupant(character);
        character.ClearOccuableTiles();
        TileLogic.AddOccuableTilesToEntity(map, character);
    }
    /// <summary>
    /// Gets the board size of the given dimension.
    /// </summary>
    /// <param name="dimension"></param>
    /// <returns></returns>
    public int GetBoardSize(int dimension)
    {
        return map.GetLength(dimension);
    }
    /// <summary>
    /// Retrieves the tile of the given x and y????
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
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
                tiles[row, column] = new Tile(row, column, height);
            }
        }
        map = tiles;
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
        BoardDesigner.DevelopAt(map, row, col, intensity);
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