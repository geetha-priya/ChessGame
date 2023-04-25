using Xunit;
using Moq;
using System;

public class nextBestMoveTests
{
    private readonly Mock<INextBestMoveRequestQueue> _queueMock;
    private readonly Game _game;
    private readonly Player _player;
    private readonly NextBestMove _move;

    public nextBestMoveTests()
    {
        _queueMock = new Mock<INextBestMoveRequestQueue>();

        var whitePlayer = new Player("P1", Color.White);
        var blackPlayer = new Player("P2", Color.Black);
        _game = new Game(whitePlayer, blackPlayer);

        _player = whitePlayer;

        _move = new NextBestMove(_queueMock.Object);
    }

    [Fact]
    public void CalculateNextBestMove_DisabledForCompetition_ThrowsException()
    {
        _game.IsCompetition = true;

        var exception = Assert.Throws<Exception>(() => _move.CalculateNextBestMove(_game, _player));
        Assert.Equal("This feature is disabled for competition games", exception.Message);
    }

    [Fact]
    public void CalculateNextBestMove_RequiresSubscription_ThrowsException()
    {
        _player.HasSubscription = false;

         var exception = Assert.Throws<Exception>(() => _move.CalculateNextBestMove(_game, _player));
         Assert.Equal("This feature requires a subscription", exception.Message);
         
    }

    [Fact]
    public void CalculateNextBestMove_QueueFull_ThrowsException()
    {
        _queueMock.Setup(q => q.Length).Returns(120);

         var exception = Assert.Throws<Exception>(() => _move.CalculateNextBestMove(_game, _player));
         Assert.Equal("Feature unavailable at this time. Please try again later", exception.Message);
    }
}
