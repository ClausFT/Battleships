using System;
using System.Linq;
using Battleships.Board.Entities;
using Battleships.Board.Enums;

namespace Battleships.Board.Services
{
    public class CoordinateService
    {
        private static Random _random;
        private static Random Random => _random ?? (_random = new Random());

        public static Coordinate GetNeighbour(Direction direction, Cell cell)
        {
            switch (direction)
            {
                case Direction.West:
                    return GetHorizontalNeighbour(cell, -1);

                case Direction.North:
                    return GetVerticalNeighbour(cell, -1);

                case Direction.East:
                    return GetHorizontalNeighbour(cell, 1);

                case Direction.South:
                    return GetVerticalNeighbour(cell, 1);
            }

            return null;
        }

        public static Coordinate GetRandomCoordinate()
        {
            var randomRow = Constants.Rows[Random.Next(0, 10)];
            var randomColumn = Constants.Columns[Random.Next(0, 10)];
            return new Coordinate(randomRow, randomColumn);
        }

        private static Coordinate GetHorizontalNeighbour(Cell cell, int offset)
        {
            var neighbourColumnIndex = Constants.Columns.ToList().IndexOf(cell.Coordinate.Column) + offset;
            if (neighbourColumnIndex < 0 || neighbourColumnIndex > 9)
                return null;

            var neighbourColumn = Constants.Columns[neighbourColumnIndex];
            return new Coordinate(cell.Coordinate.Row, neighbourColumn);
        }

        private static Coordinate GetVerticalNeighbour(Cell cell, int offset)
        {
            var neighbourRowIndex = Constants.Rows.ToList().IndexOf(cell.Coordinate.Row) + offset;
            if (neighbourRowIndex < 0 || neighbourRowIndex > 9)
                return null;

            var neighbourRow = Constants.Rows[neighbourRowIndex];
            return new Coordinate(neighbourRow, cell.Coordinate.Column);
        }
    }
}