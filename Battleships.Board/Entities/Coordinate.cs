namespace Battleships.Board.Entities
{
    public class Coordinate
    {
        public string Row { get; set; }
        public string Column { get; set; }

        public Coordinate(string row, string column)
        {
            Row = row;
            Column = column;
        }
    }
}