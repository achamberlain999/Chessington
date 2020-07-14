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

            var tryRow = currentSquare.Row + forwardDirection;
            var tryCol = currentSquare.Col;

            if (board.GetPiece(Square.At(tryRow, tryCol)) != null)
            {
                return availableMoves;
            }
            
            availableMoves.Add(Square.At(tryRow, tryCol));
            if (!HasMoved && board.GetPiece(Square.At(tryRow + forwardDirection, tryCol)) == null)
            {
                availableMoves.Add(Square.At(tryRow + forwardDirection, tryCol));
            }

            return availableMoves;
        }
    }
}