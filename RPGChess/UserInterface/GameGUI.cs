using RPGChess.GameState;
using RPGChess.Overworld;
using RPGChess.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RPGChess.UserInterface
{
    public partial class GameGUI : Form
    {
        //Board board = new Board();
        Game game = new Game();
        Graphics g = null;
        private bool isHidden = false;

        Font font = new Font("Times New Roman", 6.0f);
        public GameGUI()
        {
            game.InitCharacter("Rogue", "Vess", 14, 24);
            InitializeComponent();
            
        }
        private void ConfigureScreen()
        {
            if (isFormFullyVisible(this) == false)
            {
                if (isHidden == false)
                {
                    this.Display.Invalidate(null);
                    DrawControl.SuspendDrawing(this);
                    this.Show();
                }
                isHidden = true;
            }
            else
            {
                if (isHidden)
                {
                    this.Enabled = true;
                    this.Display.Enabled = true;
                    isHidden = false;
                    DrawControl.ResumeDrawing(this);
                    Console.WriteLine("visible");
                }
            }
        }
        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;


            //ConfigureScreen();

            Draw_Map_To_Screen();
            
        }

        void GameGUI_Press(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 'w' || e.KeyChar == 'W')
            {
                Console.WriteLine(e.KeyChar + " is the string value.");
                
            }
            if (e.KeyChar == (char)27)
            {
                // When the escape key is pressed
                Environment.Exit(0);
                
            }
            //Console.WriteLine(e.KeyChar + " is the key");
        }

        private void Draw_Map_To_Screen()
        {


            Pen black = new Pen(Brushes.Black, 18); // relates to boxsize

            for (int row = 0; row < game.GetBoardLength(0); row++)
            {
                for (int col = 0; col < game.GetBoardLength(1); col++)
                {
                    Tile tile = game.GetBoardTile(row, col);

                    g.DrawRectangle(black, tile.GetScreenX(), tile.GetScreenY(), tile.GetScreenWH(), tile.GetScreenWH());

                    if (tile.IsOccupied())
                    {
                        //"[" + tile.Height + "]"
                        g.DrawString(tile.ToTopograph(), font, Brushes.MediumVioletRed, tile.GetScreenX() - 7, tile.GetScreenY() - 5);
                        g.DrawString(tile.ToCoordinate(), font, Brushes.MediumVioletRed, tile.GetScreenX() - 7, tile.GetScreenY() + 5);
                    }
                    else
                    {
                        switch (tile.Biome)
                        {
                            case "WTR":
                                {
                                    g.DrawString(tile.ToTopograph(), font, Brushes.Blue, tile.GetScreenX() - 7, tile.GetScreenY() - 5);
                                    g.DrawString(tile.ToCoordinate(), font, Brushes.Blue, tile.GetScreenX() - 7, tile.GetScreenY() + 5);
                                }
                                break;
                            case "LWL":
                                {
                                    g.DrawString(tile.ToTopograph(), font, Brushes.SkyBlue, tile.GetScreenX() - 7, tile.GetScreenY() - 5);
                                    g.DrawString(tile.ToCoordinate(), font, Brushes.SkyBlue, tile.GetScreenX() - 7, tile.GetScreenY() + 5);
                                }
                                break;
                            case "PLN":
                                {
                                    g.DrawString(tile.ToTopograph(), font, Brushes.Wheat, tile.GetScreenX() - 7, tile.GetScreenY() - 5);
                                    g.DrawString(tile.ToCoordinate(), font, Brushes.Wheat, tile.GetScreenX() - 7, tile.GetScreenY() + 5);
                                }
                                break;
                            case "FRS":
                                {
                                    g.DrawString(tile.ToTopograph(), font, Brushes.YellowGreen, tile.GetScreenX() - 7, tile.GetScreenY() - 5);
                                    g.DrawString(tile.ToCoordinate(), font, Brushes.YellowGreen, tile.GetScreenX() - 7, tile.GetScreenY() + 5);
                                }
                                break;
                            case "HLL":
                                {
                                    g.DrawString(tile.ToTopograph(), font, Brushes.Green, tile.GetScreenX() - 7, tile.GetScreenY() - 5);
                                    g.DrawString(tile.ToCoordinate(), font, Brushes.Green, tile.GetScreenX() - 7, tile.GetScreenY() + 5);
                                }
                                break;
                            case "MTN":
                                {
                                    g.DrawString(tile.ToTopograph(), font, Brushes.DarkGreen, tile.GetScreenX() - 7, tile.GetScreenY() - 5);
                                    g.DrawString(tile.ToCoordinate(), font, Brushes.DarkGreen, tile.GetScreenX() - 7, tile.GetScreenY() + 5);
                                }
                                break;
                        }
                    }
                }
            }
        }
        bool isPointVisibleOnAScreen(Point p)
        {
            foreach (Screen s in Screen.AllScreens)
            {
                if (p.X < s.Bounds.Right && p.X > s.Bounds.Left && p.Y > s.Bounds.Top && p.Y < s.Bounds.Bottom)
                    return true;
            }
            return false;
        }

        bool isFormFullyVisible(Form f)
        {
            return isPointVisibleOnAScreen(new Point(f.Left, f.Top)) && isPointVisibleOnAScreen(new Point(f.Right, f.Top)) 
                && isPointVisibleOnAScreen(new Point(f.Left, f.Bottom)) && isPointVisibleOnAScreen(new Point(f.Right, f.Bottom));
        }
        private void Button_Click( object sender, EventArgs e)
        {
            
        }
        private void Closing_Button(object sender, EventArgs e)
        {
            Application.Exit();
            Environment.Exit(0);
        }
    }
}
