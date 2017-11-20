using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGChess.Entities.Essentials
{
    class EntityFactory
    {
        public static Character BuildClass(string class_type, string name)
        {
            switch(class_type.ToLower())
            {
                case "archer": return new Character(name, Class.ARCHER);
                case "cleric": return new Character(name, Class.CLERIC);
                case "mage": return new Character(name, Class.MAGE);
                case "monk": return new Character(name, Class.MONK);
                case "rogue": return new Character(name, Class.ROGUE);
                case "warrior": return new Character(name, Class.WARRIOR);
                default: return new Character(name, Class.MONSTER);
            }
        }
    }
}
