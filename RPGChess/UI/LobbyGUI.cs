using System;
using System.Windows.Forms;

public partial class LobbyGUI : Form
{
    public LobbyGUI()
    {
        InitializeComponent();
        SetUp();
    }
    /// <summary>
    /// Occurs when the class combox is dropped down.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ClassCombobox_DropDownClosed(object sender, EventArgs e)
    {
        Archetype a = (Archetype)this.ClassList[this.ClassList.IndexOf(this.ClassCombobox.SelectedItem)];
        string stats = "[HP: " + a.Health + "][DMG: " + a.Damage + "][RNGE: " + a.Range + "][MVMT: " + a.Movement + "]";
        this.classType = a.Type;
        this.StatsTextbox.Text = stats;
        this.CheckIfFullTeam();
    }
    /// <summary>
    /// Occurs when the name text box is entered.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void OnTextEnter_click(object sender, EventArgs e)
    {
        this.NameTextbox.Clear();
    }
    /// <summary>
    /// Occurs when the import button is clicked.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ImportToTeam_click(object sender, EventArgs e)
    {
        if (classType != null && classType.Length > 0 && this.ImortToTeamButton.Text.Length > 0)
        {
            Character c = EntityFactory.BuildCharacter(this.NameTextbox.Text, classType, Relation.Friendly);
            c.SetRelation(Relation.Friendly);
            this.CurrentTeam.Add(c);

            Console.WriteLine(c + " was created");
        }
        this.CheckIfFullTeam();

        this.TeamTextbox.Clear();
        foreach (Character c in CurrentTeam)
        {
            this.TeamTextbox.AppendText(c + "\n");
        }
    }
    /// <summary>
    /// Occurs when the remove newest button is clicked.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void RemoveLatest_click(object sender, EventArgs e)
    {
        if (CurrentTeam.Count > 0)
        {
            this.CurrentTeam.RemoveAt(this.CurrentTeam.Count - 1);
            Console.WriteLine("REMOVED");
        }
        this.CheckIfFullTeam();

        this.TeamTextbox.Clear();
        foreach (Character c in CurrentTeam)
        {
            this.TeamTextbox.AppendText(c + "\n");
        }
    }
    public void ConnectButton_click(object sender, EventArgs e)
    {
        foreach (Character c in CurrentTeam)
        {
            Metadata.Player1Instance().AddCharacterToTeam(c);
        }
        Metadata.IsLocalHost(this.TopCheckbox.AutoCheck);
        Metadata.Player1Instance().SetName(UsernameTextbox.Text);
        this.Close();
    }
}