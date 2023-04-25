using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

[ApiController]
public class ChessController : ControllerBase
{
    // collection of games used as an alternative to dbcontext
    private static Dictionary<Guid, Game> _games = new Dictionary<Guid, Game>();

    [HttpPost("api/chess")]
    public IActionResult CreateGame([FromBody] CreateGameRequest request)
    {
        // get players from query
        var whitePlayer = new Player(request.WhitePlayerName, Color.White);
        var blackPlayer = new Player(request.BlackPlayerName, Color.Black);

        // create game
        var game = new Game(whitePlayer, blackPlayer);
        var gameId = System.Guid.NewGuid();
        _games.Add(gameId, game);

        // return game
        return Ok(new CreateGameResponse { GameId = gameId });
    }

    [HttpPost("api/chess/{gameId}/move")]
    public IActionResult MakeMove(System.Guid gameId, [FromBody] MakeMoveRequest request)
    {
        if (!_games.ContainsKey(gameId))
        {
            return NotFound();
        }

        // get game 
        var game = _games[gameId];

        // get piece, square to be moved
        var movedPiece = game.Board.Squares[request.StartRow, request.StartColumn].CurrentPiece;
        var currentSquare = game.Board.Squares[request.StartRow, request.StartColumn];
        var targetSquare = game.Board.Squares[request.TargetRow, request.TargetColumn];

        if (movedPiece == null)
        {
            return BadRequest("Invalid move - piece is not on the board in the start position specified.");
        }

        // make move
        var move = new Move(movedPiece, currentSquare, targetSquare);

        // update game board
        game.Board.Squares[request.StartRow, request.StartColumn].CurrentPiece = null;
        game.Board.Squares[request.TargetRow, request.TargetColumn].CurrentPiece  = movedPiece;

        // update game move history
        game.MoveHistory.Add(move);

        return Ok(new MakeMoveResponse { GameId = gameId, WhitePlayer = game.WhitePlayer, BlackPlayer = game.BlackPlayer,
        Board = JsonConvert.SerializeObject(game.Board),
        MoveHistory = game.MoveHistory });
    }
}

public class CreateGameRequest
{
    public string WhitePlayerName { get; set; }
    public string BlackPlayerName { get; set; }

}

public class CreateGameResponse
{
    public Guid GameId { get; set; }
}

public class MakeMoveRequest
{
    public int StartRow { get; set; }
    public int StartColumn { get; set; }
    public int TargetRow { get; set; }
    public int TargetColumn { get; set; }
}

public class MakeMoveResponse
{
    public Guid GameId { get; set; }
    public Player WhitePlayer { get; set; }
    public Player BlackPlayer { get; set; }
    public string Board { get; set; }
    public List<Move> MoveHistory { get; set; }
}

