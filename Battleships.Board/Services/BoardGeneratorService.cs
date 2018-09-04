using System;
using System.Collections.Generic;
using System.Linq;
using Battleships.Board.Entities;
using Battleships.Board.Entities.Ships;
using Battleships.Board.Enums;
using Battleships.Board.Interfaces;

namespace Battleships.Board.Services
{
    public class BoardGeneratorService
    {
        public static GameBoard GenerateRandomBoard()
        {
            var board = GenerateEmptyBoard();

            var ships = new Queue<IShip>();
            foreach (var ship in Constants.Ships)
                ships.Enqueue(ship);

            while (ships.Any())
            {
                var randomCoordinate = CoordinateService.GetRandomCoordinate();
                var randomCell = board.Cells[randomCoordinate.Row][randomCoordinate.Column];
                if (randomCell.IsOccupied)
                    continue;

                var ship = ships.Dequeue();
                var direction = Directions.GetRandom();
                if (TryPlaceShipInDirection(direction, board, randomCell, ship))
                {
                    board.Ships.Add(ship);
                    continue;
                }

                ships.Enqueue(ship);
            }
            return board;
        }

        private static bool TryPlaceShipInDirection(Direction direction, GameBoard board, Cell fromCell, IShip ship)
        {
            var emptyCells = new List<Cell> { fromCell };
            Cell neighbourCell = null;
            for (int shipSize = 1; shipSize < ship.Size; shipSize++)
            {
                var neighbourCoordinate = CoordinateService.GetNeighbour(direction, neighbourCell ?? fromCell);
                if (neighbourCoordinate == null)
                    break;

                neighbourCell = board.Cells[neighbourCoordinate.Row][neighbourCoordinate.Column];
                if (neighbourCell.IsOccupied)
                    break;

                emptyCells.Add(board.Cells[neighbourCoordinate.Row][neighbourCoordinate.Column]);
            }

            if (emptyCells.Count != ship.Size)
                return false;

            PlaceShipAt(emptyCells, ship);
            return true;
        }

        private static void PlaceShipAt(List<Cell> cells, IShip ship)
        {
            foreach (var cell in cells)
            {
                ship.OccupyingCells.Add(cell);
                cell.Ship = ship;
            }
        }

        private static GameBoard GenerateEmptyBoard()
        {
            var board = new GameBoard();

            foreach (var rowNumber in Constants.Rows)
            {
                var row = new Dictionary<string, Cell>();
                foreach (var columnLetter in Constants.Columns)
                    row[columnLetter] = new Cell(rowNumber, columnLetter);

                board.Cells.Add(rowNumber, row);
            }
            return board;
        }
    }
}