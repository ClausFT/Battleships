using Battleships.Board;

namespace Battleships.Players.Interfaces
{
    public interface IPlayer
    {
        GameBoard Board { get; set; }
        void NextTurn(GameBoard opponentBoard);
    }
}