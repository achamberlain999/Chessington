using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class King : Piece
    {
        public King(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var currentSquare = board.FindPiece(this);
            var availableMoves = new List<Square>();

            var x = new List<int> {0, 1, 1, 1, 0, -1, -1, -1};
            var y = new List<int> {1, 1, 0, -1, -1, -1, 0, 1};

            for (var moveIndex = 0; moveIndex < 8; moveIndex++)
            {
                var row = currentSquare.Row + x[moveIndex];
                var col = currentSquare.Col + y[moveIndex];
                if (InBounds(row,col))
                {
                    availableMoves.Add(Square.At(row,col));
                }
            }

            return availableMoves;
        }
    }
}