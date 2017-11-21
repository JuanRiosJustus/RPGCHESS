using RPGChess.Overworld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGChess.Entities
{
    class Entity
    {
        protected internal string NAME_OF_ENTITY;
        protected internal Class TYPE_OF_CLASS;
        protected internal Tile EntityTile { get; private set; }

        public Entity(string name_of_entity, Class type_of_class)
        {
            NAME_OF_ENTITY = name_of_entity;
            TYPE_OF_CLASS = type_of_class;
        }
        /// <summary>
        /// Sets this entities tile reference to the given tile.
        /// Also sets the given tile's reference to this entity.
        /// </summary>
        /// <param name="tile"></param>
        public virtual void SetTile(Tile tile)
        {
            this.EntityTile = tile;
            if (Object.ReferenceEquals(EntityTile.Occupant, this) == false && tile != null)
            {
                EntityTile.SetOccupant(this);
            }
        }
        public override string ToString()
        {
            return NAME_OF_ENTITY + " the " + TYPE_OF_CLASS.ToString();
        }
    }
}
