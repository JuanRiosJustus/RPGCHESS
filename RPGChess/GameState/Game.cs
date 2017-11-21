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
using System.Windows.Forms;

namespace RPGChess.GameState
{
    class Game
    {
        private Board board;
        private SGLArrayList<Character> list;
        private Character CurrentCharacter;
        private int CurrentCharacterIndex = 0;


        public Game()
        {
            board = new Board();
            list = board.GetBoardedCharacters();
            board.GenerateMap(Universal.Rows, Universal.Columns);

            RandomBoard();
        }
        public void MoveCharacter(Character character)
        {

            //character.SetTile
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
        /// <summary>
        /// Moves the given character given a key.
        /// </summary>
        /// <param name="f"></param>
        /// <param name="direction"></param>
        public void MoveCharacter(PictureBox f, Direction direction)
        {
            SGLArrayList<Tile> tiles = new SGLArrayList<Tile>();
            Tile userSelectedTile;
            Character character = list.Get(CurrentCharacterIndex);
            if (character.GetTileQuantity() < 0) { return; }
            for (int i = 0; i < character.GetTileQuantity(); i++)
            {
                tiles.Add(character.GetTile(i));
            }
            
            userSelectedTile = TileLogic.ListRespectingDirection(character.EntityTile,tiles,direction);
            
            
            
            //Console.WriteLine(tiles.ToString() + " are the available tiles");
            // CALL THE CONTROLLER AND allow user to pick locatio with combo box

            // THIS IS CHOSEN BY THE USER.
            //Console.WriteLine(userSelectedTile.ToCoordinate() + " was chosen");
            board.MoveCharacter(character, userSelectedTile);
            f.Refresh();
            f.Update();
            //Console.WriteLine("Available tiles after: " + character.ListOfTiles());
            //Console.WriteLine(character.GetSurname() + " was moved");
            
        }
        /// <summary>
        /// Initializes the character to the board at a particular location.
        /// </summary>
        /// <param name="characterClass"></param>
        /// <param name="characterName"></param>
        /// <param name="row"></param>
        /// <param name="col"></param>
        public void InitCharacter(string characterClass, string characterName, int row, int col)
        {
            board.InitCharacter(characterClass, characterName, row, col);
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
