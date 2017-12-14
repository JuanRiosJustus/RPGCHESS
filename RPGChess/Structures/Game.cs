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
    private List<Character> ListOfEveryCharacter;
    private Queue<Character> TurnQueue;
    private Character CurrentCharacter;
    private int CurrentCharacterIndex = 0;
    private Player P1;
    private Player P2;
    private Queue<Player> TurnOrder;
    private ControllerGUI Controller;
    private PictureBox Visual;
    private BoardGUI board1;

    /// <summary>
    /// Constructor for a game instance.
    /// </summary>
    /// <param name="p1">The first player and local player.</param>
    /// <param name="p2">The second player and the remote player.</param>
    /// <param name="Controller">Input used by the local player.</param>
    public Game(Player p1, Player p2, ControllerGUI c, PictureBox v, BoardGUI b)
    {
        board1 = b;
        Board = new Board(ListOfEveryCharacter);
        Controller = c;
        Controller.CreateConnectionWithGame(this);
        Visual = v;
        P1 = p1;
        P2 = p2;
        TurnOrder = GameInitLogic.DecideTurnOrder(p1, p2);
        GameInitLogic.SetCharactersOnBoard(p1, p2, Board);
        
        Board.Mountainous();
        //Board.Oceanic();
        TurnQueue = new Queue<Character>();


        Controller.RefreshTeamTextBox();
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
    /// <summary>
    /// 
    /// </summary>
    public void ResetTurn()
    {
        board1.RRfresh();
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
}
