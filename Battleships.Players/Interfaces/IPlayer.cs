using Battleships.Board;

namespace Battleships.Players.Interfaces
{
    public interface IPlayer
    {
        string Name { get; }
        GameBoard Board { get; set; }
        void NextTurn(GameBoard opponentBoard);
    }
}