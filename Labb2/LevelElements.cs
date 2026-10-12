using System;
using System.Collections.Generic;
using System.Text;

namespace Labb2
{
    abstract class LevelElement
    {
        public int xCoordinate { get; set; }
        public int yCoordinate { get; set; }
        public char ClassChar { get; set; }
        public ConsoleColor ClassColor { get; set; }

        public void Draw()
        {
            Console.SetCursorPosition(xCoordinate, yCoordinate);
            Console.ForegroundColor = ClassColor;
            Console.Write(ClassChar);
        }
    }

    class Wall : LevelElement
    {
        public Wall(int x, int y)
        {
            xCoordinate = x;
            yCoordinate = y;
            ClassChar = '#';
            ClassColor = ConsoleColor.Gray;
        }
    }

    class Player : LevelElement
    {
        public int Health { get; set; }
        public Dice AttackDice { get; set; }
        public Dice DefenceDice { get; set; }


        public Player(int x, int y)
        {
            xCoordinate = x;
            yCoordinate = y;
            ClassChar = '@';
            ClassColor = ConsoleColor.Green;
            Health = 100;
            AttackDice = new Dice(2, 6, 2);
            DefenceDice = new Dice(2, 6, 0);
        }

        public (int x, int y) Update(ConsoleKey key)
        {
            
            int newX = xCoordinate;
            int newY = yCoordinate;

            switch (key)
            {
                case ConsoleKey.LeftArrow:
                    newX = xCoordinate - 1;
                    break;

                case ConsoleKey.RightArrow:
                    newX = xCoordinate + 1;
                    break;

                case ConsoleKey.UpArrow:
                    newY = yCoordinate - 1;
                    break;

                case ConsoleKey.DownArrow:
                    newY = yCoordinate + 1;
                    break;
            }
            return (newX, newY);
        }

        public void Move(int newX, int newY)
        {
            xCoordinate = newX;
            yCoordinate = newY;
        }
    }

    abstract class Enemy : LevelElement
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public Dice AttackDice { get; set; }
        public Dice DefenceDice { get; set; }

        public abstract (int x, int y) Update(Player player);

        public void Move(int newX, int newY)
        {
            xCoordinate = newX;
            yCoordinate = newY;
        }
    }

    class Rat : Enemy
    {
        public Rat(int x, int y)
        {
            xCoordinate = x;
            yCoordinate = y;
            ClassChar = 'r';
            ClassColor = ConsoleColor.Red;
            Name = "Rat";
            Health = 10;
            AttackDice = new Dice(1, 6, 3);
            DefenceDice = new Dice(1, 6, 1);
        }

        public override (int x, int y) Update(Player player)
        {
            var random = new Random();
            int direction = random.Next(1, 5);
            int newX = xCoordinate;
            int newY = yCoordinate;

            switch (direction)
            {
                case 1:
                    newX = xCoordinate - 1;
                    break;
                case 2:
                    newX = xCoordinate + 1;
                    break;
                case 3:
                    newY = yCoordinate + 1;
                    break;
                case 4:
                    newY = yCoordinate - 1;
                    break;
            }
            return (newX, newY);
        }
    }

    class Snake : Enemy
    {
        public Snake(int x, int y)
        {
            xCoordinate = x;
            yCoordinate = y;
            ClassChar = 's';
            ClassColor = ConsoleColor.Green;
            Name = "Snake";
            Health = 15;
            AttackDice = new Dice(3, 4, 2);
            DefenceDice = new Dice(1, 8, 5);
        }

        public override (int x, int y) Update(Player player)
        {
            int distance = Math.Abs(xCoordinate - player.xCoordinate)
                         + Math.Abs(yCoordinate - player.yCoordinate);

            int newX = xCoordinate;
            int newY = yCoordinate;

            if (distance > 2)
            {
                return (newX, newY);
            }

            if (xCoordinate != player.xCoordinate)
            {
                if (xCoordinate < player.xCoordinate)
                    newX--;
                else
                    newX++;
            }
            else if (yCoordinate != player.yCoordinate)
            {
                if (yCoordinate < player.yCoordinate)
                    newY--;
                else
                    newY++;
            }

            return (newX, newY);
        }
    }
}



