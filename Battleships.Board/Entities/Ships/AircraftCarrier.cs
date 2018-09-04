using System.Collections.Generic;
using System.Linq;
using Battleships.Board.Interfaces;

namespace Battleships.Board.Entities.Ships
{
    public class AircraftCarrier : IShip
    {
        public string Id => "A";
        public int Size => 6;
        public List<Cell> OccupyingCells { get; set; }
        public bool IsSunken => OccupyingCells.All(cell => cell.IsHit);

        public AircraftCarrier()
        {
            OccupyingCells = new List<Cell>();
        }
    }
}