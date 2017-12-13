using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

partial class BoardGUI
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
    
    private System.Windows.Forms.PictureBox Display;
    private ControllerGUI Controller;
    private Font MainFont;
    private Game Game;
    private Graphics g;
    private bool backgroundIsDeveloped;

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        this.Display = new System.Windows.Forms.PictureBox();
        this.MainFont = new Font("Times New Roman", 16.0f);
        this.g = null;
        this.backgroundIsDeveloped = false;
        this.SuspendLayout();
        // 
        // Display
        // 
        this.Display.Dock = System.Windows.Forms.DockStyle.Fill;
        this.Display.Location = new System.Drawing.Point(0, 0);
        this.Display.Name = "Display";
        this.Display.Size = new System.Drawing.Size(774, 462);
        this.Display.TabIndex = 1;
        this.Display.BackColor = System.Drawing.Color.Black;
        this.Display.Paint += new System.Windows.Forms.PaintEventHandler(Canvas_Paint);
        // 
        // BoardGUI
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.MinimizeBox = false;
        this.MaximizeBox = false;
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        this.DoubleBuffered = true;
        this.ClientSize = new System.Drawing.Size(Global.WindowWidth, Global.WindowHeight);
        this.Controls.Add(this.Display);
        this.Name = "BoardGUI";
        this.Text = "Board";
        this.KeyPreview = true;
        this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(GameGUI_Press);
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.ResumeLayout(false);

    }
    /// <summary>
    /// Sets the background of the board.
    /// </summary>
    /// <param name="g"></param>
    /// <returns></returns>
    private Image SetBackground(Graphics g)
    {
        Bitmap bitmap = new Bitmap(Convert.ToInt32(this.Display.Width * 2), Convert.ToInt32(this.Display.Height + 800), PixelFormat.Format32bppArgb);
        g = Graphics.FromImage(bitmap);

        for (int row = 0; row < Game.GetBoardLength(0); row++)
        {
            for (int col = 0; col < Game.GetBoardLength(1); col++)
            {
                Tile tile = Game.GetBoardTile(row, col);

                g.DrawImage(tile.TileImage, tile.X, tile.Y);
            }
        }

        bitmap.Save(@"..\..\Assets\Tiles\Board.PNG", ImageFormat.Png);
        Image result = new Bitmap(@"..\..\Assets\Tiles\Board.PNG");
        this.backgroundIsDeveloped = true;
       
        return ImageManager.ResizeImage(result, this.Display.Width, this.Display.Height);
    }
}