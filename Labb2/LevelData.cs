using System;
using System.Collections.Generic;
using System.Text;

namespace Labb2
{
    class LevelData
    {

        private List<LevelElement> _elements;

        public List<LevelElement> Elements { get; } = new List<LevelElement>();

        public void Load(string filename)
        {

            _elements = Elements;

            using (StreamReader sr = new StreamReader(filename)) 
            {
                int counter = 0;
                while (!sr.EndOfStream)
                {
                    string sLine = sr.ReadLine();
                    for (int i = 0; i < sLine.Length; i++)
                    {
                        if (sLine[i] == '#')
                        {
                            Wall wall = new Wall(i, counter);
                            _elements.Add(wall);
                        }
                        else if (sLine[i] == 'r')
                        {
                            Rat rat = new Rat(i, counter);
                            _elements.Add(rat);
                        }
                        else if (sLine[i] == 's')
                        {
                            Snake snake = new Snake(i, counter);
                            _elements.Add(snake);
                        }
                        else if (sLine[i] == '@')
                        {
                            Player player = new Player(i, counter);
                            _elements.Add(player);
                        }
                    }
                    counter++;
                }
                
            }
        }
        
    }
}
