using System;
using System.Drawing;
using System.Windows.Forms;

partial class GUI
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

    private System.Windows.Forms.Button FirstButton;
    private System.Windows.Forms.Button SecondButton;
    private System.Windows.Forms.PictureBox Display;

    private LobbyGUI Lobby;
    private Metadata Data;

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        this.FirstButton = new System.Windows.Forms.Button();
        this.SecondButton = new System.Windows.Forms.Button();
        this.Display = new System.Windows.Forms.PictureBox();
        this.Data = new Metadata();
        this.SuspendLayout();
        // 
        // main button
        // 
        this.FirstButton.Location = new System.Drawing.Point(50, Global.WindowHeight - 400);
        this.FirstButton.Name = "FirstButton";
        this.FirstButton.Size = new System.Drawing.Size(Global.ButtonWidth, Global.ButtonHeight);
        this.FirstButton.TabIndex = 0;
        this.FirstButton.Text = "PLAY";
        this.FirstButton.UseVisualStyleBackColor = true;
        this.FirstButton.Click += new System.EventHandler(this.FirstButton_click);
        //
        // the fourth button
        //
        this.SecondButton.Location = new System.Drawing.Point(50, Global.WindowHeight - 300);
        this.SecondButton.Name = "FourthButton";
        this.SecondButton.Size = new System.Drawing.Size(Global.ButtonWidth, Global.ButtonHeight);
        this.SecondButton.TabIndex = 2;
        this.SecondButton.Text = "EXIT";
        this.SecondButton.UseVisualStyleBackColor = true;
        this.SecondButton.Click += new System.EventHandler(this.FourthButton_click);
        // 
        // Display
        // 
        this.Display.Dock = System.Windows.Forms.DockStyle.Fill;
        this.Display.Location = new System.Drawing.Point(0, 0);
        this.Display.Name = "Display";
        this.Display.Size = new System.Drawing.Size(774, 462);
        this.Display.TabIndex = 1;
        this.Display.BackColor = System.Drawing.Color.Black;
        // 
        // GUI
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(Global.WindowWidth, Global.WindowHeight);
        this.DoubleBuffered = true;
        this.MinimizeBox = false;
        this.MaximizeBox = false;
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        this.BackgroundImage = ImageManager.MainBackground();
        this.Controls.Add(this.FirstButton);
        this.Controls.Add(this.SecondButton);
        this.Controls.Add(this.Display);
        this.Name = "GUI";
        this.Text = "Apocrypha";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(ClosingButton_click);
        this.Load += new EventHandler(LoadGUI);
        this.ResumeLayout(true);
    }
    /// <summary>
    /// Logic before logic shown.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public void LoadGUI(object sender, EventArgs e)
    {
        this.Display.BackgroundImage = ImageManager.MainBackground();
    }
    private void FormMove_click(object sender, EventArgs e)
    {
        this.Location = new System.Drawing.Point(0, 0);
    }
    /// <summary>
    /// Conceals all pertinent main screen components.
    /// </summary>
    private void HideComponents()
    {
        this.FirstButton.Hide();
        this.SecondButton.Hide();
    }
    /// <summary>
    /// Shows the pertinent main screen components.
    /// </summary>
    private void ShowComponents()
    {
        this.FirstButton.Show();
        this.SecondButton.Show();
    }
    #endregion

}