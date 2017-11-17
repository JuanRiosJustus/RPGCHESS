using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGChess.Entities
{
    class BaseClass
    {
        public static readonly Type MAGE = new Type("Mage", 0, 0, 0, 0, 0);
        public static readonly Type WARRIOR = new Type("Warrior", 0, 0, 0, 0, 0);
        public static readonly Type ARCHER = new Type("Archer", 0, 0, 0, 0, 0);

        public static readonly Type MONSTER = new Type("Monster", 0, 0, 0, 0, 0);
        public static readonly Type LOOT = new Type("Loot", 0, 0, 0, 0, 0); 
    }
}
