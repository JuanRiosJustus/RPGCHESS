using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;

/// <summary>
/// 
/// The definition of a game.
/// 
/// </summary>
public class Game
{
    private Board Board;
    private ArrayList List;
    private Queue<Character> TurnQueue;
    private Character CurrentCharacter;
    private int CurrentCharacterIndex = 0;
    private Player P1;
    private Player P2;
    private Queue<Player> TurnOrder;
    private ControllerGUI Controller;
    private PictureBox Visual;

    /// <summary>
    /// Constructor for a game instance.
    /// </summary>
    /// <param name="p1">The first player and local player.</param>
    /// <param name="p2">The second player and the remote player.</param>
    /// <param name="Controller">Input used by the local player.</param>
    public Game(Player p1, Player p2, ControllerGUI c, PictureBox v)
    {
        Board = new Board();
        Controller = c;
        Controller.CreateConnectionWithGame(this);
        Visual = v;
        P1 = p1;
        P2 = p2;
        TurnOrder = GameInitLogic.DecideTurnOrder(p1, p2);
        GameInitLogic.SetCharactersOnBoard(p1, p2, Board);

        List = Board.GetBoardedCharacters();
        Board.Mountainous();
        //Board.Oceanic();
        TurnQueue = new Queue<Character>();


        Controller.HardUpdate();
        //InitializeBoard();
    }
    public Character GetCurrentCharacter()
    {
        return TurnQueue.Peek();
    }
    /// <summary>
    /// Gets a tile at the given x,y coordinate.
    /// </summary>
    /// <param name="x">X coordinate of the tile.</param>
    /// <param name="y">Y coordinate of the tile</param>
    /// <returns></returns>
    public Tile GetBoardTile(int x, int y)
    {
        return Board.GetTile(x, y);
    }
    public void InitializeCharacter(Character character, int row, int col)
    {
        if (Board.AddCharacterToBoard(character, row, col))
        {
            //TurnQueue.Enqueue(Board.InitCharacter(name_of_entity, class_of_entity, row, col));
        }
        else
        {
            throw new Exception("ERROR: Character already added.");
        }
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
    public void MoveCharacter(Character c, Tile newTile)
    {
        Board.MoveCharacter(c, newTile);
        Visual.Update();
        Visual.Refresh();
    }
    public void AttackCharacter()
    {

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
}
