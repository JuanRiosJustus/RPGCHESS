using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGChess.Entities
{
    class Type
    {
        public readonly string CLASS_TYPE;
        public readonly int BASE_MOVEMENT;
        public readonly int BASE_HEALTH;
        public readonly int BASE_RESIST;
        public readonly int BASE_DAMAGE;
        public readonly int BASE_RANGE;

        public Type(string class_type, int base_movement, int base_health, int base_resist, int base_damage, int base_range)
        {
            CLASS_TYPE = class_type;
            BASE_MOVEMENT = base_movement;
            BASE_HEALTH = base_health;
            BASE_RESIST = base_resist;
            BASE_DAMAGE = base_damage;
            BASE_RANGE = base_range;
        }

        public override string ToString()
        {
            return "Clss: " + CLASS_TYPE + ", Mvmnt:" + BASE_MOVEMENT + ", HP: " + BASE_HEALTH +
                ", Rst: " + BASE_RESIST + ", Dmg: " + BASE_DAMAGE + ", Rnge: " + BASE_RANGE;
        }
    }
}