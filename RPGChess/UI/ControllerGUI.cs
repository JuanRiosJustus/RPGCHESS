using System.Windows.Forms;
using System;

/// <summary>
/// Defines the controls for interacting with the game.
/// </summary>
public partial class ControllerGUI : Form
{
    public ControllerGUI(Game connectedGame)
    {
        InitializeComponent();

        ConnectedPlayer = Metadata.Player1Instance();
        ConnectedGame = connectedGame;
    }
}