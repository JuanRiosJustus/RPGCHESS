using System;
using System.ComponentModel;
using System.Drawing;

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
        if (ConnectedGame.GameIsOver())
        {
            base.Dispose(disposing);
        }
    }
    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public void ForceDispose(object sender, EventArgs e)
    {
        base.Dispose(true);
    }

    #region Windows Form Designer generated code
    
    private System.Windows.Forms.TextBox SelectedUnitTextBox;
    private System.Windows.Forms.Label UnitStatusLabel;
    private System.Windows.Forms.TextBox UnitStatusLabelTextBox;
    private System.Windows.Forms.Label FromTileLabel;
    private System.Windows.Forms.TextBox FromTextBox;
    private System.Windows.Forms.Label ToLabel;
    private System.Windows.Forms.TextBox ToTextBox;
    private System.Windows.Forms.Label DefendingUnitLabel;
    private System.Windows.Forms.TextBox DefendingUnitTextBox;
    private System.Windows.Forms.Label DefendingUnitStatusLabel;
    private System.Windows.Forms.TextBox DefendingUnitStatusTextBox;
    private System.Windows.Forms.Label SelectedUnitLabel;

    private System.Windows.Forms.Label CombatResultLabel;
    private System.Windows.Forms.TextBox CombatResultTextBox;
    private System.Windows.Forms.Label UnitExpLabel;
    private System.Windows.Forms.TextBox ExpTextBox;
    private System.Windows.Forms.Button EndTurnButton;
    private System.Windows.Forms.TextBox TeamTextBox;
    private System.Windows.Forms.TextBox SelectedUnitDetail;
    private System.Windows.Forms.TextBox GameLogBox;

    private Player ConnectedPlayer;
    private Game ConnectedGame;


    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        this.SelectedUnitTextBox = new System.Windows.Forms.TextBox();
        this.UnitStatusLabel = new System.Windows.Forms.Label();
        this.UnitStatusLabelTextBox = new System.Windows.Forms.TextBox();
        this.FromTileLabel = new System.Windows.Forms.Label();
        this.FromTextBox = new System.Windows.Forms.TextBox();
        this.ToLabel = new System.Windows.Forms.Label();
        this.ToTextBox = new System.Windows.Forms.TextBox();
        this.DefendingUnitLabel = new System.Windows.Forms.Label();
        this.DefendingUnitTextBox = new System.Windows.Forms.TextBox();
        this.DefendingUnitStatusLabel = new System.Windows.Forms.Label();
        this.DefendingUnitStatusTextBox = new System.Windows.Forms.TextBox();
        this.SelectedUnitLabel = new System.Windows.Forms.Label();
        this.CombatResultLabel = new System.Windows.Forms.Label();
        this.CombatResultTextBox = new System.Windows.Forms.TextBox();
        this.UnitExpLabel = new System.Windows.Forms.Label();
        this.ExpTextBox = new System.Windows.Forms.TextBox();
        this.EndTurnButton = new System.Windows.Forms.Button();
        this.TeamTextBox = new System.Windows.Forms.TextBox();
        this.SelectedUnitDetail = new System.Windows.Forms.TextBox();
        this.GameLogBox = new System.Windows.Forms.TextBox();

        this.SuspendLayout();
        // 
        // SelectedUnitTextBox
        // 
        this.SelectedUnitTextBox.Location = new System.Drawing.Point(411, 13);
        this.SelectedUnitTextBox.Name = "SelectedUnitTextBox";
        this.SelectedUnitTextBox.ReadOnly = true;
        this.SelectedUnitTextBox.Size = new System.Drawing.Size(227, 20);
        this.SelectedUnitTextBox.TabIndex = 26;
        // 
        // UnitStatusLabel
        // 
        this.UnitStatusLabel.AutoSize = true;
        this.UnitStatusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.UnitStatusLabel.Location = new System.Drawing.Point(284, 69);
        this.UnitStatusLabel.Name = "UnitStatusLabel";
        this.UnitStatusLabel.Size = new System.Drawing.Size(103, 17);
        this.UnitStatusLabel.TabIndex = 27;
        this.UnitStatusLabel.Text = "UNIT STATUS:";
        this.UnitStatusLabel.BackColor = Color.Transparent;
        // 
        // UnitStatusLabelTextBox
        // 
        this.UnitStatusLabelTextBox.Location = new System.Drawing.Point(411, 68);
        this.UnitStatusLabelTextBox.Name = "UnitStatusLabelTextBox";
        this.UnitStatusLabelTextBox.ReadOnly = true;
        this.UnitStatusLabelTextBox.Size = new System.Drawing.Size(227, 20);
        this.UnitStatusLabelTextBox.TabIndex = 28;
        // 
        // FromTileLabel
        // 
        this.FromTileLabel.AutoSize = true;
        this.FromTileLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.FromTileLabel.Location = new System.Drawing.Point(284, 95);
        this.FromTileLabel.Name = "FromTileLabel";
        this.FromTileLabel.Size = new System.Drawing.Size(52, 17);
        this.FromTileLabel.TabIndex = 29;
        this.FromTileLabel.Text = "FROM:";
        this.FromTileLabel.BackColor = Color.Transparent;
        // 
        // FromTextBox
        // 
        this.FromTextBox.Location = new System.Drawing.Point(342, 94);
        this.FromTextBox.Name = "FromTextBox";
        this.FromTextBox.ReadOnly = true;
        this.FromTextBox.Size = new System.Drawing.Size(100, 20);
        this.FromTextBox.TabIndex = 30;
        // 
        // ToLabel
        // 
        this.ToLabel.AutoSize = true;
        this.ToLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ToLabel.Location = new System.Drawing.Point(500, 95);
        this.ToLabel.Name = "ToLabel";
        this.ToLabel.Size = new System.Drawing.Size(32, 17);
        this.ToLabel.TabIndex = 31;
        this.ToLabel.Text = "TO:";
        this.ToLabel.BackColor = Color.Transparent;
        // 
        // ToTextBox
        // 
        this.ToTextBox.Location = new System.Drawing.Point(538, 94);
        this.ToTextBox.Name = "ToTextBox";
        this.ToTextBox.ReadOnly = true;
        this.ToTextBox.Size = new System.Drawing.Size(100, 20);
        this.ToTextBox.TabIndex = 32;
        // 
        // DefendingUnitLabel
        // 
        this.DefendingUnitLabel.AutoSize = true;
        this.DefendingUnitLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.DefendingUnitLabel.Location = new System.Drawing.Point(284, 121);
        this.DefendingUnitLabel.Name = "DefendingUnitLabel";
        this.DefendingUnitLabel.Size = new System.Drawing.Size(128, 17);
        this.DefendingUnitLabel.TabIndex = 33;
        this.DefendingUnitLabel.Text = "DEFENDING UNIT:";
        this.DefendingUnitLabel.BackColor = Color.Transparent;
        // 
        // DefendingUnitTextBox
        // 
        this.DefendingUnitTextBox.Location = new System.Drawing.Point(411, 120);
        this.DefendingUnitTextBox.Name = "DefendingUnitTextBox";
        this.DefendingUnitTextBox.ReadOnly = true;
        this.DefendingUnitTextBox.Size = new System.Drawing.Size(227, 20);
        this.DefendingUnitTextBox.TabIndex = 34;
        // 
        // DefendingUnitStatusLabel
        // 
        this.DefendingUnitStatusLabel.AutoSize = true;
        this.DefendingUnitStatusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.DefendingUnitStatusLabel.Location = new System.Drawing.Point(283, 147);
        this.DefendingUnitStatusLabel.Name = "DefendingUnitStatusLabel";
        this.DefendingUnitStatusLabel.Size = new System.Drawing.Size(103, 17);
        this.DefendingUnitStatusLabel.TabIndex = 35;
        this.DefendingUnitStatusLabel.Text = "UNIT STATUS:";
        this.DefendingUnitStatusLabel.BackColor = Color.Transparent;
        // 
        // DefendingUnitStatusTextBox
        // 
        this.DefendingUnitStatusTextBox.Location = new System.Drawing.Point(411, 146);
        this.DefendingUnitStatusTextBox.Name = "DefendingUnitStatusTextBox";
        this.DefendingUnitStatusTextBox.ReadOnly = true;
        this.DefendingUnitStatusTextBox.Size = new System.Drawing.Size(227, 20);
        this.DefendingUnitStatusTextBox.TabIndex = 36;
        // 
        // SelectedUnitLabel
        // 
        this.SelectedUnitLabel.AutoSize = true;
        this.SelectedUnitLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.SelectedUnitLabel.Location = new System.Drawing.Point(284, 14);
        this.SelectedUnitLabel.Name = "SelectedUnitLabel";
        this.SelectedUnitLabel.Size = new System.Drawing.Size(120, 17);
        this.SelectedUnitLabel.TabIndex = 37;
        this.SelectedUnitLabel.Text = "SELECTED UNIT:";
        this.SelectedUnitLabel.BackColor = Color.Transparent;
        // 
        // CombatResultLabel
        // 
        this.CombatResultLabel.AutoSize = true;
        this.CombatResultLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.CombatResultLabel.Location = new System.Drawing.Point(283, 173);
        this.CombatResultLabel.Name = "CombatResultLabel";
        this.CombatResultLabel.Size = new System.Drawing.Size(129, 17);
        this.CombatResultLabel.TabIndex = 38;
        this.CombatResultLabel.Text = "COMBAT RESULT:";
        this.CombatResultLabel.BackColor = Color.Transparent;
        // 
        // CombatResultTextBox
        // 
        this.CombatResultTextBox.Location = new System.Drawing.Point(411, 172);
        this.CombatResultTextBox.Name = "CombatResultTextBox";
        this.CombatResultTextBox.ReadOnly = true;
        this.CombatResultTextBox.Size = new System.Drawing.Size(227, 20);
        this.CombatResultTextBox.TabIndex = 39;
        // 
        // UnitExpLabel
        // 
        this.UnitExpLabel.AutoSize = true;
        this.UnitExpLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.UnitExpLabel.Location = new System.Drawing.Point(284, 41);
        this.UnitExpLabel.Name = "UnitExpLabel";
        this.UnitExpLabel.Size = new System.Drawing.Size(75, 17);
        this.UnitExpLabel.TabIndex = 40;
        this.UnitExpLabel.Text = "UNIT EXP:";
        this.UnitExpLabel.BackColor = Color.Transparent;
        // 
        // ExpTextBox
        // 
        this.ExpTextBox.Location = new System.Drawing.Point(411, 40);
        this.ExpTextBox.Name = "ExpTextBox";
        this.ExpTextBox.ReadOnly = true;
        this.ExpTextBox.Size = new System.Drawing.Size(227, 20);
        this.ExpTextBox.TabIndex = 41;
        // 
        // EndTurnButton
        // 
        this.EndTurnButton.Location = new System.Drawing.Point(286, 290);
        this.EndTurnButton.Name = "EndTurnButton";
        this.EndTurnButton.Size = new System.Drawing.Size(352, 23);
        this.EndTurnButton.TabIndex = 42;
        this.EndTurnButton.Text = "END TURN";
        this.EndTurnButton.UseVisualStyleBackColor = true;
        this.EndTurnButton.Click += new System.EventHandler(this.EndTurnButtonClick);
        // 
        // TeamTextBox
        // 
        this.TeamTextBox.Location = new System.Drawing.Point(13, 13);
        this.TeamTextBox.Multiline = true;
        this.TeamTextBox.Name = "TeamTextBox";
        this.TeamTextBox.Size = new System.Drawing.Size(264, 177);
        this.TeamTextBox.TabIndex = 43;
        this.TeamTextBox.ReadOnly = true;
        // 
        // SelectedUnitDetail
        // 
        this.SelectedUnitDetail.Location = new System.Drawing.Point(13, 197);
        this.SelectedUnitDetail.Multiline = true;
        this.SelectedUnitDetail.Name = "SelectedUnitDetail";
        this.SelectedUnitDetail.Size = new System.Drawing.Size(264, 116);
        this.SelectedUnitDetail.TabIndex = 44;
        this.SelectedUnitDetail.ReadOnly = true;
        // 
        // GameLogBox
        // 
        this.GameLogBox.Location = new System.Drawing.Point(287, 197);
        this.GameLogBox.Multiline = true;
        this.GameLogBox.Name = "GameLogBox";
        this.GameLogBox.Size = new System.Drawing.Size(351, 87);
        this.GameLogBox.TabIndex = 45;
        this.GameLogBox.ReadOnly = true;
        // 
        // ControllerGUI
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(650, 325);
        this.Controls.Add(this.GameLogBox);
        this.Controls.Add(this.SelectedUnitDetail);
        this.Controls.Add(this.TeamTextBox);
        this.Controls.Add(this.EndTurnButton);
        this.Controls.Add(this.ExpTextBox);
        this.Controls.Add(this.UnitExpLabel);
        this.Controls.Add(this.CombatResultTextBox);
        this.Controls.Add(this.CombatResultLabel);
        this.Controls.Add(this.SelectedUnitLabel);
        this.Controls.Add(this.DefendingUnitStatusTextBox);
        this.Controls.Add(this.DefendingUnitStatusLabel);
        this.Controls.Add(this.DefendingUnitTextBox);
        this.Controls.Add(this.DefendingUnitLabel);
        this.Controls.Add(this.ToTextBox);
        this.Controls.Add(this.ToLabel);
        this.Controls.Add(this.FromTextBox);
        this.Controls.Add(this.FromTileLabel);
        this.Controls.Add(this.UnitStatusLabelTextBox);
        this.Controls.Add(this.UnitStatusLabel);
        this.Controls.Add(this.SelectedUnitTextBox);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "ControllerGUI";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.BackgroundImage = ImageManager.AuxBackground;
        this.Text = "Controller";
        this.ResumeLayout(false);
        this.TopMost = true;
        this.PerformLayout();
    }
    /// <summary>
    /// Adds the text to the top most right textbox.
    /// </summary>
    /// <param name="str">Text to be added.</param>
    public void RewriteSelectedUnitTextBox(string str)
    {
        this.SelectedUnitTextBox.Text = str;
    }
    /// <summary>
    /// Adds text to the second to the top textbox on the right.
    /// </summary>
    /// <param name="str">Text to be added.</param>
    public void RewriteExpTextBox(string str)
    {
        this.ExpTextBox.Text = str;
    }
    /// <summary>
    /// Adds text to the third most top textbox on the right
    /// </summary>
    /// <param name="str">string to be added.</param>
    public void RewriteUnitStatusLabelTextBox(string str)
    {
        this.UnitStatusLabelTextBox.Text = str;
    }
    /// <summary>
    /// Sets text to the left textbox 4th from the top.
    /// </summary>
    /// <param name="str">string to be added</param>
    public void RewriteFromTextBox(string str)
    {
        this.FromTextBox.Text = str;
    }
    /// <summary>
    /// Sets text to the right textbox 4th from the top. 
    /// </summary>
    /// <param name="str">string to be added.</param>
    public void RewriteToTextBox(string str)
    {
        this.ToTextBox.Text = str;
    }
    /// <summary>
    /// Sets the textbox for the 5th textbox from the top on the right.
    /// </summary>
    /// <param name="str">string to be added.</param>
    public void RewriteDefendingUnitTextBox(string str)
    {
        this.DefendingUnitTextBox.Text = str;
    }
    /// <summary>
    /// Sets the text for the 6th from the top on the right.
    /// </summary>
    /// <param name="str">string to be added.</param>
    public void RewriteDefendingUnitStatus(string str)
    {
        this.DefendingUnitStatusTextBox.Text = str;
    }
    /// <summary>
    /// Sets the text for the 7th from the top of the right.
    /// </summary>
    /// <param name="str">string to be added.</param>
    public void RewriteCombatResultTextBox(string str)
    {
        this.CombatResultTextBox.Text = str;
    }
    /// <summary>
    /// Appends the given string to the team textbox.
    /// </summary>
    /// <param name="str">string to be appended.</param>
    private void AppendTeamTextBox(string str)
    {
        this.TeamTextBox.AppendText(str + "\n");
    }
    /// <summary>
    /// Refreshes the Team Textbox.
    /// </summary>
    public void RefreshTeamTextBox()
    {
        this.TeamTextBox.Clear();
        for (int i = 0; i < ConnectedPlayer.TeamSize(); i++)
        {
            Character c = ConnectedPlayer.GetCharacterFromTeam(i);
            this.AppendTeamTextBox(c.ToString());
        }
    }
    /// <summary>
    /// Appends information to the games log.
    /// </summary>
    /// <param name="str"></param>
    public void AppendToGameLog(string str)
    {
        this.GameLogBox.AppendText(Metadata.GameTime() + str + "\n");
    }
    /// <summary>
    /// When the player has decided to attack.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public void AttackButtonClick(object sender, EventArgs e)
    {

        // DO DAMAGE TODO
        // NEED TO IMMPLEMENT
        // UAUAUAUUAUAUA
    }
    /// <summary>
    /// When the player decids to end the turn
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public void EndTurnButtonClick(object sender, EventArgs e)
    {
        ConnectedGame.UpdateAndRefreshGameGui();
        //socketlogic
        // and stuff
    }

    #endregion
    
    

    protected override void OnClosing(CancelEventArgs e)
    {
        return;
    }
}