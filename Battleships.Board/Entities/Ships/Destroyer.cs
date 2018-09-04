using System.Collections.Generic;
using System.Linq;
using Battleships.Board.Interfaces;

namespace Battleships.Board.Entities.Ships
{
    public class Destroyer : IShip
    {
        public string Id => "D";
        public int Size => 3;
        public List<Cell> OccupyingCells { get; set; }
        public bool IsSunken => OccupyingCells.All(cell => cell.IsHit);

        public Destroyer()
        {
            OccupyingCells = new List<Cell>();
        }
    }
}