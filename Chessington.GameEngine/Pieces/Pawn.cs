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
            var owner = this.Player;
            
            var availableMovesList = new List<Square>();

            if (owner == Player.White)
            {
                availableMovesList.Add(new Square(currentSquare.Row - 1, currentSquare.Col));
                if (!HasMoved)
                {
                    availableMovesList.Add(new Square(currentSquare.Row - 2, currentSquare.Col));
                }
            }
            
            if (owner == Player.Black)
            {
                availableMovesList.Add(new Square(currentSquare.Row + 1, currentSquare.Col));
                if (!HasMoved)
                {
                    availableMovesList.Add(new Square(currentSquare.Row + 2, currentSquare.Col));
                }
            }

            IEnumerable<Square> availableMoves = availableMovesList;
            return availableMoves;
        }
    }
}