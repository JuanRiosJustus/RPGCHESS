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

    private Character CurrentChara;
    private bool HasMoved;
    private bool HasAttacked;
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
        this.CurrentChara = null;
        this.backgroundIsDeveloped = false;
        this.HasMoved = false;
        this.HasAttacked = false;
        this.IsMoving = false;
        this.IsAttacking = false;
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
    /// Determines the actions based on user mouse input 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public void MouseClickOnScreen(object sender, MouseEventArgs e)
    {
        if (this.HasAttacked == true && this.HasMoved == true)
        {
            Console.WriteLine("Nothing else to do.....");
            this.Controller.AppendToGameLog("Turn Over");
            return;
        }
        // Get the respective tile.
        int col = (int)(e.X / 26.25);
        int row = (e.Y / 26);
        Tile t = Game.GetBoardTile(row, col);

        
        /********** USER IS SELECTING A UNIT/CHARACTER **********/
        // determine if the player is attacking based on the character they selected.
        if (CurrentChara == null && t.IsOccupied() == true)
        {
            Character c = (Character)t.Occupant;
            
            // moving the character.
            if (c.RELATION_OF_ENTITY == Relation.Friendly && (this.HasAttacked == false || this.HasMoved == false))
            {
                this.CurrentChara = c;
                this.IsMoving = true;
                Console.WriteLine(c.ToString() + " is selected");
                this.Controller.RewriteSelectedUnitTextBox(c.ToString());
                this.Controller.RewriteUnitStatusLabelTextBox(c.GetStatus());
                this.Controller.RewriteFromTextBox(c.TILE_OF_ENTITY.ToString());
                this.Controller.RewriteExpTextBox(c.GetExpStatus());
                this.Controller.RefreshTeamTextBox();
                return;
            }
            Console.WriteLine("W?W?W?W?W?W?W??W?W?W?W?W?W?W?W?W?W?W?W?WW??W?W?W?W?W?W?W");
        }
        /********** WERE ATTACKING **********/
        if (CurrentChara != null && t.IsOccupied() == true && this.HasAttacked == false)
        {
            // we are attacking.
            for (int i = 0; i < this.CurrentChara.GetAttackableCharacterQuantity(); i++)
            {
                // check that the player is attackable
                Character c = (Character)t.Occupant;

                if (this.CurrentChara.GetAttackableEntity(i) == c)
                {
                    this.Controller.AppendToGameLog(CurrentChara.NAME_OF_ENTITY + " has attacked " + c.NAME_OF_ENTITY);

                    Console.WriteLine("IMPLEMENT COMBAT BECAUSE YOU HIT SOMEONE >:( ");
                    //this.Controller.RewriteSelectedUnitTextBox("");
                    this.Controller.RewriteDefendingUnitTextBox(c.ToString());
                    this.Controller.RewriteDefendingUnitStatus(c.GetStatus());
                    this.Controller.RefreshTeamTextBox();
                    this.CurrentChara = null;
                    this.HasAttacked = true;
                    return;
                }
            }
        }
        /********** WERE MOVING **********/
        if (CurrentChara != null && t.IsOccupied() == false && this.HasMoved == false)
        {
            for (int i = 0; i < this.CurrentChara.GetOccuableTileQuantity(); i++)
            {
                if (this.CurrentChara.GetOccuableTile(i) == t)
                {
                    this.Controller.AppendToGameLog(CurrentChara.NAME_OF_ENTITY + " has moved from " + CurrentChara.TILE_OF_ENTITY.ToString() + " to " + t.ToString());
                    
                    this.Game.MoveCharacter(this.CurrentChara, t);
                    ////////////////////////////////////////////////////////////
                    for (int k = 0; k < this.CurrentChara.GetAttackableCharacterQuantity(); k++)
                    {
                        this.Controller.AppendToGameLog(CurrentChara.GetAttackableEntity(k).NAME_OF_ENTITY + " is within range of " + CurrentChara.NAME_OF_ENTITY);
                    }
                    ///////////////////////////////////////////////////////////
                    this.Controller.RewriteToTextBox(t.ToString());
                    this.Controller.RefreshTeamTextBox();
                    this.CurrentChara = null;
                    this.HasMoved = true;

                    

                    return;
                }
            }
        }
        /********** NOTHING WAS DONE THIS TURN ?? **********/
        Console.WriteLine("Nothing was done this turn");
        this.RRfresh();
        if (this.HasAttacked && this.HasMoved)
        {
            this.Controller.AppendToGameLog("Turn Over");
        }
        this.CurrentChara = null;
    }
    public void RRfresh()
    {
        this.IsMoving = false;
        this.IsAttacking = false;
        this.HasMoved = false;
        this.HasAttacked = false;
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