using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;

class Game
{
    private Board Board;
    private ArrayList List;
    private Queue<Character> TurnQueue;
    private Character CurrentCharacter;
    private int CurrentCharacterIndex = 0;


    public Game()
    {
        Board = new Board();
        List = Board.GetBoardedCharacters();
        Board.GenerateMap(Global.Rows, Global.Columns);
        //Board.Mountainous();
        Board.Oceanic();
        TurnQueue = new Queue<Character>();
    }
    public Character GetCurrentCharacter()
    {
        return TurnQueue.Peek();
    }
    /// <summary>
    /// Gets a tile at the given x,y coordinate.
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    public Tile GetBoardTile(int x, int y)
    {
        return Board.GetTile(x, y);
    }
    /// <summary>
    /// Initializes the character to the board at a particular location.
    /// </summary>
    /// <param name="name_of_entity"></param>
    /// <param name="class_of_entity"></param>
    /// <param name="row"></param>
    /// <param name="col"></param>
    public void InitCharacter(string name_of_entity, string class_of_entity, int row, int col)
    {
        TurnQueue.Enqueue(Board.InitCharacter(name_of_entity, class_of_entity, row, col));
        //CurrentCharacter = list.Get(CurrentCharacterIndex);
    }
    /// <summary>
    /// Returns the lenght of the given board dimension.
    /// </summary>
    /// <param name="dimension"></param>
    /// <returns></returns>
    public int GetBoardLength(int dimension)
    {
        return Board.GetBoardSize(dimension);
    }
    /// <summary>
    /// Moves the given character given a direction.
    /// </summary>
    /// <param name="f"></param>
    /// <param name="direction"></param>
    public void MoveCharacter(PictureBox f, Direction direction)
    {
        ArrayList tiles = new ArrayList();
        Tile userSelectedTile;
        Character character = TurnQueue.Dequeue();

        if (character.GetOccuableTileQuantity() < 0) { return; }

        for (int i = 0; i < character.GetOccuableTileQuantity(); i++)
        {
            tiles.Add(character.GetOccuableTile(i));
        }

        userSelectedTile = TileLogic.TileRespectingDirection(character.TILE_OF_ENTITY, tiles, direction);

        Board.MoveCharacter(character, userSelectedTile);

        f.Refresh();
        f.Update();

        TurnQueue.Enqueue(character);
    }
    private void SetTilesOnTileBox(ComboBox tile_box)
    {
        tile_box.Items.Clear();
        for (int i = 0; i < TurnQueue.Peek().GetOccuableTileQuantity(); i++)
        {
            tile_box.Items.Add(TurnQueue.Peek().GetOccuableTile(i).ToCoordinate());
        }
        Console.WriteLine(TurnQueue.Peek().OccuableTilesToString());
    }
    //private void AdjustTeamDisplay()
    public void UpdateController(ComboBox tileBox, TextBox teamDisplay)
    {
        SetTilesOnTileBox(tileBox);
    }
}
