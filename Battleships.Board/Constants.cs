using Battleships.Board.Entities.Ships;
using Battleships.Board.Interfaces;

namespace Battleships.Board
{
    public class Constants
    {
        public static readonly string[] Rows = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" };
        public static readonly string[] Columns = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J" };
        public static IShip[] Ships => new IShip[] {new Submarine(), new Submarine(), new Destroyer(), new Cruiser(), new Battleship(), new AircraftCarrier()};
    }
}