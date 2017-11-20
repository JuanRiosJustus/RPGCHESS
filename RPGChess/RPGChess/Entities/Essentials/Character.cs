using RPGChess.Overworld;
using RPGChess.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGChess.Entities
{
    class Character : Entity
    {
        private int Movement;
        private int Health;
        private int Resist;
        private int Damage;

        private Direction Character_Direction;
        private int Level;
        private int StepsToLevel;
        private int Steps;
        private string Initials;

        private SGLArrayList<Tile> AvailableTiles;

        public Character(string name_of_entity, Class type_of_class) : base(name_of_entity, type_of_class)
        {
            NAME_OF_ENTITY = name_of_entity;
            TYPE_OF_CLASS = type_of_class;
            AvailableTiles = new SGLArrayList<Tile>();
            Character_Direction = Direction.NORTH;
            CalculateBaseStats();
            Level = 1;
        }
        private void CalculateBaseStats()
        {
            Movement = TYPE_OF_CLASS.Movement;
            Health = TYPE_OF_CLASS.Health;
            Resist = TYPE_OF_CLASS.Resist;
            Damage = TYPE_OF_CLASS.Damage;
        }

        public void SetTile(Tile tile, Tile[,] map)
        {
            base.SetTile(tile);
        }

        public void AddTile(Tile tile)
        {
            AvailableTiles.Add(tile);
        }
        public string TilesToString()
        {
            return AvailableTiles.ToString();
        }

        public void SetDirection(Direction direction) { Character_Direction = direction; }
        public Direction GetDirection() { return Character_Direction; }
        public void SetMovement(int movement) { Movement = movement;}
        public int GetMovement() { return Movement; }
        public void SetHealth(int health) { Health = health; }
        public int GetHealth() { return Health; }
        public void SetResist(int resist) { Resist = resist; }
        public int GetResist() { return Resist; }
        public void SetDamage(int damage) { Damage = damage; }
        public int GetDamage() { return Damage; }

        public void CheckIfCanLevel()
        {
            if (Steps >= StepsToLevel)
            {
                Level++;
                StepsToLevel = StepsToLevel * 2;
                IncreaseStats();
            }
        }

        private void IncreaseStats()
        {
            if (TYPE_OF_CLASS == Class.ARCHER)
            {

            }
            else if (TYPE_OF_CLASS == Class.MAGE)
            {

            }
            else if(TYPE_OF_CLASS == Class.MONK)
            {

            }
            else if(TYPE_OF_CLASS == Class.ROGUE)
            {

            }
            else if (TYPE_OF_CLASS == Class.WARRIOR)
            {

            }
            else if (TYPE_OF_CLASS == Class.MONSTER)
            {

            }
        }

        public string GetSurname() { return NAME_OF_ENTITY + " " + TYPE_OF_CLASS.ToString(); }

        public override string ToString()
        {
            return "[N:" + NAME_OF_ENTITY.ToString() + "][L:" + Level + "][C:" + TYPE_OF_CLASS.Type + "]";
        }
    }
}
