using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Knight : Piece
    {
        public Knight(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var currentSquare = board.FindPiece(this);
            var availableMovesList = new List<Square>();

            var x = new List<int> {1, 2, 2, 1, -1, -2, -2, -1};
            var y = new List<int> {2, 1, -1, -2, -2, -1, 1, 2};

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