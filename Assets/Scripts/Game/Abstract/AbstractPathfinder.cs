using System.Collections.Generic;

namespace Snake
{
  public abstract class AbstractPathfinder : IPathfinder
  {
    [Inject]
    public IGrid Grid { get; set; }

    protected static readonly Position[] directions = new []
    {
      new Position (-1, 0),
      new Position (0, -1),
      new Position (1, 0),
      new Position (0, 1)
    };

    protected int gr, gc;

    private Dictionary<Cell, Cell> cameFrom = new Dictionary<Cell, Cell> ();
    private Dictionary<Cell, int> costSoFar = new Dictionary<Cell, int> ();

    private SimplePriorityQueue<Cell> frontier;

    public AbstractPathfinder ()
    {
      frontier = new SimplePriorityQueue<Cell> ();
    }

    [PostConstruct]
    public void Initialize ()
    {
      gr = Grid.Rows;
      gc = Grid.Columns;
    }

    public IEnumerable<Direction> GetDirections (Cell start, Cell goal)
    {
      if (FindPath (goal, start))
      {
        var current = start;

        while (cameFrom.ContainsKey (current) && current != goal)
        {
          var next = cameFrom[current];

          yield return GetDirection (current, next);

          current = next;
        }
      }
      else
      {
        var neighbor = GetAnyNeighbor (start);

        if (neighbor != start)
        {
          yield return GetDirection (start, neighbor);
        }
      }
    }

    protected abstract IEnumerable<Cell> GetNeighbors (Cell cell, Cell goal);

    protected abstract Direction GetDirection (Cell cell, Cell next);

    protected abstract Cell GetAnyNeighbor (Cell cell);

    protected abstract int Heuristic (Cell x, Cell y);

    private bool FindPath (Cell start, Cell goal)
    {
      frontier.Clear ();

      cameFrom.Clear ();

      costSoFar.Clear ();

      frontier.Enqueue (start, 0);

      cameFrom[start] = start;

      costSoFar[start] = 0;

      while (frontier.Count > 0)
      {
        var current = frontier.Dequeue ();

        if (current == goal)
        {
          return true;
        }

        foreach (var next in GetNeighbors (current, goal))
        {
          int newCost = costSoFar[current] + 1;

          if (!costSoFar.ContainsKey (next) || newCost < costSoFar[next])
          {
            costSoFar[next] = newCost;

            int priority = newCost + Heuristic (next, goal);

            frontier.Enqueue (next, priority);

            cameFrom[next] = current;
          }
        }
      }

      return false;
    }
  }
}
