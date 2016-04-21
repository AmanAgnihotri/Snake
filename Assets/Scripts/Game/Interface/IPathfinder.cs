using System.Collections.Generic;

namespace Snake
{
  public interface IPathfinder
  {
    IEnumerable<Direction> GetDirections (Cell start, Cell goal);
  }
}
