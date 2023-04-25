// Enum to represent possible piece type in the game.
public enum PieceType
{
    Bishop,
    King,
    Knight,
    Pawn,
    Queen, 
    Rook   
}

// Class representing the Piece of the game and contains
// type(which has to be determined in concrete class), color and name of piece.
public abstract class Piece
{
    public virtual PieceType Type { get; set; }
    public Color Color { get; set; }
    public string Name { get; set; }
    
    public Piece(Color color, string name)
    {
        Color = color;
        Name = name;
    }
    
    public abstract bool IsValidMove(Square targetSquare);
}

// Class to represent white or black king
public class King : Piece
{
    public King(Color color, string name) : base(color, name)
    {
    }

    public override PieceType Type => PieceType.King;

    public override bool IsValidMove(Square square)
    {
        // Assume any move as valid for time being
        return true;
    }
}

// Class to represent white or black queen
public class Queen : Piece
{
    public Queen(Color color, string name) : base(color, name)
    {
    }

    public override PieceType Type => PieceType.Queen;

    public override bool IsValidMove(Square square)
    {
        // Assume any move as valid for time being
        return true;
    }
}

// Class to represent white or black bishop
public class Bishop : Piece
{
    public Bishop(Color color, string name) : base(color, name)
    {
    }

    public override PieceType Type => PieceType.Bishop;

    public override bool IsValidMove(Square square)
    {
        // Assume any move as valid for time being
        return true;
    }
}

// Class to represent white or black knight
public class Knight : Piece
{
    public Knight(Color color, string name) : base(color, name)
    {
    }

    public override PieceType Type => PieceType.Knight;

    public override bool IsValidMove(Square square)
    {
        // Assume any move as valid for time being
        return true;
    }
}

// Class to represent white or black rook
public class Rook : Piece
{
    public Rook(Color color, string name) : base(color, name)
    {
    }

    public override PieceType Type => PieceType.Rook;

    public override bool IsValidMove(Square square)
    {
        // Assume any move as valid for time being
        return true;
    }
}

// Class to represent white or black pawn
public class Pawn : Piece
{
    public Pawn(Color color, string name) : base(color, name)
    {
    }

    public override PieceType Type => PieceType.Queen;

    public override bool IsValidMove(Square square)
    {
        // Assume any move as valid for time being
        return true;
    }
}

