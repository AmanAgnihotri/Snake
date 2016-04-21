using System;
using System.Collections.Generic;

namespace Snake
{
  [Implements (typeof (IPathfinder))]
  public class BoundedPathfinder : AbstractPathfinder
  {
    protected override IEnumerable<Cell> GetNeighbors (Cell cell, Cell goal)
    {
      var row = cell.Row;
      var column = cell.Column;

      foreach (var dir in directions)
      {
        var newRow = row + dir.Row;
        var newColumn = column + dir.Column;

        if (!IsValid (newRow, newColumn))
        {
          continue;
        }

        var nextCell = Grid.Cells[newRow, newColumn];

        if (!nextCell.IsActive () || nextCell == goal)
        {
          yield return nextCell;
        }
      }
    }

    protected override Direction GetDirection (Cell cell, Cell next)
    {
      var dr = next.Row - cell.Row;

      if (dr == 0)
      {
        var dc = next.Column - cell.Column;

        return dc == 1 ? Direction.Right : Direction.Left;
      }
      else
      {
        return dr == 1 ? Direction.Down : Direction.Up;
      }
    }

    protected override Cell GetAnyNeighbor (Cell cell)
    {
      var row = cell.Row;
      var column = cell.Column;

      foreach (var dir in directions)
      {
        var newRow = row + dir.Row;
        var newColumn = column + dir.Column;

        if (!IsValid (newRow, newColumn))
        {
          continue;
        }

        var nextCell = Grid.Cells[newRow, newColumn];

        if (!nextCell.IsActive ())
        {
          return nextCell;
        }
      }

      return cell;
    }

    protected override int Heuristic (Cell x, Cell y)
    {
      return Math.Abs (x.Row - y.Row) + Math.Abs (x.Column - y.Column);
    }

    private bool IsValid (int row, int column)
    {
      return row > 0 && column > 0 && row < gr && column < gc;
    }
  }
}
