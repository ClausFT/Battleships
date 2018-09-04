using System.Collections.Generic;
using System.Linq;
using Battleships.Board.Interfaces;

namespace Battleships.Board.Entities.Ships
{
    public class Submarine : IShip
    {
        public string Id => "S";
        public int Size => 2;
        public List<Cell> OccupyingCells { get; set; }
        public bool IsSunken => OccupyingCells.All(cell => cell.IsHit);

        public Submarine()
        {
            OccupyingCells = new List<Cell>();
        }
    }
}