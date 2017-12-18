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
    private Board ConnectedBoard;
    private List<Character> ListOfEveryCharacter;
    private Queue<Character> TurnQueue;
    private Character FocusedCharacter;
    private int CurrentCharacterIndex = 0;
    private Player P1;
    private Player P2;
    private Queue<Player> TurnOrder;
    private int ActionsTaken;
    private ControllerGUI ConnectedControllerGUI;
    private GameGUI ConnectedGameGUI;

    /// <summary>
    /// Constructor for a game instance.
    /// </summary>
    /// <param name="p1">The first player and local player.</param>
    /// <param name="p2">The second player and the remote player.</param>
    /// <param name="Controller">Input used by the local player.</param>
    public Game(GameGUI connectedGameGUI)
    {
        P1 = Metadata.Player1Instance();
        P2 = Metadata.Player2Instance();

        ConnectedBoard = new Board();

        ConnectedControllerGUI = new ControllerGUI(this);

        ConnectedControllerGUI.Show();
        ConnectedGameGUI = connectedGameGUI;
        
        GameInitialization.DetermineTurnOrder(P1, P2, TurnOrder);
        GameInitialization.SetCharactersOnBoard(P1, P2, ConnectedBoard);

        ConnectedBoard.Mountainous();
        //ConnectedBoard.Oceanic();

        ActionsTaken = 0;
        ConnectedControllerGUI.RefreshTeamTextBox();

        ConnectedGameGUI.FormClosing += new FormClosingEventHandler(ConnectedControllerGUI.ForceDispose);
    }
    /// <summary>
    /// Determines if the current game is over
    /// returns true if and only if a team has no more characters.
    /// </summary>
    /// <returns></returns>
    public bool GameIsOver()
    {
        if (P1.TeamSize() == 0 || P2.TeamSize() == 0)
        {
            return true;
        }
        return false;
    }
    /// <summary>
    /// Gets a tile at the given x,y coordinate.
    /// </summary>
    /// <param name="x">X coordinate of the tile.</param>
    /// <param name="y">Y coordinate of the tile</param>
    /// <returns></returns>
    public Tile GetBoardTile(int x, int y)
    {
        return ConnectedBoard.GetTile(x, y);
    }
    /// <summary>
    /// Returns the lenght of the given board dimension.
    /// </summary>
    /// <param name="dimension"></param>
    /// <returns></returns>
    public int GetBoardLength(int dimension)
    {
        return ConnectedBoard.GetBoardSize(dimension);
    }
    /// <summary>
    /// Determines if the focused character can attack the given.
    /// </summary>
    /// <param name="defender">character to check.</param>
    /// <returns></returns>
    public bool CheckIfAttackableByFocusedCharcter(Character defender)
    {
        for (int i = 0; i < FocusedCharacter.GetAttackableCharacterQuantity(); i++)
        {
            if (FocusedCharacter.GetAttackableEntity(i) == defender)
            {
                return true;
            }
        }
        return false;
    }
    /// <summary>
    /// Moves the given character given a direction.
    /// </summary>
    /// <param name="f"></param>
    /// <param name="direction"></param>
    public void MoveCharacter(Character c, Tile newTile)
    {
        Tile t = c.TILE_OF_ENTITY;
        ConnectedBoard.MoveCharacter(c, newTile);
        
        ConnectedControllerGUI.RewriteSelectedUnitToTextBox(newTile);
        ConnectedControllerGUI.AppendToGameLog(c.NAME_OF_ENTITY + " has moved from " + t.ToCoordinate() + " to " + c.TILE_OF_ENTITY.ToCoordinate());
        CheckTargetableCharacters(c);

        FocusedCharacter = null;
        ActionsTaken++;

        UpdateAndRefreshGameGui();
        ConnectedControllerGUI.RefreshTeamTextBox();
    }
    /// <summary>
    /// Updates and refreshes the picturebox of the gui.
    /// </summary>
    private void UpdateAndRefreshGameGui()
    {
        ConnectedGameGUI.GetDisplay().Update();
        ConnectedGameGUI.GetDisplay().Refresh();
    }
    /// <summary>
    /// appends the game status to the controller.
    /// </summary>
    /// <returns></returns>
    public void AppendToGameLog(string str)
    {
        ConnectedControllerGUI.AppendToGameLog(str);
    }
    private void CheckTargetableCharacters(Character c)
    {
        for (int i = 0; i < c.GetAttackableCharacterQuantity(); i++)
        {
            Character k = c.GetAttackableEntity(i);
            ConnectedControllerGUI.AppendToGameLog(c.NAME_OF_ENTITY + " can target " + k.NAME_OF_ENTITY);
        }
    }
    /// <summary>
    /// Displayers all the data of the given character to the controller.
    /// </summary>
    /// <param name="c"></param>
    public void SelectCharacter(Character c)
    {
        ConnectedControllerGUI.RewriteSelectedUnitTextBox(c);
        ConnectedControllerGUI.RewriteExpTextBox(c);
        ConnectedControllerGUI.RewriteSelectedUnitStatusTextBox(c);
        ConnectedControllerGUI.RewriteSelectedUnitFromTextBox(c);
        
        if (FocusedCharacter == null)
        {
            ConnectedControllerGUI.AppendToGameLog(c.NAME_OF_ENTITY + " was selected.");
        }

        FocusedCharacter = c;
    }
    /// <summary>
    /// Returns true if and only if their is a currently focused character.
    /// </summary>
    /// <returns></returns>
    public bool IsFocusing()
    {
        return FocusedCharacter != null;
    }
    /// <summary>
    /// Returns the focused character.
    /// </summary>
    /// <returns></returns>
    public Character GetFocusedCharcter() { return FocusedCharacter; }
    /// <summary>
    /// Shows the combat of two characters to the controller.
    /// </summary>
    /// <param name="attacker"></param>
    /// <param name="defender"></param>
    public void CharacterCombat(Character attacker, Character defender)
    {
        if (attacker == null || defender == null) { return; }
        ConnectedControllerGUI.RefreshTeamTextBox();
        ConnectedControllerGUI.RewriteSelectedUnitTextBox(attacker);
        ConnectedControllerGUI.RewriteExpTextBox(attacker);
        ConnectedControllerGUI.RewriteSelectedUnitStatusTextBox(attacker);
        ConnectedControllerGUI.RewriteDefendingUnitTextBox(defender);
        ConnectedControllerGUI.RewriteDefendingUnitStatus(defender);
        ConnectedControllerGUI.AppendToGameLog(attacker.NAME_OF_ENTITY + " attacked " + defender.NAME_OF_ENTITY);

        /// combat happens
        /// 

        /// update result textbox
        /// 

        FocusedCharacter = null;
        ActionsTaken++;
    }
    /// <summary>
    /// Determines if the turn is over.
    /// </summary>
    /// <returns></returns>
    public bool TurnIsOver()
    {
        return ActionsTaken >= Global.ACTIONSPERTURN;
    }
    /// <summary>
    /// Resets the actions taken to refresh the turn.
    /// </summary>
    public void ResetTurn()
    {
        ActionsTaken = 0;
    }
}
