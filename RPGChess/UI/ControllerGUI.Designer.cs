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
    
    private System.Windows.Forms.TextBox MainUnitTextBox;
    private System.Windows.Forms.Label MainStatsLabel;
    private System.Windows.Forms.TextBox MainUnitStatsTextBox;
    private System.Windows.Forms.TextBox AuxiliaryTextBox;
    private System.Windows.Forms.Label LeadUnitLabel;
    private System.Windows.Forms.TextBox LeadUnitTextBox;
    private System.Windows.Forms.Label LeadUnitStatsLabel;
    private System.Windows.Forms.TextBox LeadUnitStatsTextBox;
    private System.Windows.Forms.Label MainUnitLabel;

    private System.Windows.Forms.Label LeadUnitTileLabel;
    private System.Windows.Forms.TextBox LeadUnitTileTextBox;
    private System.Windows.Forms.Label MainUnitTileLabel;
    private System.Windows.Forms.TextBox MainUnitTileTextBox;
    private System.Windows.Forms.Button EndTurnButton;
    private System.Windows.Forms.TextBox TeamTextBox;
    private System.Windows.Forms.TextBox MainUnitInfo;
    private System.Windows.Forms.TextBox GameLogBox;

    private Player ConnectedPlayer;
    private Game ConnectedGame;


    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
            this.MainUnitTextBox = new System.Windows.Forms.TextBox();
            this.MainStatsLabel = new System.Windows.Forms.Label();
            this.MainUnitStatsTextBox = new System.Windows.Forms.TextBox();
            this.AuxiliaryTextBox = new System.Windows.Forms.TextBox();
            this.LeadUnitLabel = new System.Windows.Forms.Label();
            this.LeadUnitTextBox = new System.Windows.Forms.TextBox();
            this.LeadUnitStatsLabel = new System.Windows.Forms.Label();
            this.LeadUnitStatsTextBox = new System.Windows.Forms.TextBox();
            this.MainUnitLabel = new System.Windows.Forms.Label();
            this.LeadUnitTileLabel = new System.Windows.Forms.Label();
            this.LeadUnitTileTextBox = new System.Windows.Forms.TextBox();
            this.MainUnitTileLabel = new System.Windows.Forms.Label();
            this.MainUnitTileTextBox = new System.Windows.Forms.TextBox();
            this.EndTurnButton = new System.Windows.Forms.Button();
            this.TeamTextBox = new System.Windows.Forms.TextBox();
            this.MainUnitInfo = new System.Windows.Forms.TextBox();
            this.GameLogBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // MainUnitTextBox
            // 
            this.MainUnitTextBox.Location = new System.Drawing.Point(385, 13);
            this.MainUnitTextBox.Name = "MainUnitTextBox";
            this.MainUnitTextBox.ReadOnly = true;
            this.MainUnitTextBox.Size = new System.Drawing.Size(253, 20);
            this.MainUnitTextBox.TabIndex = 26;
            // 
            // MainStatsLabel
            // 
            this.MainStatsLabel.AutoSize = true;
            this.MainStatsLabel.BackColor = System.Drawing.Color.Transparent;
            this.MainStatsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainStatsLabel.Location = new System.Drawing.Point(283, 43);
            this.MainStatsLabel.Name = "MainStatsLabel";
            this.MainStatsLabel.Size = new System.Drawing.Size(94, 17);
            this.MainStatsLabel.TabIndex = 27;
            this.MainStatsLabel.Text = "MAIN STATS:";
            // 
            // MainUnitStatsTextBox
            // 
            this.MainUnitStatsTextBox.Location = new System.Drawing.Point(385, 42);
            this.MainUnitStatsTextBox.Name = "MainUnitStatsTextBox";
            this.MainUnitStatsTextBox.ReadOnly = true;
            this.MainUnitStatsTextBox.Size = new System.Drawing.Size(253, 20);
            this.MainUnitStatsTextBox.TabIndex = 28;
            // 
            // AuxiliaryTextBox
            // 
            this.AuxiliaryTextBox.Location = new System.Drawing.Point(287, 94);
            this.AuxiliaryTextBox.Name = "AuxiliaryTextBox";
            this.AuxiliaryTextBox.ReadOnly = true;
            this.AuxiliaryTextBox.Size = new System.Drawing.Size(351, 20);
            this.AuxiliaryTextBox.TabIndex = 30;
            // 
            // LeadUnitLabel
            // 
            this.LeadUnitLabel.AutoSize = true;
            this.LeadUnitLabel.BackColor = System.Drawing.Color.Transparent;
            this.LeadUnitLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LeadUnitLabel.Location = new System.Drawing.Point(283, 121);
            this.LeadUnitLabel.Name = "LeadUnitLabel";
            this.LeadUnitLabel.Size = new System.Drawing.Size(84, 17);
            this.LeadUnitLabel.TabIndex = 33;
            this.LeadUnitLabel.Text = "LEAD UNIT:";
            // 
            // LeadUnitTextBox
            // 
            this.LeadUnitTextBox.Location = new System.Drawing.Point(385, 120);
            this.LeadUnitTextBox.Name = "LeadUnitTextBox";
            this.LeadUnitTextBox.ReadOnly = true;
            this.LeadUnitTextBox.Size = new System.Drawing.Size(253, 20);
            this.LeadUnitTextBox.TabIndex = 34;
            // 
            // LeadUnitStatsLabel
            // 
            this.LeadUnitStatsLabel.AutoSize = true;
            this.LeadUnitStatsLabel.BackColor = System.Drawing.Color.Transparent;
            this.LeadUnitStatsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LeadUnitStatsLabel.Location = new System.Drawing.Point(283, 149);
            this.LeadUnitStatsLabel.Name = "LeadUnitStatsLabel";
            this.LeadUnitStatsLabel.Size = new System.Drawing.Size(97, 17);
            this.LeadUnitStatsLabel.TabIndex = 35;
            this.LeadUnitStatsLabel.Text = "LEAD STATS:";
            // 
            // LeadUnitStatsTextBox
            // 
            this.LeadUnitStatsTextBox.Location = new System.Drawing.Point(385, 148);
            this.LeadUnitStatsTextBox.Name = "LeadUnitStatsTextBox";
            this.LeadUnitStatsTextBox.ReadOnly = true;
            this.LeadUnitStatsTextBox.Size = new System.Drawing.Size(253, 20);
            this.LeadUnitStatsTextBox.TabIndex = 36;
            // 
            // MainUnitLabel
            // 
            this.MainUnitLabel.AutoSize = true;
            this.MainUnitLabel.BackColor = System.Drawing.Color.Transparent;
            this.MainUnitLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainUnitLabel.Location = new System.Drawing.Point(283, 14);
            this.MainUnitLabel.Name = "MainUnitLabel";
            this.MainUnitLabel.Size = new System.Drawing.Size(81, 17);
            this.MainUnitLabel.TabIndex = 37;
            this.MainUnitLabel.Text = "MAIN UNIT:";
            // 
            // LeadUnitTileLabel
            // 
            this.LeadUnitTileLabel.AutoSize = true;
            this.LeadUnitTileLabel.BackColor = System.Drawing.Color.Transparent;
            this.LeadUnitTileLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LeadUnitTileLabel.Location = new System.Drawing.Point(284, 173);
            this.LeadUnitTileLabel.Name = "LeadUnitTileLabel";
            this.LeadUnitTileLabel.Size = new System.Drawing.Size(81, 17);
            this.LeadUnitTileLabel.TabIndex = 38;
            this.LeadUnitTileLabel.Text = "LEAD TILE:";
            // 
            // LeadUnitTileTextBox
            // 
            this.LeadUnitTileTextBox.Location = new System.Drawing.Point(385, 172);
            this.LeadUnitTileTextBox.Name = "LeadUnitTileTextBox";
            this.LeadUnitTileTextBox.ReadOnly = true;
            this.LeadUnitTileTextBox.Size = new System.Drawing.Size(253, 20);
            this.LeadUnitTileTextBox.TabIndex = 39;
            // 
            // MainUnitTileLabel
            // 
            this.MainUnitTileLabel.AutoSize = true;
            this.MainUnitTileLabel.BackColor = System.Drawing.Color.Transparent;
            this.MainUnitTileLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainUnitTileLabel.Location = new System.Drawing.Point(284, 69);
            this.MainUnitTileLabel.Name = "MainUnitTileLabel";
            this.MainUnitTileLabel.Size = new System.Drawing.Size(78, 17);
            this.MainUnitTileLabel.TabIndex = 40;
            this.MainUnitTileLabel.Text = "MAIN TILE:";
            // 
            // MainUnitTileTextBox
            // 
            this.MainUnitTileTextBox.Location = new System.Drawing.Point(385, 68);
            this.MainUnitTileTextBox.Name = "MainUnitTileTextBox";
            this.MainUnitTileTextBox.ReadOnly = true;
            this.MainUnitTileTextBox.Size = new System.Drawing.Size(253, 20);
            this.MainUnitTileTextBox.TabIndex = 41;
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
            this.TeamTextBox.ReadOnly = true;
            this.TeamTextBox.Size = new System.Drawing.Size(264, 177);
            this.TeamTextBox.TabIndex = 43;
            // 
            // MainUnitInfo
            // 
            this.MainUnitInfo.Location = new System.Drawing.Point(13, 197);
            this.MainUnitInfo.Multiline = true;
            this.MainUnitInfo.Name = "MainUnitInfo";
            this.MainUnitInfo.Size = new System.Drawing.Size(264, 116);
            this.MainUnitInfo.TabIndex = 44;
        this.MainUnitInfo.ReadOnly = true;
            // 
            // GameLogBox
            // 
            this.GameLogBox.Location = new System.Drawing.Point(287, 197);
            this.GameLogBox.Multiline = true;
            this.GameLogBox.Name = "GameLogBox";
            this.GameLogBox.ReadOnly = true;
            this.GameLogBox.Size = new System.Drawing.Size(351, 87);
            this.GameLogBox.TabIndex = 45;
            // 
            // ControllerGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 330);
            this.Controls.Add(this.GameLogBox);
            this.Controls.Add(this.MainUnitInfo);
            this.Controls.Add(this.TeamTextBox);
            this.Controls.Add(this.EndTurnButton);
            this.Controls.Add(this.MainUnitTileTextBox);
            this.Controls.Add(this.MainUnitTileLabel);
            this.Controls.Add(this.LeadUnitTileTextBox);
            this.Controls.Add(this.LeadUnitTileLabel);
            this.Controls.Add(this.MainUnitLabel);
            this.Controls.Add(this.LeadUnitStatsTextBox);
            this.Controls.Add(this.LeadUnitStatsLabel);
            this.Controls.Add(this.LeadUnitTextBox);
            this.Controls.Add(this.LeadUnitLabel);
            this.Controls.Add(this.AuxiliaryTextBox);
            this.Controls.Add(this.MainUnitStatsTextBox);
            this.Controls.Add(this.MainStatsLabel);
            this.Controls.Add(this.MainUnitTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ControllerGUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Controller";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

    }
    /// <summary>
    /// Adds the text to the top most right textbox.
    /// </summary>
    /// <param name="str">Text to be added.</param>
    public void RewriteMainUnitTextBox(Character c)
    {
        if (c == null) { return; }
        this.MainUnitTextBox.Text = c.SelectedView();
    }
    /// <summary>
    /// Adds text to the second to the top textbox on the right.
    /// </summary>
    /// <param name="str">Text to be added.</param>
    public void RewriteMainTileTextBox(Character c)
    {
        if (c == null) { return; }
        this.MainUnitTileTextBox.Text = c.TileView();
    }
    /// <summary>
    /// Adds text to the third most top textbox on the right
    /// </summary>
    /// <param name="str">string to be added.</param>
    public void RewriteMainUnitStatusTextBox(Character c)
    {
        if (c == null) { return; }
        this.MainUnitStatsTextBox.Text = c.StatusView();
    }
    /// <summary>
    /// Sets text to the left textbox 4th from the top.
    /// </summary>
    /// <param name="str">string to be added</param>
    public void RewriteAuxiliaryTextBox(string str)
    {
        if (str == null) { return; }
        this.AuxiliaryTextBox.Text = str;
    }
    /// <summary>
    /// Sets the textbox for the 5th textbox from the top on the right.
    /// </summary>
    /// <param name="str">string to be added.</param>
    public void RewriteLeadUnitTextBox(Character c)
    {
        if (c == null) { this.LeadUnitTextBox.Clear(); return; }
        this.LeadUnitTextBox.Text = c.SelectedView();
    }
    /// <summary>
    /// Sets the text for the 6th from the top on the right.
    /// </summary>
    /// <param name="str">string to be added.</param>
    public void RewriteLeadUnitStatusTextBox(Character c)
    {
        if (c == null) { this.LeadUnitStatsTextBox.Clear(); return; }
        this.LeadUnitStatsTextBox.Text = c.StatusView();
    }
    /// <summary>
    /// Sets the text for the 7th from the top of the right.
    /// </summary>
    /// <param name="str">string to be added.</param>
    public void RewriteLeadUnitTileTextBox(Character c)
    {
        if (c == null) { this.LeadUnitTileTextBox.Clear(); return; }
        this.LeadUnitTileTextBox.Text = c.TileView();
    }
    /// <summary>
    /// Rewrites info for the bottom left box of the controller.
    /// </summary>
    /// <param name="c"></param>
    public void RewriteMainUnitInfo(Character c)
    {
        this.MainUnitInfo.Text = "[LEFT-CLICK]: " + "Basic Attack ( " + c.DAMAGE + " base ). \n";
        this.MainUnitInfo.AppendText("[RIGHT-CLICK]: " + c.CLASS_OF_ENTITY.ULTIMATE.NAME 
            + "( " + (c.CLASS_OF_ENTITY.ULTIMATE.POTENCY + c.DAMAGE) + " base )\n");
        this.MainUnitInfo.AppendText("[TARGET RANGE]: " + c.CLASS_OF_ENTITY.RANGE + "\n");
        this.MainUnitInfo.AppendText("[MOVE RANGE]: " + c.CLASS_OF_ENTITY.MOVEMENT);
        //this.MainUnitInfo.AppendText(c.C + " HP PER TURN");
        //
        //
        //
        //
        //
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
            this.AppendTeamTextBox(c.TeamView());
        }
    }
    /// <summary>
    /// Appends information to the games log.
    /// </summary>
    /// <param name="str"></param>
    public void AppendToGameLog(string str)
    {
        if (this.GameLogBox.Text.Length > 1000) { this.GameLogBox.Clear(); }
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
    /// Updates the existing scene fields to match the current interacton
    /// </summary>
    /// <param name="c1"></param>
    /// <param name="c2"></param>
    public void UpdateScene(Character c1, Character c2)
    {

    }
    /// <summary>
    /// When the player decids to end the turn
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public void EndTurnButtonClick(object sender, EventArgs e)
    {
        this.MainUnitTextBox.Clear();
        this.MainUnitTileTextBox.Clear();
        this.MainUnitStatsTextBox.Clear();
        this.AuxiliaryTextBox.Clear();

        this.LeadUnitTextBox.Clear();
        this.LeadUnitStatsTextBox.Clear();
        this.LeadUnitTileTextBox.Clear();

        this.RefreshTeamTextBox();
        this.AppendToGameLog("Waiting for other player...(TODO)");
        this.ConnectedGame.ResetTurn();
        //ConnectedGame.UpdateAndRefreshGameGui();
        //socketlogic
        // and stuff
    }

    #endregion
}