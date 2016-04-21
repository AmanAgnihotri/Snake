internal interface IFixedSizePriorityQueue<TItem> : IPriorityQueue<TItem>
{
  void Resize (int maxNodes);

  int MaxSize { get; }
}
