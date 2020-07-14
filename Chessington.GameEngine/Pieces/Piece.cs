using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;

namespace Chessington.GameEngine.Pieces
{
    public abstract class Piece
    {
        protected Piece(Player player)
        {
            Player = player;
        }
        
        protected bool FirstMove = true;

        public Player Player { get; private set; }

        public abstract IEnumerable<Square> GetAvailableMoves(Board board);

        public void MoveTo(Board board, Square newSquare)
        {
            var currentSquare = board.FindPiece(this);
            board.MovePiece(currentSquare, newSquare);
            FirstMove = false;
        }

        protected IEnumerable<Square> GetDiagonalMovesList(Board board)
        {
            var currentSquare = board.FindPiece(this);
            var availableMoves = new List<Square>();
            
            var x = new List<int> {1, 1, -1, -1};
            var y = new List<int> {1, -1, 1, -1};

            for (var directionIndex = 0; directionIndex < 4; directionIndex++)
            {
                for (var distance = 1; distance <= 7; distance++)
                {
                    var row = currentSquare.Row + distance * y[directionIndex];
                    var col = currentSquare.Col + distance * x[directionIndex];
                    if (InBounds(row, col) && board.EmptySpace(row, col)) {
                        availableMoves.Add(Square.At(row, col));
                    }
                    else
                    {
                        if (InBounds(row, col) && board.GetPiece(Square.At(row, col)).Player != board.GetPiece(Square.At(currentSquare.Row, currentSquare.Col)).Player)
                        {
                            availableMoves.Add(Square.At(row, col));
                        }
                        break;
                    }
                }
            }
            
            return availableMoves;
        }

        protected IEnumerable<Square> GetLateralMovesList(Board board)
        {
            var currentSquare = board.FindPiece(this);
            var availableMoves = new List<Square>();
            
            var x = new List<int> {1, -1, 0, 0};
            var y = new List<int> {0, 0, 1, -1};

            for (var directionIndex = 0; directionIndex < 4; directionIndex++)
            {
                for (var distance = 1; distance <= 7; distance++)
                {
                    var row = currentSquare.Row + distance * y[directionIndex];
                    var col = currentSquare.Col + distance * x[directionIndex];
                    if (InBounds(row, col) && board.EmptySpace(row, col)) {
                        availableMoves.Add(Square.At(row, col));
                    }
                    else 
                    {
                        if (InBounds(row, col) && board.GetPiece(Square.At(row, col)).Player != board.CurrentPlayer)
                        {
                            availableMoves.Add(Square.At(row, col));
                        }

                        break;
                    }
                }
            }

            return availableMoves;
        }
        
        protected static bool InBounds(int row, int col)
        {
            return row >= 0 && row < GameSettings.BoardSize && col >= 0 && col < GameSettings.BoardSize;
        }
    }
}