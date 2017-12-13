using System;

/// <summary>
/// Defines the controls for interacting with the game.
/// </summary>
partial class ControllerGUI
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    private System.Windows.Forms.Form AssociatedBoard;

    private System.Windows.Forms.TextBox TeamTexbox;
    private System.Windows.Forms.Label TeamLabel;
    private System.Windows.Forms.Label CurrentLabel;
    private System.Windows.Forms.Label MoveToLabel;
    private System.Windows.Forms.Label AttackLabel;
    private System.Windows.Forms.ComboBox TeamComboBox;
    private System.Windows.Forms.ComboBox AttackComboBox;
    private System.Windows.Forms.TextBox StatsTextbox;
    private System.Windows.Forms.Label StatsLabel;
    private System.Windows.Forms.Button EndButton;
    private System.Windows.Forms.TextBox LogTextbox;
    private System.Windows.Forms.ComboBox TilesComboBox;

    private Player Player1;
    private Game _Game;


    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
            this.AttackComboBox = new System.Windows.Forms.ComboBox();
            this.TeamTexbox = new System.Windows.Forms.TextBox();
            this.TeamLabel = new System.Windows.Forms.Label();
            this.CurrentLabel = new System.Windows.Forms.Label();
            this.MoveToLabel = new System.Windows.Forms.Label();
            this.AttackLabel = new System.Windows.Forms.Label();
            this.TeamComboBox = new System.Windows.Forms.ComboBox();
            this.StatsTextbox = new System.Windows.Forms.TextBox();
            this.StatsLabel = new System.Windows.Forms.Label();
            this.EndButton = new System.Windows.Forms.Button();
            this.LogTextbox = new System.Windows.Forms.TextBox();
            this.TilesComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // AttackComboBox
            // 
            this.AttackComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AttackComboBox.FormattingEnabled = true;
            this.AttackComboBox.Location = new System.Drawing.Point(396, 121);
            this.AttackComboBox.Name = "AttackComboBox";
            this.AttackComboBox.Size = new System.Drawing.Size(242, 21);
            this.AttackComboBox.TabIndex = 14;
            // 
            // TeamTexbox
            // 
            this.TeamTexbox.Location = new System.Drawing.Point(12, 39);
            this.TeamTexbox.Multiline = true;
            this.TeamTexbox.Name = "TeamTexbox";
            this.TeamTexbox.ReadOnly = true;
            this.TeamTexbox.Size = new System.Drawing.Size(260, 136);
            this.TeamTexbox.TabIndex = 8;
            // 
            // TeamLabel
            // 
            this.TeamLabel.AutoSize = true;
            this.TeamLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TeamLabel.Location = new System.Drawing.Point(125, 19);
            this.TeamLabel.Name = "TeamLabel";
            this.TeamLabel.Size = new System.Drawing.Size(46, 17);
            this.TeamLabel.TabIndex = 9;
            this.TeamLabel.Text = "TEAM";
            // 
            // CurrentLabel
            // 
            this.CurrentLabel.AutoSize = true;
            this.CurrentLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CurrentLabel.Location = new System.Drawing.Point(289, 40);
            this.CurrentLabel.Name = "CurrentLabel";
            this.CurrentLabel.Size = new System.Drawing.Size(96, 17);
            this.CurrentLabel.TabIndex = 10;
            this.CurrentLabel.Text = "CHARACTER:";
            // 
            // MoveToLabel
            // 
            this.MoveToLabel.AutoSize = true;
            this.MoveToLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MoveToLabel.Location = new System.Drawing.Point(289, 98);
            this.MoveToLabel.Name = "MoveToLabel";
            this.MoveToLabel.Size = new System.Drawing.Size(52, 17);
            this.MoveToLabel.TabIndex = 12;
            this.MoveToLabel.Text = "MOVE:";
            // 
            // AttackLabel
            // 
            this.AttackLabel.AutoSize = true;
            this.AttackLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AttackLabel.Location = new System.Drawing.Point(289, 125);
            this.AttackLabel.Name = "AttackLabel";
            this.AttackLabel.Size = new System.Drawing.Size(66, 17);
            this.AttackLabel.TabIndex = 13;
            this.AttackLabel.Text = "ATTACK:";
            // 
            // TeamComboBox
            // 
            this.TeamComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TeamComboBox.FormattingEnabled = true;
            this.TeamComboBox.Location = new System.Drawing.Point(396, 40);
            this.TeamComboBox.Name = "TeamComboBox";
            this.TeamComboBox.Size = new System.Drawing.Size(242, 21);
            this.TeamComboBox.TabIndex = 15;
            this.TeamComboBox.DropDownClosed += new System.EventHandler(this.CharacterComboBoxDropdownClosed);
            // 
            // StatsTextbox
            // 
            this.StatsTextbox.Location = new System.Drawing.Point(396, 67);
            this.StatsTextbox.Name = "StatsTextbox";
            this.StatsTextbox.ReadOnly = true;
            this.StatsTextbox.Size = new System.Drawing.Size(242, 20);
            this.StatsTextbox.TabIndex = 16;
            // 
            // StatsLabel
            // 
            this.StatsLabel.AutoSize = true;
            this.StatsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatsLabel.Location = new System.Drawing.Point(289, 70);
            this.StatsLabel.Name = "StatsLabel";
            this.StatsLabel.Size = new System.Drawing.Size(57, 17);
            this.StatsLabel.TabIndex = 17;
            this.StatsLabel.Text = "STATS:";
            // 
            // EndButton
            // 
            this.EndButton.Location = new System.Drawing.Point(292, 148);
            this.EndButton.Name = "EndButton";
            this.EndButton.Size = new System.Drawing.Size(346, 23);
            this.EndButton.TabIndex = 18;
            this.EndButton.Text = "END TURN";
            this.EndButton.UseVisualStyleBackColor = true;
            this.EndButton.Click += new System.EventHandler(this.EndTurnButtonClick);
            // 
            // LogTextbox
            // 
            this.LogTextbox.Location = new System.Drawing.Point(12, 182);
            this.LogTextbox.Multiline = true;
            this.LogTextbox.Name = "LogTextbox";
            this.LogTextbox.ReadOnly = true;
            this.LogTextbox.Size = new System.Drawing.Size(626, 131);
            this.LogTextbox.TabIndex = 19;
            // 
            // TilesComboBox
            // 
            this.TilesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TilesComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TilesComboBox.FormattingEnabled = true;
            this.TilesComboBox.Location = new System.Drawing.Point(396, 93);
            this.TilesComboBox.Name = "TilesComboBox";
            this.TilesComboBox.Size = new System.Drawing.Size(242, 24);
            this.TilesComboBox.TabIndex = 20;
            this.TilesComboBox.DropDownClosed += new System.EventHandler(this.TileComboBoxDropdownClosed);
            // 
            // ControllerGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 325);
            this.Controls.Add(this.TilesComboBox);
            this.Controls.Add(this.LogTextbox);
            this.Controls.Add(this.EndButton);
            this.Controls.Add(this.StatsLabel);
            this.Controls.Add(this.StatsTextbox);
            this.Controls.Add(this.TeamComboBox);
            this.Controls.Add(this.AttackLabel);
            this.Controls.Add(this.MoveToLabel);
            this.Controls.Add(this.CurrentLabel);
            this.Controls.Add(this.TeamLabel);
            this.Controls.Add(this.TeamTexbox);
            this.Controls.Add(this.AttackComboBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ControllerGUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Controller";
            this.ResumeLayout(false);
            this.PerformLayout();

    }
    /// <summary>
    /// Creates a tether to the given game.
    /// </summary>
    /// <param name="game"></param>
    public void CreateConnectionWithGame(Game game)
    {
        _Game = game;
    }
    /// <summary>
    /// When the character has been set on the controller.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void CharacterComboBoxDropdownClosed(object sender, EventArgs e)
    {
        Character c = (Character)TeamComboBox.SelectedItem;
        for (int i = 0; i < c.GetOccuableTileQuantity(); i++)
        {
            Tile t = c.GetOccuableTile(i);
            TilesComboBox.Items.Add(t);
        }
        
        StatsTextbox.Text = c.Status();
        this.SoftUpdate();
        TeamComboBox.Enabled = false;
    }
    /// <summary>
    /// Occurs when the combobox of tiles is closed.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public void TileComboBoxDropdownClosed(object sender, EventArgs e)
    {
        Character c = (Character)TeamComboBox.SelectedItem;
        Tile t = TileLogic.ConvertStringToTile(_Game, TilesComboBox.SelectedItem.ToString());

        _Game.MoveCharacter(c, t);

        for (int i = 0; i < c.GetAttackableCharacterQuantity(); i++)
        {
            AttackComboBox.Items.Add(c.GetAttackableEntity(i));
        }

        this.SoftUpdate();
        TilesComboBox.Enabled = false;
    }
    public void AttakComboBoxDropdownClosed(object sender, EventArgs e)
    {
        AttackComboBox.Items.Clear();
        // DO DAMAGE TODO
        // NEED TO IMMPLEMENT
        // UAUAUAUUAUAUA
    }
    public void EndTurnButtonClick(object sender, EventArgs e)
    {
        GiveControls();
        HardUpdate();
    }
    /// <summary>
    /// Only updates the textual components.
    /// </summary>
    public void SoftUpdate()
    {
        TeamTexbox.Clear();
        

        for (int i = 0; i < Player1.TeamSize(); i++)
        {
            Character c = Player1.GetCharacterFromTeam(i);
            TeamTexbox.AppendText(c + ((Character)TeamComboBox.SelectedItem == c ? " << " : "") + "\n");
        }
    }
    /// <summary>
    /// Updates the controller including all GUI Components.
    /// </summary>
    public void HardUpdate()
    {
        TeamTexbox.Clear();
        TeamComboBox.Items.Clear();
        TilesComboBox.Items.Clear();
        
        for (int i = 0; i < Player1.TeamSize(); i++)
        {
            Character c = Player1.GetCharacterFromTeam(i);
            TeamTexbox.AppendText(c + "\n");
            TeamComboBox.Items.Add(c);
        }
    }
    public void GiveControls()
    {
        TeamComboBox.Enabled = true;
        TilesComboBox.Enabled = true;
    }
    public void TakeControls()
    {
        TeamComboBox.Enabled = false;
        TilesComboBox.Enabled = false;
    }

    #endregion

}