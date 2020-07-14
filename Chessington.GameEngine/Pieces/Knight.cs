using System.Collections.Generic;

namespace Chessington.GameEngine.Pieces
{
    public class Knight : Piece
    {
        public Knight(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var currentSquare = board.FindPiece(this);
            var availableMoves = new List<Square>();

            var x = new List<int> {1, 2, 2, 1, -1, -2, -2, -1};
            var y = new List<int> {2, 1, -1, -2, -2, -1, 1, 2};

            for (var moveIndex = 0; moveIndex < 8; moveIndex++)
            {
                var row = currentSquare.Row + x[moveIndex];
                var col = currentSquare.Col + y[moveIndex];
                if (InBounds(row,col) && (board.EmptySpace(row,col) || board.GetPiece(Square.At(row,col)).Player != board.CurrentPlayer))
                {
                    availableMoves.Add(Square.At(row,col));
                }
            }

            return availableMoves;
        }
    }
}