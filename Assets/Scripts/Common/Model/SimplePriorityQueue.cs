using System;
using System.Collections.Generic;

public sealed class SimplePriorityQueue<T> : IPriorityQueue<T>
{
  private class SimpleNode : StablePriorityQueueNode
  {
    public T Data { get; private set; }

    public SimpleNode (T data)
    {
      Data = data;
    }
  }

  private const int INITIAL_QUEUE_SIZE = 128;

  private readonly StablePriorityQueue<SimpleNode> queue;

  public SimplePriorityQueue ()
  {
    queue = new StablePriorityQueue<SimpleNode> (INITIAL_QUEUE_SIZE);
  }

  private SimpleNode GetExistingNode (T item)
  {
    var comparer = EqualityComparer<T>.Default;

    foreach (var node in queue)
    {
      if (comparer.Equals (node.Data, item))
      {
        return node;
      }
    }

    throw new InvalidOperationException ("Item cannot be found in queue: " + item);
  }

  public int Count { get { return queue.Count; } }

  public void Clear () { queue.Clear (); }

  public bool Contains (T item)
  {
    var comparer = EqualityComparer<T>.Default;

    foreach (var node in queue)
    {
      if (comparer.Equals (node.Data, item))
      {
        return true;
      }
    }

    return false;
  }

  public T Dequeue ()
  {
    if (queue.Count <= 0)
    {
      throw new InvalidOperationException ("Cannot call Dequeue () on an empty queue");
    }

    SimpleNode node = queue.Dequeue ();

    return node.Data;
  }

  public void Enqueue (T item, float priority)
  {
    SimpleNode node = new SimpleNode (item);

    if (queue.Count == queue.MaxSize)
    {
      queue.Resize (queue.MaxSize * 2 + 1);
    }

    queue.Enqueue (node, priority);
  }

  public void Remove (T item)
  {
    try
    {
      queue.Remove (GetExistingNode (item));
    }
    catch (InvalidOperationException ex)
    {
      throw new InvalidOperationException ("Cannot call Remove () on a node which is not enqueued: " + item, ex);
    }
  }

  public void UpdatePriority (T item, float priority)
  {
    try
    {
      SimpleNode updateMe = GetExistingNode (item);

      queue.UpdatePriority (updateMe, priority);
    }
    catch (InvalidOperationException ex)
    {
      throw new InvalidOperationException ("Cannot call UpdatePriority () on a node which is not enqueued: " + item, ex);
    }
  }
}
