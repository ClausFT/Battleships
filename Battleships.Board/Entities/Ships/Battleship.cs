using System.Collections.Generic;
using System.Linq;
using Battleships.Board.Interfaces;

namespace Battleships.Board.Entities.Ships
{
    public class Battleship : IShip
    {
        public string Id => "B";
        public int Size => 5;
        public List<Cell> OccupyingCells { get; set; }
        public bool IsSunken => OccupyingCells.All(cell => cell.IsHit);

        public Battleship()
        {
            OccupyingCells = new List<Cell>();
        }
    }
}