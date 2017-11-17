using RPGChess.Entities;
using RPGChess.Overworld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGChess
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board();
            board.GenerateMap(30, "Water");
            board.GeneralToConsole();
            board.GenerateAcross(-9, Option.ONE);
            board.GenerateAcross(-9, Option.THREE);
            Console.WriteLine("-------------------------------------------------------------");
            board.GeneralToConsole();
            Console.WriteLine("-------------------------------------------------------------");
            board.TopographToConsole();
            Console.ReadKey();
        }
    }
}
