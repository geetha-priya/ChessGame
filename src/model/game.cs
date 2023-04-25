// Class representing game and contains
// players, board and history of moves made during the game.
// Note: IsCompetition has been added to support 'Testing' TASK of assesment

public class Game {
    public Player WhitePlayer { get; set; }
    public Player BlackPlayer { get; set; }
    public Board Board { get; set; }
    public List<Move> MoveHistory { get; set; }
    public bool IsCompetition {get; set;}
    
    public Game(Player whitePlayer, Player blackPlayer, bool isCompetition=false)
    {
        WhitePlayer = whitePlayer;
        BlackPlayer = blackPlayer;
        Board = new Board();
        MoveHistory = new List<Move>();
        IsCompetition = isCompetition;
    }
}