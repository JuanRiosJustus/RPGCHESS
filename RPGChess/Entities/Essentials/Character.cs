﻿using RPGChess.Utility;
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
        private int Steps;
        private string Initials;

        public Character(string name_of_entity, Class type_of_class) : base(name_of_entity, type_of_class)
        {
            NAME_OF_ENTITY = name_of_entity;
            TYPE_OF_CLASS = type_of_class;
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

        public string GetSurname() { return NAME_OF_ENTITY + " " + TYPE_OF_CLASS.ToString(); }

        public override string ToString()
        {
            return "[N:" + NAME_OF_ENTITY.ToString() + "][L:" + Level + "][T:" + TYPE_OF_CLASS.Type + "]";
        }
    }
}