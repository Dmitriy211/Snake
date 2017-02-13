using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            Worm worm = new Worm();
            Food food = new Food();
            Wall wall = new Wall(1);
            
            while (worm.isAlive)
            {
                Console.Clear();
                worm.Draw();
                food.Draw();
                wall.Draw();
                bool k = false;
                for (int i = 0; i < wall.bricks.Count; i++)
                    if (wall.bricks[i].x == worm.body[0].x && wall.bricks[i].y == worm.body[0].y)
                    {
                        k = true;
                        break;
                    }

                if (k == true)
                    break;

                ConsoleKeyInfo pressedKey = Console.ReadKey();
                switch (pressedKey.Key)
                {
                    case ConsoleKey.UpArrow:
                        worm.Move(0, -1);
                        break;
                    case ConsoleKey.DownArrow:
                        worm.Move(0, 1);
                        break;
                    case ConsoleKey.LeftArrow:
                        worm.Move(-1, 0);
                        break;
                    case ConsoleKey.RightArrow:
                        worm.Move(1, 0);
                        break;
                    case ConsoleKey.Escape:
                        worm.isAlive = false;
                        break;
                }

                if (worm.CanEat(food))
                {
                    food = new Food();
                }
            }

            Console.Clear();
            Console.WriteLine("GAME OVER");

        }
    }
}
