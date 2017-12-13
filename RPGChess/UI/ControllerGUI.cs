using System.Windows.Forms;
using System;

/// <summary>
/// Defines the controls for interacting with the game.
/// </summary>
public partial class ControllerGUI : Form
{
    public ControllerGUI(Player p1)
    {
        InitializeComponent();
        Player1 = p1;
    }
    public void SetAssociatedBoard(Form associatedBoard)
    {
        this.AssociatedBoard = associatedBoard;
    }
    /// <summary>
    /// Adds a tile to the tile combobox.
    /// </summary>
    /// <param name="obj"></param>
    public void AddToTileBox(string tilecoordinate)
    {
        this.AttackComboBox.Items.Add(tilecoordinate);
    }
    /// <summary>
    /// Clears all the items inside the tilebox.
    /// </summary>
    public void ClearTileBox()
    {
        this.AttackComboBox.Items.Clear();
    }
    /// <summary>
    /// Returns the tilebox of this form.
    /// </summary>
    /// <returns></returns>
    public ComboBox GetTileComboBox()
    {
        return AttackComboBox;
    }
    private void AcceptingButton_Click(object sender, EventArgs e)
    {

        Console.WriteLine("WOW THIS WAS PRESSED");
    }
    /// <summary>
    /// Returns the controllers textbox.
    /// </summary>
    /// <returns></returns>
    public TextBox GetTeamTextBox()
    {
        return TeamTexbox;
    }
    /// <summary>
    /// Clears the text box.
    /// </summary>
    public void ClearTeamTextBox()
    {
        TeamTexbox.Clear();
    }
    /// <summary>
    /// Returns the combox of selectable characters.
    /// </summary>
    /// <returns></returns>
    public ComboBox GetTeamComboBox()
    {
        return TeamComboBox;
    }
    /// <summary>
    /// Clears the character combobox.
    /// </summary>
    public void ClearCharacterComboBox()
    {
        TeamComboBox.Items.Clear();
    }
    /// <summary>
    /// Clears the tile combobox
    /// </summary>
    public void ClearTilesComboBox()
    {
        TilesComboBox.Items.Clear();
    }
}