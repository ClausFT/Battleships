using System.Collections.Generic;
using System.Linq;
using Battleships.Board.Entities;
using Battleships.Board.Interfaces;

namespace Battleships.Board
{
    public class GameBoard
    {
        public Dictionary<string, Dictionary<string, Cell>> Cells { get; set; }
        public List<IShip> Ships { get; set; }
        public bool IsGameOver => Ships.All(ship => ship.IsSunken);

        public GameBoard()
        {
            Cells = new Dictionary<string, Dictionary<string, Cell>>();
            Ships = new List<IShip>();
        }

        public void TakeHit(Coordinate coordinate)
        {
            Cells[coordinate.Row][coordinate.Column].IsHit = true;
        }
    }
}