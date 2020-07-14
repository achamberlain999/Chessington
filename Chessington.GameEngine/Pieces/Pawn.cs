using System.Collections.Generic;

namespace Chessington.GameEngine.Pieces
{
    public class Pawn : Piece
    {
        public Pawn(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var currentSquare = board.FindPiece(this);
            var availableMoves = new List<Square>();

            var forwardDirection = (Player == Player.White) ? -1 : +1;

            var row = currentSquare.Row + forwardDirection;
            var col = currentSquare.Col;

            if (InBounds(row, col) && board.EmptySpace(row, col))
            {
                availableMoves.Add(Square.At(row, col));
                if (FirstMove && InBounds(row,col) && board.EmptySpace(row + forwardDirection, col))
                {
                    availableMoves.Add(Square.At(row + forwardDirection, col));
                }
            }

            var x = new List<int> {1, -1};

            for (var moveIndex = 0; moveIndex <= 1; moveIndex++)
            {
                var takeRow = currentSquare.Row + forwardDirection;
                var takeCol = currentSquare.Col + x[moveIndex];
                if (InBounds(takeRow, takeCol) && !board.EmptySpace(takeRow, takeCol) && board.GetPiece(Square.At(takeRow, takeCol)).Player !=
                    board.GetPiece(Square.At(currentSquare.Row, currentSquare.Col)).Player)
                {
                    availableMoves.Add(Square.At(takeRow,takeCol));
                }
            }

            return availableMoves;
        }
    }
}