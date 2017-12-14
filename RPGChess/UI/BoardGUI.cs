using System;
using System.Drawing;
using System.Windows.Forms;

/// <summary>
/// Defines the board where things will be drawn on.
/// </summary>
public partial class BoardGUI : Form
{
    private Random random = new Random();
    private ClientSocket cl;
    private ServerSocket ss;
    
    public BoardGUI(Player p1, Player p2)
    {
        // TODO
        InitializeComponent();
        this.Controller = new ControllerGUI(p1);
        this.Game = new Game(p1, p2, this.Controller, this.Display, this);
        Controller.Show();
        
    }
    /// <summary>
    /// Method occurs on paint.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Canvas_Paint(object sender, PaintEventArgs e)
    {
        g = e.Graphics;
        g.ScaleTransform(.75f, .75f);
        g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

        if (backgroundIsDeveloped == false)
        {
            this.Display.BackgroundImage = this.SetBackground(g);
        }

        Draw();
    }
    /// <summary>
    /// Draws the contents to the GUI
    /// </summary>
    private void Draw()
    {
        for (int row = 0; row < Game.GetBoardLength(0); row++)
        {
            for (int col = 0; col < Game.GetBoardLength(1); col++)
            {
                Tile tile = Game.GetBoardTile(row, col);
                
                if (tile.IsOccupied())
                {
                    g.DrawImage(tile.Occupant.IMAGE_OF_ENTITY, tile.X + 5, tile.Y);

                    Character cha = (Character)tile.Occupant;
                    for (int i = 0; i < cha.GetOccuableTileQuantity(); i++)
                    {
                        Tile t = cha.GetOccuableTile(i);
                        if (tile.Occupant != t.Occupant)
                        {
                            g.DrawString(t.Height + "", Font, Brushes.Black, t.X + 15, t.Y + 5);
                            g.DrawString(t.ToCoordinate(), Font, Brushes.Black, t.X + 5, t.Y + 15);
                        }
                    }
                }
            }
        }
    }
    //
    /// <summary>
    /// Method occurs when button is pressed.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public void GameGUI_Press(object sender, KeyPressEventArgs e)
    {
        Controller.Show();
        /*
        //TODO when the controlelr has been had t acepted button pressed
        //make srue to update the character postion.
        if (e.KeyChar == 'w' || e.KeyChar == 'W')
        {
            //Game.MoveCharacter(this.Display, Direction.NORTH);
            Game.HardUpdate(Controller.GetTileComboBox(), null);
        }
        else if (e.KeyChar == 's' || e.KeyChar == 'S')
        {
            //Game.MoveCharacter(this.Display, Direction.SOUTH);
            Game.HardUpdate(Controller.GetTileComboBox(), null);
        }
        else if (e.KeyChar == 'a' || e.KeyChar == 'A')
        {
            //Game.MoveCharacter(this.Display, Direction.WEST);
            Game.HardUpdate(Controller.GetTileComboBox(), null);
        }
        else if (e.KeyChar == 'd' || e.KeyChar == 'D')
        {
            //Game.MoveCharacter(this.Display, Direction.EAST);
            Game.HardUpdate(Controller.GetTileComboBox(), null);
        }*/

        // To escape the game.
        if (e.KeyChar == (char)27)
        {
            // When the escape key is pressed
            Environment.Exit(0);
        }
    }
    public void ControllerConnector()
    {

    }
}