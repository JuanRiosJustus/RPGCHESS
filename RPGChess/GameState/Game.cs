using RPGChess.Overworld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGChess.GameState
{
     class Game
    {
        private static Board Game_Board;
        public static int RowsOfTiles;
        public static int ColumnsOfTiles;

        public Game(Board game_board)
        {
            Game_Board = game_board;
        }
        public static void ConstructBoard(int rows, int columns)
        {
            // 32, 18

        }
       
    }
}
