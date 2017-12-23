using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

/// <summary>
/// Defines the board where things will be drawn on.
/// </summary>
public partial class GameGUI : Form
{
    private Random random = new Random();
    private ClientSocket cl;
    private ServerSocket ss;
    private Animation an = new Animation(@"..\unnamed.gif");
    
    public GameGUI()
    {
        //Animation an = new Animation(@"..\unnamed.gif");
        an.ReverseAtEnd = true;
        InitializeComponent();
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
        

        for (int row = 0; row < ConnectedGame.GetBoardLength(0); row++)
        {
            for (int col = 0; col < ConnectedGame.GetBoardLength(1); col++)
            {
                Tile tile = ConnectedGame.GetBoardTile(row, col);

                


                if (tile.IsOccupied())
                {
                    g.DrawImage(tile.Occupant.IMAGE_OF_ENTITY, tile.Coordinate.X + 5, tile.Coordinate.Y);

                    Character cha = (Character)tile.Occupant;
                    
                    List<Tile> tiles = ConnectedGame.GetOccuableTilesFromEntity(cha);

                    for (int i = 0; i < tiles.Count; i++)
                    {
                        Tile t = tiles[i];

                        if (t != tile)
                        {
                            g.DrawString(t.Height + "", Font, Brushes.Black, t.Coordinate.X + 15, t.Coordinate.Y + 5);
                            g.DrawString(t.ToCoordinate(), Font, Brushes.Black, t.Coordinate.X + 5, t.Coordinate.Y + 15);
                        }
                    }
                }
            }
        }
        if (this.AnimateAttack == true)
        {
            for (int i = 0; i < an.Frames; i++)
            {
                Point p = this.LatestChara.COORDINATE_OF_ENTITY;
                g.DrawImage(an.GetFrame(i), p.X - 100, p.Y);
                Thread.Sleep(100);
                Console.WriteLine("GGGg");
            }
            this.AnimateAttack = false;
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