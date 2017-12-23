using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;

partial class LobbyGUI
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


    private System.Windows.Forms.Label IPv4Label;
    private System.Windows.Forms.TextBox TopTextbox;
    private System.Windows.Forms.CheckBox TopCheckbox;

    private System.Windows.Forms.Button ConnectButton;
    private System.Windows.Forms.ComboBox ClassCombobox;
    private System.Windows.Forms.Label ClassLabel;
    private System.Windows.Forms.Label SeperatorLabel;
    private System.Windows.Forms.TextBox StatsTextbox;
    private System.Windows.Forms.Label StatsLabel;
    private System.Windows.Forms.Label NameLabel;
    private System.Windows.Forms.TextBox NameTextbox;
    private System.Windows.Forms.TextBox TeamTextbox;
    private System.Windows.Forms.Button ImortToTeamButton;
    private System.Windows.Forms.Button RemoveLatestButton;
    private System.Windows.Forms.Label UsernameLabel;
    private System.Windows.Forms.TextBox UsernameTextbox;
    private System.Windows.Forms.Button SurvivalButton;

    private string classType;
    private List<Character> CurrentTeam;

    private List<Archetype> ClassList;

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        this.IPv4Label = new System.Windows.Forms.Label();
        this.TopTextbox = new System.Windows.Forms.TextBox();
        this.TopCheckbox = new System.Windows.Forms.CheckBox();
        this.ConnectButton = new System.Windows.Forms.Button();
        this.ClassCombobox = new System.Windows.Forms.ComboBox();
        this.ClassLabel = new System.Windows.Forms.Label();
        this.SeperatorLabel = new System.Windows.Forms.Label();
        this.StatsTextbox = new System.Windows.Forms.TextBox();
        this.StatsLabel = new System.Windows.Forms.Label();
        this.NameLabel = new System.Windows.Forms.Label();
        this.NameTextbox = new System.Windows.Forms.TextBox();
        this.TeamTextbox = new System.Windows.Forms.TextBox();
        this.ImortToTeamButton = new System.Windows.Forms.Button();
        this.RemoveLatestButton = new System.Windows.Forms.Button();
        this.UsernameLabel = new System.Windows.Forms.Label();
        this.UsernameTextbox = new System.Windows.Forms.TextBox();
        this.SurvivalButton = new System.Windows.Forms.Button();
        this.AbilityLabel = new System.Windows.Forms.Label();
        this.AbilityCombobox = new System.Windows.Forms.ComboBox();
        this.SuspendLayout();
        // 
        // IPv4Label
        // 
        this.IPv4Label.AutoSize = true;
        this.IPv4Label.BackColor = System.Drawing.Color.Transparent;
        this.IPv4Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.IPv4Label.Location = new System.Drawing.Point(300, 105);
        this.IPv4Label.Name = "IPv4Label";
        this.IPv4Label.Size = new System.Drawing.Size(39, 17);
        this.IPv4Label.TabIndex = 0;
        this.IPv4Label.Text = "IPv4:";
        // 
        // TopTextbox
        // 
        this.TopTextbox.Location = new System.Drawing.Point(400, 102);
        this.TopTextbox.Name = "TopTextbox";
        this.TopTextbox.Size = new System.Drawing.Size(202, 20);
        this.TopTextbox.TabIndex = 1;
        // 
        // TopCheckbox
        // 
        this.TopCheckbox.AutoSize = true;
        this.TopCheckbox.BackColor = System.Drawing.Color.Transparent;
        this.TopCheckbox.Location = new System.Drawing.Point(303, 22);
        this.TopCheckbox.Name = "TopCheckbox";
        this.TopCheckbox.Size = new System.Drawing.Size(90, 17);
        this.TopCheckbox.TabIndex = 2;
        this.TopCheckbox.Text = "LOCALHOST";
        this.TopCheckbox.UseVisualStyleBackColor = false;
        // 
        // ConnectButton
        // 
        this.ConnectButton.Enabled = false;
        this.ConnectButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ConnectButton.Location = new System.Drawing.Point(399, 17);
        this.ConnectButton.Name = "ConnectButton";
        this.ConnectButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ConnectButton.Size = new System.Drawing.Size(203, 23);
        this.ConnectButton.TabIndex = 3;
        this.ConnectButton.Text = "CONNECT";
        this.ConnectButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
        this.ConnectButton.UseVisualStyleBackColor = true;
        this.ConnectButton.Click += new System.EventHandler(this.ConnectButton_click);
        // 
        // ClassCombobox
        // 
        this.ClassCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.ClassCombobox.FormattingEnabled = true;
        this.ClassCombobox.Location = new System.Drawing.Point(74, 63);
        this.ClassCombobox.Name = "ClassCombobox";
        this.ClassCombobox.Size = new System.Drawing.Size(210, 21);
        this.ClassCombobox.TabIndex = 4;
        this.ClassCombobox.DropDownClosed += new System.EventHandler(this.ClassCombobox_DropDownClosed);
        // 
        // ClassLabel
        // 
        this.ClassLabel.AutoSize = true;
        this.ClassLabel.BackColor = System.Drawing.Color.Transparent;
        this.ClassLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ClassLabel.Location = new System.Drawing.Point(13, 66);
        this.ClassLabel.Name = "ClassLabel";
        this.ClassLabel.Size = new System.Drawing.Size(56, 17);
        this.ClassLabel.TabIndex = 5;
        this.ClassLabel.Text = "CLASS:";
        // 
        // SeperatorLabel
        // 
        this.SeperatorLabel.AutoSize = true;
        this.SeperatorLabel.BackColor = System.Drawing.Color.Transparent;
        this.SeperatorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.SeperatorLabel.Location = new System.Drawing.Point(12, 42);
        this.SeperatorLabel.Name = "SeperatorLabel";
        this.SeperatorLabel.Size = new System.Drawing.Size(623, 17);
        this.SeperatorLabel.TabIndex = 6;
        this.SeperatorLabel.Text = "---------------------------------------------------------------------------------" +
"------------------------------------------";
        // 
        // StatsTextbox
        // 
        this.StatsTextbox.Enabled = false;
        this.StatsTextbox.Location = new System.Drawing.Point(74, 117);
        this.StatsTextbox.Name = "StatsTextbox";
        this.StatsTextbox.Size = new System.Drawing.Size(210, 20);
        this.StatsTextbox.TabIndex = 7;
        // 
        // StatsLabel
        // 
        this.StatsLabel.AutoSize = true;
        this.StatsLabel.BackColor = System.Drawing.Color.Transparent;
        this.StatsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.StatsLabel.Location = new System.Drawing.Point(13, 120);
        this.StatsLabel.Name = "StatsLabel";
        this.StatsLabel.Size = new System.Drawing.Size(57, 17);
        this.StatsLabel.TabIndex = 8;
        this.StatsLabel.Text = "STATS:";
        // 
        // NameLabel
        // 
        this.NameLabel.AutoSize = true;
        this.NameLabel.BackColor = System.Drawing.Color.Transparent;
        this.NameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.NameLabel.Location = new System.Drawing.Point(12, 146);
        this.NameLabel.Name = "NameLabel";
        this.NameLabel.Size = new System.Drawing.Size(51, 17);
        this.NameLabel.TabIndex = 9;
        this.NameLabel.Text = "NAME:";
        // 
        // NameTextbox
        // 
        this.NameTextbox.Location = new System.Drawing.Point(74, 143);
        this.NameTextbox.Name = "NameTextbox";
        this.NameTextbox.Size = new System.Drawing.Size(210, 20);
        this.NameTextbox.TabIndex = 10;
        this.NameTextbox.Enter += new System.EventHandler(this.OnTextEnter_click);
        // 
        // TeamTextbox
        // 
        this.TeamTextbox.Location = new System.Drawing.Point(15, 198);
        this.TeamTextbox.Multiline = true;
        this.TeamTextbox.Name = "TeamTextbox";
        this.TeamTextbox.ReadOnly = true;
        this.TeamTextbox.Size = new System.Drawing.Size(269, 115);
        this.TeamTextbox.TabIndex = 11;
        // 
        // ImortToTeamButton
        // 
        this.ImortToTeamButton.Enabled = false;
        this.ImortToTeamButton.Location = new System.Drawing.Point(30, 169);
        this.ImortToTeamButton.Name = "ImortToTeamButton";
        this.ImortToTeamButton.Size = new System.Drawing.Size(113, 23);
        this.ImortToTeamButton.TabIndex = 12;
        this.ImortToTeamButton.Text = "IMPORT TO TEAM";
        this.ImortToTeamButton.UseVisualStyleBackColor = true;
        this.ImortToTeamButton.Click += new System.EventHandler(this.ImportToTeam_click);
        // 
        // RemoveLatestButton
        // 
        this.RemoveLatestButton.Enabled = false;
        this.RemoveLatestButton.Location = new System.Drawing.Point(149, 169);
        this.RemoveLatestButton.Name = "RemoveLatestButton";
        this.RemoveLatestButton.Size = new System.Drawing.Size(113, 23);
        this.RemoveLatestButton.TabIndex = 13;
        this.RemoveLatestButton.Text = "REMOVE NEWEST";
        this.RemoveLatestButton.UseVisualStyleBackColor = true;
        this.RemoveLatestButton.Click += new System.EventHandler(this.RemoveLatest_click);
        // 
        // UsernameLabel
        // 
        this.UsernameLabel.AutoSize = true;
        this.UsernameLabel.BackColor = System.Drawing.Color.Transparent;
        this.UsernameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.UsernameLabel.Location = new System.Drawing.Point(300, 72);
        this.UsernameLabel.Name = "UsernameLabel";
        this.UsernameLabel.Size = new System.Drawing.Size(93, 17);
        this.UsernameLabel.TabIndex = 14;
        this.UsernameLabel.Text = "USERNAME: ";
        // 
        // UsernameTextbox
        // 
        this.UsernameTextbox.Location = new System.Drawing.Point(400, 72);
        this.UsernameTextbox.Name = "UsernameTextbox";
        this.UsernameTextbox.Size = new System.Drawing.Size(202, 20);
        this.UsernameTextbox.TabIndex = 15;
        // 
        // SurvivalButton
        // 
        this.SurvivalButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.SurvivalButton.Location = new System.Drawing.Point(74, 18);
        this.SurvivalButton.Name = "SurvivalButton";
        this.SurvivalButton.Size = new System.Drawing.Size(205, 23);
        this.SurvivalButton.TabIndex = 16;
        this.SurvivalButton.Text = "SURVIVAL";
        this.SurvivalButton.UseVisualStyleBackColor = true;
        // 
        // AbilityLabel
        // 
        this.AbilityLabel.AutoSize = true;
        this.AbilityLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.AbilityLabel.Location = new System.Drawing.Point(13, 93);
        this.AbilityLabel.Name = "AbilityLabel";
        this.AbilityLabel.Size = new System.Drawing.Size(62, 17);
        this.AbilityLabel.TabIndex = 17;
        this.AbilityLabel.Text = "ABILITY:";
        this.AbilityLabel.BackColor = Color.Transparent;
        // 
        // AbilityCombobox
        // 
        this.AbilityCombobox.FormattingEnabled = true;
        this.AbilityCombobox.Location = new System.Drawing.Point(74, 90);
        this.AbilityCombobox.Name = "AbilityCombobox";
        this.AbilityCombobox.Size = new System.Drawing.Size(210, 21);
        this.AbilityCombobox.TabIndex = 18;
        this.AbilityCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        // 
        // LobbyGUI
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(630, 325);
        this.Controls.Add(this.AbilityCombobox);
        this.Controls.Add(this.AbilityLabel);
        this.Controls.Add(this.SurvivalButton);
        this.Controls.Add(this.UsernameTextbox);
        this.Controls.Add(this.UsernameLabel);
        this.Controls.Add(this.RemoveLatestButton);
        this.Controls.Add(this.ImortToTeamButton);
        this.Controls.Add(this.TeamTextbox);
        this.Controls.Add(this.NameTextbox);
        this.Controls.Add(this.NameLabel);
        this.Controls.Add(this.StatsLabel);
        this.Controls.Add(this.StatsTextbox);
        this.Controls.Add(this.SeperatorLabel);
        this.Controls.Add(this.ClassLabel);
        this.Controls.Add(this.ClassCombobox);
        this.Controls.Add(this.ConnectButton);
        this.Controls.Add(this.TopCheckbox);
        this.Controls.Add(this.TopTextbox);
        this.Controls.Add(this.IPv4Label);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        this.BackgroundImage = ImageManager.SubBackground();
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "LobbyGUI";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "Lobby";
        this.ResumeLayout(false);
        this.PerformLayout();
    }
    /// <summary>
    /// instantiates other objects.
    /// </summary>
    private void SetUp()
    {
        ClassList = new List<Archetype>();
        CurrentTeam = new List<Character>();

        foreach (Archetype a in Archetype.Values)
        {
            this.ClassCombobox.Items.Add(a);
            this.ClassList.Add(a);
        }
        this.TeamTextbox.Text = NetworkManager.GetLocalIPAddress();
    }
    /// <summary>
    /// Checks if the current team is of adequate amount.
    /// </summary>
    private void CheckIfFullTeam()
    {
        if (CurrentTeam.Count >= Global.TEAMSIZE && UsernameTextbox.Text.Length > 1)
        {
            this.ImortToTeamButton.Enabled = false;
            this.ConnectButton.Enabled = true;
        }
        else
        {
            this.ConnectButton.Enabled = false;
            this.ImortToTeamButton.Enabled = true;

            if (CurrentTeam.Count == 0)
            {
                this.RemoveLatestButton.Enabled = false;
            }
            else
            {
                this.RemoveLatestButton.Enabled = true;
            }
        }
    }

    #endregion

    private System.Windows.Forms.Label AbilityLabel;
    private System.Windows.Forms.ComboBox AbilityCombobox;
}