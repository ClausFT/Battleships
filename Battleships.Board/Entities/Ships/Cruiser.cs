using System.Collections.Generic;
using System.Linq;
using Battleships.Board.Interfaces;

namespace Battleships.Board.Entities.Ships
{
    public class Cruiser : IShip
    {
        public string Id => "C";
        public int Size => 4;
        public List<Cell> OccupyingCells { get; set; }
        public bool IsSunken => OccupyingCells.All(cell => cell.IsHit);

        public Cruiser()
        {
            OccupyingCells = new List<Cell>();
        }
    }
}