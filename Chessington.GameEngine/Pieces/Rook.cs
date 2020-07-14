using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Rook : Piece
    {
        public Rook(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var currentSquare = board.FindPiece(this);
            var availableMovesList = new List<Square>();
            
            for (var i = 0; i < 8; i++)
            {
                availableMovesList.Add(new Square(currentSquare.Row,i));
                availableMovesList.Add(new Square(i,currentSquare.Col));
            }
            
            availableMovesList.RemoveAll(s => s == Square.At(currentSquare.Row, currentSquare.Col));
            IEnumerable<Square> availableMoves = availableMovesList;
            
            return availableMoves;
        }
    }
}