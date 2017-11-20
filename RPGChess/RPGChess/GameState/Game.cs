using RPGChess.Entities;
using RPGChess.Entities.Essentials;
using RPGChess.Overworld;
using RPGChess.Utility;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGChess.GameState
{
    class Game
    {
        private Board board;
        private ArrayList heros;


        public Game()
        {
            board = new Board();
            heros = new ArrayList();
            board.GenerateMap(Universal.Rows, Universal.Columns);

            RandomBoard();

            heros.Add(EntityFactory.BuildClass("mage", "Aystogon"));
            heros.Add(EntityFactory.BuildClass("archer", "Angler"));
            //Console.WriteLine(mage.To);
            //board.AddCharacter((Character)heros[0], 5, 4);
            Random random = new Random();
            board.AddCharacter((Character)heros[1], random.Next(Universal.Rows), random.Next(Universal.Columns));

        }
        public void MoveCharacter(Character cha, Direction dir)
        {

            //board.MoveCharacter(archer, Direction.EAST);
        }
        public Tile GetBoardTile(int x, int y)
        {
            return board.GetTile(x, y);
        }
        public int GetBoardLength(int dimension)
        {
            return board.GetBoardSize(dimension);
        }


        private void RandomBoard()
        {
            board.GenerateDevelopAt(14, 7, 9);
            board.GenerateDevelopAt(11, 5, 9);
            board.GenerateDevelopAt(8, 26, -9);
            board.GenerateDevelopAt(4, 6, -9);

            Random rand = new Random();
            for (int i = 0; i < 90; i++)
            {
                int col = rand.Next(Universal.Columns);
                int row = rand.Next(Universal.Rows);
                int z = rand.Next(8);
                board.GenerateDevelopAt(row, col, z);
            }

            for (int i = 0; i < 10; i++)
            {
                int col = rand.Next(Universal.Columns);
                int row = rand.Next(Universal.Rows);
                int z = rand.Next(-8, 0);
                board.GenerateDevelopAt(row, col, z);
            }
        }
    }
}
