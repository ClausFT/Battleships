using System;
using System.Collections.Generic;
using System.Threading;
using Battleships.Board.Services;
using Battleships.Players.Interfaces;
using Battleships.Services;

namespace Battleships
{
    public class GameEngine
    {
        private readonly IPlayer _player1;
        private readonly IPlayer _player2;
        private readonly bool _humanVsAi;
        private readonly bool _aiVsAi;

        public GameEngine(IAiPlayer aiPlayer, IHumanPlayer humanPlayer)
        {
            _player1 = aiPlayer;
            _player2 = humanPlayer;
            _humanVsAi = true;
            Initialize();
        }

        public GameEngine(IAiPlayer aiPlayer1, IAiPlayer aiPlayer2)
        {
            _player1 = aiPlayer1;
            _player2 = aiPlayer2;
            _aiVsAi = true;
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
            turnQueue.Enqueue(_player2);
            turnQueue.Enqueue(_player1);

            while (true)
            {
                UpdateConsole();

                var currentPlayer = turnQueue.Dequeue();
                var opponentPlayer = turnQueue.Dequeue();

                currentPlayer.NextTurn(opponentPlayer.Board);

                if (opponentPlayer.Board.IsGameOver)
                {
                    turnQueue.Enqueue(currentPlayer);
                    break;
                }

                turnQueue.Enqueue(opponentPlayer);
                turnQueue.Enqueue(currentPlayer);
                if (_aiVsAi)
                    Thread.Sleep(50);
            }

            var winner = turnQueue.Dequeue();
            Console.Clear();
            ConsoleService.WriteBoards(_player1, _player2);
            Console.WriteLine(winner.Name + " won the game");
        }

        private void UpdateConsole()
        {
            Console.Clear();
            if (_humanVsAi)
            {
                ConsoleService.WriteBoardsWithHiddenPlayer1Ships(_player1, _player2);
            }

            else if (_aiVsAi)
            {
                ConsoleService.WriteBoards(_player1, _player2);
            }           
        }
    }
}