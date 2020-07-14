using System.Collections.Generic;

namespace Chessington.GameEngine.Pieces
{
    public class Pawn : Piece
    {
        public Pawn(Player player) 
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var availableMovesList = new List<Square>();
            availableMovesList.Add(new Square(6,0));
            availableMovesList.Add(new Square(2,0));
            availableMovesList.Add(new Square(5,5));
            availableMovesList.Add(new Square(3,3));
            
            IEnumerable<Square> availableMoves = availableMovesList;
            return availableMoves;
        }
    }
}