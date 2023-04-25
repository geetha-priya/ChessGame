// Class representing move made by players of a game and contains
// start and target square for the move and a piece being moved.
public class Move
{
    public Piece MovedPiece { get; set; }
    public Square StartSquare { get; set; }
    public Square EndSquare { get; set; }
    
    public Move(Piece movedPiece, Square startSquare, Square endSquare)
    {
        MovedPiece = movedPiece;
        StartSquare = startSquare;
        EndSquare = endSquare;
    }
}


