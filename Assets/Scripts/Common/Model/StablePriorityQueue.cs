using System;
using System.Collections;
using System.Collections.Generic;

public sealed class StablePriorityQueue<T> : IEnumerable<T>, IFixedSizePriorityQueue<T> where T : StablePriorityQueueNode
{
  private int numNodes;
  private T[] nodes;
  private long numNodesEverEnqueued;

  public StablePriorityQueue (int maxNodes)
  {
    numNodes = 0;

    nodes = new T[maxNodes + 1];

    numNodesEverEnqueued = 0;
  }

  public int Count { get { return numNodes; } }

  public int MaxSize { get { return nodes.Length - 1; } }

  public void Clear ()
  {
    Array.Clear (nodes, 1, numNodes);

    numNodes = 0;
  }

  public bool Contains (T node)
  {
    return (nodes[node.QueueIndex] == node);
  }

  public void Enqueue (T node, float priority)
  {
    node.Priority = priority;
    numNodes++;
    nodes[numNodes] = node;
    node.QueueIndex = numNodes;
    node.InsertionIndex = numNodesEverEnqueued++;

    CascadeUp (nodes[numNodes]);
  }

  private void Swap (T node1, T node2)
  {
    nodes[node1.QueueIndex] = node2;
    nodes[node2.QueueIndex] = node1;

    int temp = node1.QueueIndex;
    node1.QueueIndex = node2.QueueIndex;
    node2.QueueIndex = temp;
  }

  private void CascadeUp (T node)
  {
    int parent = node.QueueIndex / 2;

    while (parent >= 1)
    {
      T parentNode = nodes[parent];

      if (HasHigherPriority (parentNode, node))
        break;

      Swap (node, parentNode);

      parent = node.QueueIndex / 2;
    }
  }

  private void CascadeDown (T node)
  {
    T newParent;
    int finalQueueIndex = node.QueueIndex;

    while (true)
    {
      newParent = node;
      int childLeftIndex = 2 * finalQueueIndex;

      if (childLeftIndex > numNodes)
      {
        node.QueueIndex = finalQueueIndex;
        nodes[finalQueueIndex] = node;
        break;
      }

      T childLeft = nodes[childLeftIndex];
      if (HasHigherPriority(childLeft, newParent))
      {
        newParent = childLeft;
      }

      int childRightIndex = childLeftIndex + 1;
      if (childRightIndex <= numNodes)
      {
        T childRight = nodes[childRightIndex];
        if (HasHigherPriority(childRight, newParent))
        {
          newParent = childRight;
        }
      }

      if (newParent != node)
      {
        nodes[finalQueueIndex] = newParent;

        int temp = newParent.QueueIndex;
        newParent.QueueIndex = finalQueueIndex;
        finalQueueIndex = temp;
      }
      else
      {
        node.QueueIndex = finalQueueIndex;
        nodes[finalQueueIndex] = node;
        break;
      }
    }
  }

  private bool HasHigherPriority (T higher, T lower)
  {
    return (higher.Priority < lower.Priority || (higher.Priority == lower.Priority && higher.InsertionIndex < lower.InsertionIndex));
  }

  public T Dequeue ()
  {
    T returnMe = nodes[1];

    Remove (returnMe);

    return returnMe;
  }

  public void Resize (int maxNodes)
  {
    T[] newArray = new T[maxNodes + 1];

    int highestIndexToCopy = Math.Min (maxNodes, numNodes);

    for (int i = 1; i <= highestIndexToCopy; i++)
    {
      newArray[i] = nodes[i];
    }

    nodes = newArray;
  }

  public void UpdatePriority (T node, float priority)
  {
    node.Priority = priority;

    OnNodeUpdated (node);
  }

  private void OnNodeUpdated (T node)
  {
    int parentIndex = node.QueueIndex / 2;
    T parentNode = nodes[parentIndex];

    if (parentIndex > 0 && HasHigherPriority (node, parentNode))
    {
      CascadeUp (node);
    }
    else
    {
      CascadeDown (node);
    }
  }

  public void Remove (T node)
  {
    if(node.QueueIndex == numNodes)
    {
      nodes[numNodes] = null;
      numNodes--;
      return;
    }

    T formerLastNode = nodes[numNodes];
    Swap(node, formerLastNode);
    nodes[numNodes] = null;
    numNodes--;

    OnNodeUpdated (formerLastNode);
  }

  public IEnumerator<T> GetEnumerator ()
  {
    for(int i = 1; i <= numNodes; i++)
    {
      yield return nodes[i];
    }
  }

  IEnumerator IEnumerable.GetEnumerator ()
  {
    return GetEnumerator();
  }
}
