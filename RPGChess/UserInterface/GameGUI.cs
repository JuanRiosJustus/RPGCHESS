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
        Board board = new Board();
        Graphics g = null;

        Font font = new Font("Times New Roman", 8.0f);
        public GameGUI()
        {
            InitializeComponent();
            board.GenerateMap(Universal.Rows, Universal.Columns);
            board.GenerateDevelopAt(16, 7, 9);
            board.GenerateDevelopAt(11, 5, 9);
            board.GenerateDevelopAt(8, 26, -9);

            Random rand = new Random();
            for (int i = 0; i < 20; i++)
            {
                int col = rand.Next(Universal.Columns);
                int row = rand.Next(Universal.Rows);
                int z = rand.Next(8);
                board.GenerateDevelopAt(row, col, z);
            }
        }

        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            Pen black = new Pen(Brushes.Black, 18); // relates to boxsize
            
            for (int row = 0; row < board.GetBoardSize(0); row++)
            {
                for(int col = 0; col < board.GetBoardSize(1); col++)
                {
                    Tile tile = board.GetTile(row, col);

                    g.DrawRectangle(black, tile.GetScreenX(), tile.GetScreenY(), tile.GetScreenWH(), tile.GetScreenWH());

                    switch(tile.Biome)
                    {
                        case "WTR":
                            {
                                g.DrawString(tile.ToStandard(), font, Brushes.RoyalBlue, tile.GetScreenX() - 7, tile.GetScreenY() - 5);
                            }
                            break;
                        case "LWL":
                            {
                                g.DrawString(tile.ToStandard(), font, Brushes.LightSteelBlue, tile.GetScreenX() - 7, tile.GetScreenY() - 5);
                            }
                            break;
                        case "PLN":
                            {
                                g.DrawString(tile.ToStandard(), font, Brushes.Beige, tile.GetScreenX() - 7, tile.GetScreenY() - 5);
                            }
                            break;
                        case "HLL":
                            {
                                g.DrawString(tile.ToStandard(), font, Brushes.YellowGreen, tile.GetScreenX() - 7, tile.GetScreenY() - 5);
                            }
                            break;
                        case "MTN":
                            {
                                g.DrawString(tile.ToStandard(), font, Brushes.ForestGreen, tile.GetScreenX() - 7, tile.GetScreenY() - 5);
                            }
                            break;

                    }
                }
            }
            

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
