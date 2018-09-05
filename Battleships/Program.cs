using System;
using Battleships.Players;

namespace Battleships
{
    class Program
    {
        static void Main(string[] args)
        {
            var humanPlayer = new HumanPlayer();
            var easyEnemy1 = new EasyEnemy();
            var easyEnemy2 = new EasyEnemy();
            var gameEngine = new GameEngine(easyEnemy1, humanPlayer);
            gameEngine.Start();
            Console.ReadLine();
        }
    }
}