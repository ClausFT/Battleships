using System.Collections.Generic;
using System.Text;

namespace Battleships.Board.Services
{
    public class BoardStringFormatterService
    {
        public static List<string> ToStringList(GameBoard board)
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
                    var cellValue = "   │";
                    //if (cell.IsOccupied)
                    //    cellValue = $" {cell.Ship.Id} │";
                    if (!cell.IsOccupied && cell.IsHit)
                        cellValue = " o │"; //·
                    if (cell.IsOccupied && cell.IsHit)
                        cellValue = " X │";
                    lineBuilder.Append(cellValue); //·

                    //lineBuilder.Append(cell.IsOccupied ? $" {cell.Ship.Id} │" : "   │"); //·
                }

                lines.Add(lineBuilder.ToString());
                lineBuilder.Clear();
            }

            lines.Add("   └───┴───┴───┴───┴───┴───┴───┴───┴───┴───┘");
            return lines;
        }
    }
}