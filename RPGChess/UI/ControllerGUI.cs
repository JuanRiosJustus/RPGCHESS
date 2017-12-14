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
    private void AcceptingButton_Click(object sender, EventArgs e)
    {

        Console.WriteLine("WOW THIS WAS PRESSED");
    }
}