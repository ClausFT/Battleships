using Battleships.Board;
using Battleships.Board.Services;
using Battleships.Players.Interfaces;

namespace Battleships.Players
{
    public class EasyEnemy : IPlayer
    {
        public GameBoard Board { get; set; }
        public void NextTurn(GameBoard opponentBoard)
        {
            while (true)
            {
                var randomCoordinate = CoordinateService.GetRandomCoordinate();
                var randomCell = opponentBoard.Cells[randomCoordinate.Row][randomCoordinate.Column];
                if (randomCell.IsHit)
                    continue;

                opponentBoard.Attack(randomCell.Coordinate);
                break;
            }
        }
    }
}