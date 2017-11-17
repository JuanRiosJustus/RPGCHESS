using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGChess.Entities
{
    class Character : Entity
    {
        public Character(string entityName, Type entityObject) : base(entityName, entityObject)
        {
        }
    }
}
