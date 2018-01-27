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
        /*
        Metadata.IsLocalHost(false);
        Player p1 = Metadata.Player1Instance();
        p1.SetName("Justus");
        Player p2 = Metadata.Player2Instance();
        p2.SetName("The enemy");
        p1.AddCharacterToTeam(EntityFactory.BuildCharacter("Gaebulg", "Warrior", Relation.Friend));
        p1.AddCharacterToTeam(EntityFactory.BuildCharacter("Aystogon", "Mage", Relation.Friend));
        p1.AddCharacterToTeam(EntityFactory.BuildCharacter("Seth", "Ranger", Relation.Friend));
        p2.AddCharacterToTeam(EntityFactory.BuildCharacter("Artyomodon", "Warrior", Relation.Foe));
        p2.AddCharacterToTeam(EntityFactory.BuildCharacter("Riven", "Monk", Relation.Foe));
        p2.AddCharacterToTeam(EntityFactory.BuildCharacter("Wrathlos", "Rogue", Relation.Foe));
        */

        if (Lobby == null)
        {
            Hide();
            Lobby = new LobbyGUI(Data);
            Lobby.Closed += (s, args) =>
            {
                this.Show();
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