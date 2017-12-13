using System;
using System.Windows.Forms;

public partial class GUI : Form
{
    public GUI()
    {
        InitializeComponent();
    }

    /// <summary>
    /// Launches the lobby where a player will need to search for a game given an ip.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void FirstButton_click(object sender, EventArgs e)
    {
        if (Lobby == null && Board == null)
        {
            Hide();
            Lobby = new LobbyGUI();
            Lobby.Closed += (s, args) =>
            {
                Board = new BoardGUI(new Player(Relation.Friendly), new Player(Relation.Enemy));
                Board.Closed += (s1, args1) =>
                {
                    Lobby = null;
                    Board = null;
                    Show();
                };
                Board.Show();
            };
            Lobby.Show();
        }
    }
    private void SecondButton_click(object sender, EventArgs e)
    {
        Console.WriteLine("THIS WILL OPEN THE TUT/HELP WINDOW.");
    }
    private void ThirdButton_click(object sender, EventArgs e)
    {
        Console.WriteLine("THIS WILL OPEN THE SETTINGS WINDOW.");
    }
    /// <summary>
    /// The exit button, exits the program.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void FourthButton_click(object sender, EventArgs e)
    {
        Environment.Exit(0);
    }
    private void ClosingButton_click(object sender, EventArgs e)
    {
        Application.Exit();
        Environment.Exit(0);
    }
}