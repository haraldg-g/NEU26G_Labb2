using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Xml.Linq;

namespace Labb2
{
    class Program
    {
        private static Player _player;
        private static LevelData _level;
        private static List<Wall> _discoveredWalls;

        public static List<Wall> DiscoveredWalls { get; } = new List<Wall>();

        static void Main(string[] args)
        {

            _level = new LevelData();
            _level.Load("level1.txt");
            _discoveredWalls = DiscoveredWalls;

            foreach (LevelElement element in _level.Elements)
            {
                if (element is Player player)
                {
                    _player = player;
                  
                }
  
            }

            foreach (LevelElement element in _level.Elements)
            {
                if (Math.Sqrt((_player.yCoordinate - element.yCoordinate) * (_player.yCoordinate - element.yCoordinate) + (_player.xCoordinate - element.xCoordinate) * (_player.xCoordinate - element.xCoordinate)) <= 5)
                {
                    if (element is Wall wall && !_discoveredWalls.Contains(wall))
                    {
                        _discoveredWalls.Add(wall);
                    }
                    element.Draw();
                }
            }

            // 3. Game loop
            while (_player.Health > 0)
            {
                
                ConsoleKeyInfo key = Console.ReadKey();
                Enemy enemyToRemove = null;

                // Kontrollera om spelaren får röra sig och gå in i combat om det är en enemy
                foreach (LevelElement element in _level.Elements)
                {
                    if (element is Player player)
                    {
                        (int x, int y) = player.Update(key.Key);
                        switch (GetElementAtPosition(x, y))
                        {
                            case null:
                                player.Move(x, y);
                                break;

                            case Wall wall:
                                break;

                            case Enemy enemy:
                                new Combat(player, enemy);
                                if (enemy.Health <= 0)
                                {
                                    enemyToRemove = enemy;
                                }
                                break;
                        }
                    }
                }

                // Ta bort enemy efter varje combat
                if (enemyToRemove != null)
                {
                    _level.Elements.Remove(enemyToRemove);
                    enemyToRemove = null;
                }

                // Uppdatera enemy och gå in i combat om den går in i player
                foreach (LevelElement element in _level.Elements)
                {
                    if (element is Enemy enemy)
                    {
                        (int x, int y) = enemy.Update(_player);
                        switch (GetElementAtPosition(x, y))
                        {
                            case null:
                            enemy.Move(x, y);
                                break;

                            case Wall wall:
                                break;

                            case Player player:
                                new Combat(enemy, _player);
                                if (enemy.Health <= 0)
                                {
                                    enemyToRemove = enemy;
                                }
                                break;
                        }                  
                    }
                }

                // Ta bort enemy igen 
                if (enemyToRemove != null)
                {
                    _level.Elements.Remove(enemyToRemove);
                    enemyToRemove = null;
                }

                // Rita om kartan
                Console.Clear();
                foreach (LevelElement element in _level.Elements)
                {
                    if (Math.Sqrt((_player.yCoordinate - element.yCoordinate) * (_player.yCoordinate - element.yCoordinate) + (_player.xCoordinate - element.xCoordinate) * (_player.xCoordinate - element.xCoordinate)) <= 5)
                    {
                        if (element is Wall wall && !_discoveredWalls.Contains(wall))
                        {
                            _discoveredWalls.Add(wall);
                        }
                        element.Draw();
                    }
                }
                foreach (Wall wall in _discoveredWalls)
                {
                    if (Math.Sqrt((_player.yCoordinate - wall.yCoordinate) * (_player.yCoordinate - wall.yCoordinate) + (_player.xCoordinate - wall.xCoordinate) * (_player.xCoordinate - wall.xCoordinate)) > 5)
                    {
                        wall.Draw();
                    }
                }
            }
        }
        static LevelElement GetElementAtPosition(int x, int y)
        {
            foreach (LevelElement element in _level.Elements)
            {
                if (element.xCoordinate == x && element.yCoordinate == y)
                {
                    return element;
                }
            }
            return null;
        }
    }
}


