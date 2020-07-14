using System;
using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public abstract class Piece
    {
        protected Piece(Player player)
        {
            Player = player;
        }

        public Player Player { get; private set; }

        public bool HasMoved = false;

        public abstract IEnumerable<Square> GetAvailableMoves(Board board);

        public void MoveTo(Board board, Square newSquare)
        {
            var currentSquare = board.FindPiece(this);
            board.MovePiece(currentSquare, newSquare);
            this.HasMoved = true;
        }

        protected List<Square> GetDiagonalMovesList(Board board)
        {
            var currentSquare = board.FindPiece(this);
            var availableMovesList = new List<Square>();
            var x = new List<int>{1, 1, -1, -1};
            var y = new List<int>{1, -1, 1, -1};

            for (var i = 0; i <= 8; i++)
            {
                for (var j = 0; j < 4; j++)
                {
                    var tryRow = currentSquare.Row + i * y[j];
                    var tryCol = currentSquare.Row + i * x[j];
                    if (InBounds(tryRow, tryCol)) {
                        availableMovesList.Add(new Square(tryRow, tryCol));
                    }
                }
            }
            
            availableMovesList.RemoveAll(s => s == Square.At(currentSquare.Row, currentSquare.Col));
            return availableMovesList;
        }

        protected List<Square> GetLateralMovesList(Board board)
        {
            var currentSquare = board.FindPiece(this);
            var availableMovesList = new List<Square>();
            
            for (var i = 0; i < 8; i++)
            {
                availableMovesList.Add(new Square(currentSquare.Row,i));
                availableMovesList.Add(new Square(i,currentSquare.Col));
            }
            
            availableMovesList.RemoveAll(s => s == Square.At(currentSquare.Row, currentSquare.Col));
            return availableMovesList;
        }
        
        protected bool InBounds(int row, int col)
        {
            return row >= 0 && row <= 7 && col >= 0 && col <= 7;
        }
    }
}