using System;

namespace Battleships.Board.Enums
{
    public enum Direction
    {
        West,
        North,
        East,
        South
    }

    public class Directions
    {
        private static Random _random;
        private static Random Random => _random ?? (_random = new Random());

        public static Direction GetRandom()
        {
            var random = Random.Next(4);
            return (Direction)random;
        }
    }
}