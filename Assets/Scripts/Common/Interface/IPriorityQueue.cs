using System.Collections.Generic;

public interface IPriorityQueue<T>
{
  void Enqueue (T node, float priority);

  T Dequeue ();

  void Clear ();

  bool Contains (T node);

  void Remove (T node);

  void UpdatePriority (T node, float priority);

  int Count { get; }
}
