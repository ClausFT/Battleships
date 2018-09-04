using System;
using Battleships.Players;

namespace Battleships
{
    class Program
    {
        static void Main(string[] args)
        {
            var humanPlayer = new HumanPlayer();
            var easyEnemy = new EasyEnemy();
            var gameEngine = new GameEngine(humanPlayer, easyEnemy);
            gameEngine.Start();
            Console.ReadLine();
        }
    }
}