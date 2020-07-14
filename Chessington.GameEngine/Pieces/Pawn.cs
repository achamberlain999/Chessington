using System.Collections.Generic;
using System.Net.Configuration;

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
                if (FirstMove && InBounds(row,col) && board.EmptySpace(row+forwardDirection, col))
                {
                    availableMoves.Add(Square.At(row + forwardDirection, col));
                }
            }

            return availableMoves;
        }
    }
}