using RPGChess.Entities;
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
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new GameGUI());

            
            BoardStart();
            Console.ReadKey();
        }

        static void BoardStart()
        {
            Board board = new Board();
            board.GenerateMap(15, "GRND");
            board.ToConsole(Board.View.Standard);
            board.GenerateAcross(-9, Option.THREE, "WTR");
            Console.WriteLine("-------------------------------------------------------------");
            board.ToConsole(Board.View.Level);
            Console.WriteLine("-------------------------------------------------------------");
            board.ToConsole(Board.View.Standard);

            Character character = new Character("Eli", Class.ARCHER);
            Console.WriteLine(character.ToString());
            board.SetCharacter(character, 2, 5);
            board.ToConsole(Board.View.Standard);
            board.ToConsole(Board.View.Coordinate);
        }
    }
}
