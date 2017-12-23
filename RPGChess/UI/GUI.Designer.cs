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
    private System.Windows.Forms.Button ThirdButton;
    private System.Windows.Forms.Button FourthButton;

    private LobbyGUI Lobby;
    private GameGUI Board;

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        this.FirstButton = new System.Windows.Forms.Button();
        this.SecondButton = new System.Windows.Forms.Button();
        this.ThirdButton = new System.Windows.Forms.Button();
        this.FourthButton = new System.Windows.Forms.Button();

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
        // the second button
        //
        this.SecondButton.Location = new System.Drawing.Point(50, Global.WindowHeight - 300);
        this.SecondButton.Name = "SecondButton";
        this.SecondButton.Size = new System.Drawing.Size(Global.ButtonWidth, Global.ButtonHeight);
        this.SecondButton.TabIndex = 1;
        this.SecondButton.Text = "HELP";
        this.SecondButton.UseVisualStyleBackColor = true;
        this.SecondButton.Click += new System.EventHandler(this.SecondButton_click);
        //
        // the third button
        //
        this.ThirdButton.Location = new System.Drawing.Point(50, Global.WindowHeight - 200);
        this.ThirdButton.Name = "ThirdButton";
        this.ThirdButton.Size = new System.Drawing.Size(Global.ButtonWidth, Global.ButtonHeight);
        this.ThirdButton.TabIndex = 2;
        this.ThirdButton.Text = "SETTINGS";
        this.ThirdButton.UseVisualStyleBackColor = true;
        this.ThirdButton.Click += new System.EventHandler(this.ThirdButton_click);
        //
        // the fourth button
        //
        this.FourthButton.Location = new System.Drawing.Point(50, Global.WindowHeight - 100);
        this.FourthButton.Name = "FourthButton";
        this.FourthButton.Size = new System.Drawing.Size(Global.ButtonWidth, Global.ButtonHeight);
        this.FourthButton.TabIndex = 2;
        this.FourthButton.Text = "EXIT";
        this.FourthButton.UseVisualStyleBackColor = true;
        this.FourthButton.Click += new System.EventHandler(this.FourthButton_click);
        // 
        // GUI
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(Global.WindowWidth, Global.WindowHeight);
        this.MinimizeBox = false;
        this.MaximizeBox = false;
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        this.BackgroundImage = ImageManager.MainBackground();
        this.Controls.Add(this.FirstButton);
        this.Controls.Add(this.SecondButton);
        this.Controls.Add(this.ThirdButton);
        this.Controls.Add(this.FourthButton);
        this.Name = "GUI";
        this.Text = "Apocrypha";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(ClosingButton_click);
        this.ResumeLayout(true);
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
        this.ThirdButton.Hide();
        this.FourthButton.Hide();
    }
    /// <summary>
    /// Shows the pertinent main screen components.
    /// </summary>
    private void ShowComponents()
    {
        this.FirstButton.Show();
        this.SecondButton.Show();
        this.ThirdButton.Show();
        this.FourthButton.Show();
    }
    #endregion

}