using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGChess.Entities
{
    class Class
    {
        public static readonly Class ARCHER = new Class("Archer", 0, 0, 0, 0, 0, 0);
        public static readonly Class MAGE = new Class("Mage", 0, 0, 0, 0, 0, 0);
        public static readonly Class MONK = new Class("Monk", 0, 0, 0, 0, 0, 0);
        public static readonly Class ROGUE = new Class("Rogue", 0, 0, 0, 0, 0, 0);
        public static readonly Class WARRIOR = new Class("Warrior", 0, 0, 0, 0, 0, 0);

        public static readonly Class MONSTER = new Class("Monster", 0, 0, 0, 0, 0, 0);
        public static readonly Class MULTICLASS = new Class("Multiclass", 0, 0, 0, 0, 0, 0);

        private readonly string CLASS_TYPE;
        private readonly int BASE_MOVEMENT;
        private readonly int BASE_HEALTH;
        private readonly int BASE_REGEN;
        private readonly int BASE_RESIST;
        private readonly int BASE_DAMAGE;
        private readonly int BASE_RANGE;

        public Class(string class_type, int base_movement, int base_health, int base_regen, int base_resist, int base_damage, int base_range)
        {
            CLASS_TYPE = class_type;
            BASE_MOVEMENT = base_movement;
            BASE_HEALTH = base_health;
            BASE_REGEN = base_regen;
            BASE_RESIST = base_resist;
            BASE_DAMAGE = base_damage;
            BASE_RANGE = base_range;
        }

        public static IEnumerable<Class> Values
        {
            get
            {
                yield return ARCHER;
                yield return MAGE;
                yield return MONK;
                yield return ROGUE;
                yield return WARRIOR;
                yield return MONSTER;
                yield return MULTICLASS;
            }
        }

        public string Type { get { return CLASS_TYPE; } }
        public int Movement { get { return BASE_MOVEMENT; } }
        public int Health { get { return BASE_HEALTH; } }
        public int Regen { get { return BASE_REGEN; } }
        public int Resist { get { return BASE_RESIST; } }
        public int Damage { get { return BASE_DAMAGE; } }
        public int Range {  get { return BASE_RANGE;  } }

        public override string ToString()
        {
            return "the " + CLASS_TYPE;
        }
    }
}