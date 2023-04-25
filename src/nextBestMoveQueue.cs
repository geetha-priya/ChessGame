using System.Collections.Concurrent;

public interface INextBestMoveRequestQueue
{
  int Length {get;}
  void Enqueue(NextBestMoveRequest request);
  bool TryDequeue(out NextBestMoveRequest request);
}

public class NextBestMoveRequestQueue : INextBestMoveRequestQueue
{
    private ConcurrentQueue<NextBestMoveRequest> _queue = new ConcurrentQueue<NextBestMoveRequest>();

    public int Length => _queue.Count;

    public void Enqueue(NextBestMoveRequest request)
    {
        _queue.Enqueue(request);
    }

    public bool TryDequeue(out NextBestMoveRequest request)
    {
        return _queue.TryDequeue(out request);
    }
}