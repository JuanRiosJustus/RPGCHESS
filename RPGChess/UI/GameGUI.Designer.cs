using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

partial class GameGUI
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
    private Font MainFont;
    private Game ConnectedGame;
    private Graphics g;
    private bool backgroundIsDeveloped;
    private float Ax;
    private float Ay;

    private Character LatestChara;
    private Character AttackedChara;
    private bool HasMoved;
    private bool HasAttacked;
    private bool AnimateAttack;
    private bool IsMoving;
    private bool IsAttacking;

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        this.Display = new System.Windows.Forms.PictureBox();
        this.MainFont = new Font("Times New Roman", 16.0f);
        this.g = null;
        this.LatestChara = null;
        this.AttackedChara = null;
        this.backgroundIsDeveloped = false;
        this.HasMoved = false;
        this.HasAttacked = false;
        this.IsMoving = false;
        this.IsAttacking = false;
        this.AnimateAttack = false;
        this.Ax = 0;
        this.Ay = 0;
        this.ConnectedGame = new Game(this);
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
        this.Display.MouseClick += new MouseEventHandler(this.MouseClickOnScreen);
        // 
        // GameGUI
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
        this.Name = "GameGUI";
        this.Text = "Board";
        this.KeyPreview = true;
        this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(GameGUI_Press);
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.ResumeLayout(false);

    }
    /// <summary>
    /// Determines the actions based on user mouse input 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public void MouseClickOnScreen(object sender, MouseEventArgs e)
    {
        if (this.ConnectedGame.TurnIsOver())
        {
            Console.WriteLine("Nothing else to do.....");
            //this.ConnectedGame.ResetTurn();
            return;
        }

        // Get the respective tile.
        int col = (int)(e.X / 26.25);
        int row = (e.Y / 26);
        if (row > Global.Rows|| col > Global.Columns-1) { return; }

        Tile currentTile = ConnectedGame.GetBoardTile(row, col);
        
        /********** USER IS SELECTING A UNIT/CHARACTER/ENTITY **********/
        // Check that the tile has a character and we are not currently holding a chacrarter
        if (this.ConnectedGame.IsFocusing() == false && currentTile.IsOccupied() == true)
        {
            Character c = (Character)currentTile.Occupant;
            
            // set the character if we have not attacked or moved this turn.
            if (c.RELATION_OF_ENTITY == Relation.Friend && (this.HasAttacked == false || this.HasMoved == false))
            {
                this.ConnectedGame.Focus(c);
                return;
            }
        }

        /********** WERE ATTACKING **********/
        // attacking if we have a selected character and the selecte tile is occupied and we hav not attacked,

        if (this.ConnectedGame.IsFocusing() && currentTile.IsOccupied() == true)
        {
            // check that the player is attackable
            Character target = (Character)currentTile.Occupant;
            Character targeter = this.ConnectedGame.GetFocusedCharcter();

            // chech that the player is attackable.
            if (this.ConnectedGame.IsTargetableByEntity(targeter, target))
            {
                this.AnimateAttack = true;
                this.LatestChara = target;
                this.ConnectedGame.CharacterCombat(targeter, target, e);
                
                return;
            }
        }
        /********** WERE MOVING **********/
        if (this.ConnectedGame.IsFocusing() && currentTile.IsOccupied() == false)
        {
            Character currentCha = this.ConnectedGame.GetFocusedCharcter();

            //Check if entity can occupy the tile
            if (this.ConnectedGame.IsOccuableByEntity(currentCha, currentTile))
            {
                this.ConnectedGame.MoveCharacter(currentCha, currentTile);
                return;
            }
        }

        /********** NOTHING WAS DONE THIS TURN  **********/
        this.ConnectedGame.AppendToGameLog("Nothing was done...");
        this.ConnectedGame.Unfocus();
        this.ConnectedGame.ResetTurn();
    }
    /// <summary>
    /// Returns the picture box component of this gui.
    /// </summary>
    /// <returns></returns>
    public PictureBox GetDisplay()
    {
        return this.Display;
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

        for (int row = 0; row < ConnectedGame.GetBoardLength(0); row++)
        {
            for (int col = 0; col < ConnectedGame.GetBoardLength(1); col++)
            {
                Tile tile = ConnectedGame.GetBoardTile(row, col);

                g.DrawImage(tile.TileImage, tile.Coordinate.X, tile.Coordinate.Y);
            }
        }

        bitmap.Save(@"..\..\Assets\Backgrounds\Board.PNG", ImageFormat.Png);
        Image result = new Bitmap(@"..\..\Assets\Backgrounds\Board.PNG");
        this.backgroundIsDeveloped = true;
       
        return ImageManager.ResizeImage(result, this.Display.Width, this.Display.Height);
    }
}