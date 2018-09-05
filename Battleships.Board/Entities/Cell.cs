using IShip = Battleships.Board.Interfaces.IShip;

namespace Battleships.Board.Entities
{
    public class Cell
    {
        public IShip Ship { get; set; }
        public Coordinate Coordinate { get; set; }
        public bool IsHit { get; set; }

        public bool IsOccupied => Ship != null;

        public Cell(string row, string column)
        {
            Coordinate = new Coordinate(row, column);
        }

        public override string ToString()
        {
            if (IsOccupied && IsHit)
                return "X";

            if (IsOccupied)
                return Ship.Id;

            if (!IsOccupied && IsHit)
                return "·";
          
            return " ";
        }
    }
}