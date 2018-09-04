using System;
using System.Collections.Generic;
using Battleships.Board.Services;
using Battleships.Players.Interfaces;
using Battleships.Services;

namespace Battleships
{
    public class GameEngine
    {
        private readonly IPlayer _player1;
        private readonly IPlayer _player2;

        public GameEngine(IPlayer player1, IPlayer player2)
        {
            _player1 = player1;
            _player2 = player2;
            Initialize();
        }

        private void Initialize()
        {
            _player1.Board = BoardGeneratorService.GenerateRandomBoard();
            _player2.Board = BoardGeneratorService.GenerateRandomBoard();
        }

        public void Start()
        {
            var turnQueue = new Queue<IPlayer>();
            turnQueue.Enqueue(_player1);
            turnQueue.Enqueue(_player2);

            var battling = true;
            while (battling)
            {
                Console.Clear();
                ConsoleService.WriteBoards(_player1.Board, _player2.Board);

                var currentPlayer = turnQueue.Dequeue();
                var opponentPlayer = turnQueue.Dequeue();

                currentPlayer.NextTurn(opponentPlayer.Board);

                turnQueue.Enqueue(opponentPlayer);
                turnQueue.Enqueue(currentPlayer);

                if (_player1.Board.IsGameOver || _player2.Board.IsGameOver)
                    battling = false;
            }
        }
    }
}