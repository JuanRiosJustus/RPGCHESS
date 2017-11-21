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
            //Application.Run(new ControllerGUI());

            
            //BoardStart();
            Console.ReadKey();
        }
    }
}
