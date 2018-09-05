using System;
using System.Collections.Generic;
using System.Linq;
using Battleships.Board.Services;
using Battleships.Players.Interfaces;

namespace Battleships.Services
{
    public class ConsoleService
    {
        public static void WriteBoardsWithHiddenPlayer1Ships(IPlayer player1, IPlayer player2)
        {
            var stringOutput = GetBoardsAsString(player1, player2, true);
            Console.WriteLine(stringOutput);
        }

        public static void WriteBoards(IPlayer player1, IPlayer player2)
        {
            var stringOutput = GetBoardsAsString(player1, player2, false);
            Console.WriteLine(stringOutput);
        }

        private static string GetBoardsAsString(IPlayer player1, IPlayer player2, bool hidePlayer1Ships)
        {
            var list1 = BoardStringFormatterService.ToStringList(player1.Board, hidePlayer1Ships);
            var list2 = BoardStringFormatterService.ToStringList(player2.Board);
            var player1Text = $"{player1.Name} board:";
            var player2Text = $"{player2.Name} board:";
            player2Text = player2Text.PadLeft(67 - player1Text.Length, ' ');
            var mergedList = new List<string> { $"{player1Text}{player2Text}\n" };
            for (int i = 0; i < list1.Count; i++)
            {
                var line = $"{list1.ElementAt(i)}     │     {list2.ElementAt(i)}";
                mergedList.Add(line);
            }
            return string.Join("\n", mergedList);
        }
    }
}