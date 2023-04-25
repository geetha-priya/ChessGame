public class NextBestMove 
{
  private const int MaxQueueLength = 100;
  private readonly INextBestMoveRequestQueue _queue;
  
  public NextBestMove (INextBestMoveRequestQueue queue)
  {
    _queue = queue;
  }
  
  public void CalculateNextBestMove (Game game, Player player)
  { 
    if (game.IsCompetition) 
    {
      throw new Exception( "This feature is disabled for competition games");
    }
    
    else if (!player.HasSubscription)
    {
      throw new Exception( "This feature requires a subscription");
    }

    else if (_queue.Length > MaxQueueLength)
    {
      throw new Exception( "Feature unavailable at this time. Please try again later");
    } 
    
    var request = new NextBestMoveRequest 
    {
      board = game.Board,
      color = player.Color
    };
    
    _queue.Enqueue(request);
  }
}