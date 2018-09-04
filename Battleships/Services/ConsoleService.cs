using System;
using System.Collections.Generic;
using System.Linq;
using Battleships.Board;
using Battleships.Board.Services;

namespace Battleships.Services
{
    public class ConsoleService
    {
        public static void WriteBoards(GameBoard board1, GameBoard board2)
        {
            var list1 = BoardStringFormatterService.ToStringList(board1);
            var list2 = BoardStringFormatterService.ToStringList(board2);
            var mergedList = new List<string> { "Enemy board:\t\t\t\t\t       Your board:\n" };
            for (int i = 0; i < list1.Count; i++)
            {
                var line = $"{list1.ElementAt(i)}     │     {list2.ElementAt(i)}";
                mergedList.Add(line);
            }

            Console.WriteLine(string.Join("\n", mergedList));
        }
    }
}