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
            var availableMovesList = new List<Square>();

            var x = new List<int> {0, 1, 1, 1, 0, -1, -1, -1};
            var y = new List<int> {1, 1, 0, -1, -1, -1, 0, 1};

            for (var i = 0; i < 8; i++)
            {
                var tryRow = currentSquare.Row + x[i];
                var tryCol = currentSquare.Col + y[i];
                if (InBounds(tryRow,tryCol))
                {
                    availableMovesList.Add(new Square(tryRow,tryCol));
                }
            }
            
            IEnumerable<Square> availableMoves = availableMovesList;
            
            return availableMoves;
        }
    }
}