// Class representing the individual sqaure of a game board and contains
// color, row and column(position) on the board, piece occupying the square.


public class Square
{
    public Color Color { get; set; }
    // nullable is disabled project wide. However CurrentPiece feild needs to be made nullable, so adding
    // #nullable enable clause here
    #nullable enable
    public Piece? CurrentPiece { get; set; }
    #nullable disable
    public int Row { get; set; }
    public int Column { get; set; }
    
    public Square(Color color, int row, int col)
    {
        Color = color;
        Row = row;
        Column = col;
    }
}

// Class representing the game board and contains 8X8 square grid.
public class Board
{
    public Square[,] Squares { get; set; }
    
    public Board()
    {
        Squares = new Square[8, 8];
        
        // Initialize the board with alternating black and white squares
        for (int row = 0; row < 8; row++)
        {
            for (int col = 0; col < 8; col++)
            {
                if ((row + col) % 2 == 0)
                {
                    Squares[row, col] = new Square(Color.White, row, col);
                }
                else
                {
                    Squares[row, col] = new Square(Color.Black,row, col);
                }
            }
        }

        // Place white pieces
        Squares[0, 0].CurrentPiece = new Rook(Color.White, "WhiteRook");
        Squares[0, 1].CurrentPiece = new Knight(Color.White, "WhiteKnight");
        Squares[0, 2].CurrentPiece = new Bishop(Color.White, "WhiteBishop");
        Squares[0, 3].CurrentPiece = new Queen(Color.White, "WhiteQueen");
        Squares[0, 4].CurrentPiece = new King(Color.White, "WhiteKing");
        Squares[0, 5].CurrentPiece = new Bishop(Color.White, "WhiteBishop");
        Squares[0, 6].CurrentPiece = new Knight(Color.White, "WhiteKnight");
        Squares[0, 7].CurrentPiece = new Rook(Color.White, "WhiteRook");
        for (int i = 0; i < 8; i++)
        {
            Squares[1, i].CurrentPiece = new Pawn(Color.White, $"WhitePawn{i}");
        }

        // Place black pieces
        Squares[7, 0].CurrentPiece = new Rook(Color.Black, "BlackRook");
        Squares[7, 1].CurrentPiece = new Knight(Color.Black, "BlackKnight");
        Squares[7, 2].CurrentPiece = new Bishop(Color.Black, "BlackBishop");
        Squares[7, 3].CurrentPiece = new Queen(Color.Black, "BlackQueen");
        Squares[7, 4].CurrentPiece = new King(Color.Black, "BlackKing");
        Squares[7, 5].CurrentPiece = new Bishop(Color.Black, "BlackBishop");
        Squares[7, 6].CurrentPiece = new Knight(Color.Black, "BlackKnight");
        Squares[7, 7].CurrentPiece = new Rook(Color.Black, "BlackRook");
        for (int i = 0; i < 8; i++)
        {
            Squares[6, i].CurrentPiece = new Pawn(Color.Black, $"BlackPawn{i}");
        }
    }
}

