namespace Labb_2
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

    abstract class Enemy : LevelElement
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public Dice AttackDice { get; set; }
        public Dice DefenceDice { get; set; }

        public abstract void Update();
    }

    class Rat : Enemy
    {
        public Rat(int x, int y)
        {
            xCoordinate = x;
            yCoordinate = y;
            ClassChar = 'R';
            ClassColor = ConsoleColor.Red;
            Name = "Rat";
            Health = 10;
            AttackDice = new Dice(1, 4);
            DefenceDice = new Dice(1, 2);
        }
        public override void Update()
        {
            // Implement rat behavior here
        }
    }

    class Snake : Enemy
    {
        public Snake(int x, int y)
        {
            xCoordinate = x;
            yCoordinate = y;
            ClassChar = 'S';
            ClassColor = ConsoleColor.Green;
            Name = "Snake";
            Health = 15;
            AttackDice = new Dice(1, 6);
            DefenceDice = new Dice(1, 3);
        }
        public override void Update()
        {
            // Implement snake behavior here
        }
    }
}