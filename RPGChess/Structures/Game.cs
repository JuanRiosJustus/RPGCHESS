using System.Collections.Generic;
using System.Windows.Forms;

/// <summary>
/// The definition of a game.
/// </summary>
public class Game
{
    private Board ConnectedBoard;
    private Character FocusedCharacter;
    private Player P1;
    private Player P2;
    private Queue<Player> TurnOrder;
    private int Actions;
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

        ConnectedBoard = new Board(BoardType.Default);

        ConnectedControllerGUI = new ControllerGUI(this);

        ConnectedControllerGUI.Show();
        ConnectedGameGUI = connectedGameGUI;

        InitManager.DetermineTurnOrder(P1, P2, TurnOrder);
        InitManager.SetCharactersOnBoard(P1, P2, ConnectedBoard);

        Actions = 0;
        ConnectedControllerGUI.RefreshTeamTextBox();

        ConnectedGameGUI.FormClosing += new FormClosingEventHandler(ConnectedControllerGUI.ForceDispose);
    }
    /// <summary>
    /// Determines if the turn is over.
    /// </summary>
    /// <returns></returns>
    public bool TurnIsOver()
    {
        return Actions == Global.ActionsPerTurn;
    }
    /// <summary>
    /// Resets the actions taken to refresh the turn.
    /// </summary>
    public void ResetTurn()
    {
        Actions = 0;
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
    /// Returns a single tile from the board given a row and column,
    /// </summary>
    /// <param name="row">row of the tile.</param>
    /// <param name="col">column of the tile.</param>
    /// <returns></returns>
    public Tile GetBoardTile(int row, int col)
    {
        return ConnectedBoard.GetTile(row, col);
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
    /// Moves the given character given a direction.
    /// </summary>
    /// <param name="f"></param>
    /// <param name="direction"></param>
    public void MoveCharacter(Character cha, Tile newTile)
    {
        Tile t = cha.TileOfEntity;
        ConnectedControllerGUI.RefreshTeamTextBox();
        ConnectedBoard.MoveEntity(cha, newTile);
        
        UpdateMainTextBoxes(cha);
        ConnectedControllerGUI.AppendToGameLog(cha.NameEmphasized() +
            " has moved from " + t.ToPosition() + " to " + cha.TileOfEntity.ToPosition());
        CheckForTargetableEntities(cha);
        
        string str = AuxiliaryInputManager.AuxiliaryText(cha);
        
        ConnectedControllerGUI.RewriteAuxiliaryTextBox(str);
        ConnectedControllerGUI.RefreshTeamTextBox();
        ConnectedControllerGUI.RewriteMainUnitInfo(cha);

        EndOfTurn();
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
    /// <summary>
    /// Prints the available targetable entities of the given entity.
    /// </summary>
    /// <param name="c"></param>
    private void CheckForTargetableEntities(Character c)
    {
        List<Entity> targets = ConnectedBoard.GetTargetableEntities(c);
        for (int i = 0; i < targets.Count; i++)
        {
            Entity k = targets[i];
            if (k != c)
            {
                ConnectedControllerGUI.AppendToGameLog(c.NameEmphasized() + " can target " + k.NameOfEntity);
            }
        }
    }
    /// <summary>
    /// Displayers all the data of the given character to the controller.
    /// </summary>
    /// <param name="c"></param>
    public void Focus(Character c)
    {
        UpdateMainTextBoxes(c);
        ConnectedControllerGUI.RewriteAuxiliaryTextBox(c.NameOfEntity + " was selected.");
        if (FocusedCharacter == null)
        {
            ConnectedControllerGUI.AppendToGameLog(c.NameEmphasized() + " was selected.");
        }
        UpdateLeadTextBoxes(null);
        ConnectedControllerGUI.RewriteMainUnitInfo(c);
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
    public void CharacterCombat(Character attacker, Character defender, MouseEventArgs e)
    {
        if (attacker == null || defender == null) { return; }
        ConnectedControllerGUI.RefreshTeamTextBox();
        ConnectedControllerGUI.AppendToGameLog(attacker.NameEmphasized() + " attacked " + defender.NameOfEntity);

        /// combat happens
        /// 

        CombatResult cr = CombatManager.Combat(attacker, defender, e);

        if (defender.IsDead()) { attacker.GainExp(defender.Damage); }
        /// update result textbox
        /// 
        UpdateMainTextBoxes(attacker);
        UpdateLeadTextBoxes(defender);
        string s = FormatCombatString(attacker, defender, cr);
        ConnectedControllerGUI.RewriteAuxiliaryTextBox(s);
        ConnectedControllerGUI.AppendToGameLog(s);
        ConnectedControllerGUI.RefreshTeamTextBox();
        ConnectedControllerGUI.RewriteMainUnitInfo(attacker);
        EndOfTurn();
        if (defender.IsDead()) { ConnectedControllerGUI.AppendToGameLog(defender.NameOfEntity + " died."); }
    }
    /// <summary>
    /// Returns a formated string for output based on given input.
    /// </summary>
    /// <param name="m">main character.</param>
    /// <param name="l">lead character.</param>
    /// <param name="c">combat info</param>
    /// <returns></returns>
    private string FormatCombatString(Character m, Character l, CombatResult c)
    {
        return m.NameOfEntity + " used [ " + c.AttackUsed + " ] for [" + c.DamageDone + " ] damage.";
    }
    /// <summary>
    /// Updates all the textboxes for the selected lead unit.
    /// </summary>
    /// <param name="cha"></param>
    private void UpdateLeadTextBoxes(Character cha)
    {
        ConnectedControllerGUI.RewriteLeadUnitTileTextBox(cha);
        ConnectedControllerGUI.RewriteLeadUnitTextBox(cha);
        ConnectedControllerGUI.RewriteLeadUnitStatusTextBox(cha);
    }
    /// <summary>
    /// Updates all the textboxes for the selected main unit.
    /// </summary>
    /// <param name="cha">unit to select.</param>
    private void UpdateMainTextBoxes(Character cha)
    {
        ConnectedControllerGUI.RewriteMainUnitTextBox(cha);
        ConnectedControllerGUI.RewriteMainTileTextBox(cha);
        ConnectedControllerGUI.RewriteMainUnitStatusTextBox(cha);
    }
    private void CheckForEndTurn()
    {
        if (TurnIsOver())
        {
            ConnectedControllerGUI.AppendToGameLog("End of turn.");
        }
    }
    /// <summary>
    /// Occurs at the end of every turn.
    /// </summary>
    public void EndOfTurn()
    {
        ConnectedBoard.UpdateCharacterState();
        UpdateAndRefreshGameGui();
        IncrementAction();
        Unfocus();
        CheckForEndTurn();
    }
    /// <summary>
    /// Increases the action counter.
    /// </summary>
    private void IncrementAction()
    {
        Actions++;
    }
    /// <summary>
    /// Sets the focued character to null.
    /// </summary>
    public void Unfocus()
    {
        Character c = FocusedCharacter;
        FocusedCharacter = null;
        if (c == null) { return; }
        ConnectedControllerGUI.AppendToGameLog(c.NameEmphasized() + " was deselected.");
    }
    /// <summary>
    /// <see cref="Board.IsOccuableByEntity(Entity, Tile)"/>
    /// Determines if an enetity can traverse to the given tile.
    /// </summary>
    /// <param name="ent">Entity to check.</param>
    /// <param name="newTile">new tlle to look at.</param>
    /// <returns></returns>
    public bool IsOccuableByEntity(Entity ent, Tile newTile)
    {
        return ConnectedBoard.IsOccuableByEntity(ent, newTile);
    }
    /// <summary>
    /// <see cref="Board.GetOccuableTilesFromEntity(Entity)"/>
    /// Returns the list of occuable tile given an entity.
    /// </summary>
    /// <param name="ent">entity to check tile for.</param>
    /// <returns></returns>
    public List<Tile> GetOccuableTilesFromEntity(Entity ent)
    {
        return ConnectedBoard.GetOccuableTilesFromEntity(ent);
    }
    /// <summary>
    /// Checks to see if the first entity can target the second given entity.
    /// </summary>
    /// <param name="ent">first entity doing the action.</param>
    /// <param name="ent2">second entity doing the action.</param>
    /// <returns></returns>
    public bool IsTargetableByEntity(Entity ent, Entity ent2)
    {
        return ConnectedBoard.IsTargetableByEntity(ent, ent2);
    }
}