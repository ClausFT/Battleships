using System.Collections.Generic;
using System.Text;

namespace Battleships.Board.Services
{
    public class BoardStringFormatterService
    {
        public static List<string> ToStringList(GameBoard board)
        {
            return ToStringList(board, false);
        }

        public static List<string> ToStringList(GameBoard board, bool hideShips)
        {
            var lines = new List<string> { @" \   A │ B │ C │ D │ E │ F │ G │ H │ I │ J  " };
            var lineBuilder = new StringBuilder();

            foreach (var row in Constants.Rows)
            {
                lines.Add(row == "1" ? "   ┌───┼───┼───┼───┼───┼───┼───┼───┼───┼───┐" : "───┼───┼───┼───┼───┼───┼───┼───┼───┼───┼───┤");
                lineBuilder.Append(row == "10" ? $"{row} │" : $" {row} │");

                foreach (var column in Constants.Columns)
                {
                    var cell = board.Cells[row][column];
                    var hideShipCondition = hideShips && cell.IsOccupied && !cell.IsHit;
                    var cellValue = hideShipCondition ? "   │" : $" {cell} │";
                    lineBuilder.Append(cellValue);
                }

                lines.Add(lineBuilder.ToString());
                lineBuilder.Clear();
            }

            lines.Add("   └───┴───┴───┴───┴───┴───┴───┴───┴───┴───┘");
            return lines;
        }
    }
}