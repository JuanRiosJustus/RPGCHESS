using RPGChess.Entities;
using RPGChess.Entities.Essentials;
using RPGChess.Overworld;
using RPGChess.UserInterface;
using RPGChess.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RPGChess
{
    class Program
    {
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new GameGUI());

            
            //BoardStart();
            Console.ReadKey();
        }

        static void BoardStart()
        {
            Board board = new Board();
            board.ToConsole(Board.View.Standard);
            board.GenerateAcross(-9, Option.THREE);
            Console.WriteLine("-------------------------------------------------------------");
            board.ToConsole(Board.View.Level);
            Console.WriteLine("-------------------------------------------------------------");
            board.ToConsole(Board.View.Standard);

            Character character = EntityFactory.BuildClass("mage", "Aystogon");
            Console.WriteLine(character.ToString());
            board.SetCharacter(character, 2, 5);
            board.ToConsole(Board.View.Standard);
            board.ToConsole(Board.View.Coordinate);
        }
    }
}
