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
        protected readonly string EntityName;
        protected readonly Type EntityType;
        public Tile EntityTile { get; private set; }

        public Entity(string entityName, Type entityType)
        {
            EntityName = entityName;
            EntityType = entityType;
        }
        /// <summary>
        /// Sets this entities tile reference to the given tile.
        /// Also sets the given tile's reference to this entity.
        /// </summary>
        /// <param name="tile"></param>
        public void SetTile(Tile tile)
        {
            this.EntityTile = tile;
            if (Object.ReferenceEquals(EntityTile.Occupant, this) == false)
            {
                EntityTile.SetOccupant(this);
            }
        }
        public override string ToString()
        {
            return EntityName + " the " + EntityType.ToString();
        }
    }
}
