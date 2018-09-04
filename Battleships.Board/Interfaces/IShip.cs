using System.Collections.Generic;
using Battleships.Board.Entities;

namespace Battleships.Board.Interfaces
{
    public interface IShip
    {
        string Id { get; }
        int Size { get; }
        List<Cell> OccupyingCells { get; set; }
        bool IsSunken { get; }
    }
}