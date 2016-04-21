using System;
using System.Collections.Generic;

namespace Snake
{
  public class UnboundedPathfinder : AbstractPathfinder
  {
    protected override IEnumerable<Cell> GetNeighbors (Cell cell, Cell goal)
    {
      var row = cell.Row;
      var column = cell.Column;

      foreach (var dir in directions)
      {
        var newRow = row + dir.Row;
        var newColumn = column + dir.Column;

        Grid.Validate (ref newRow, ref newColumn);

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
      var dc = next.Column - cell.Column;

      if (dr == 0)
      {
        return (dc == -1 || dc > 1) ? Direction.Left : Direction.Right;
      }
      else
      {
        return (dr == -1 || dr > 1) ? Direction.Up : Direction.Down;
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

        Grid.Validate (ref newRow, ref newColumn);

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
      var xr = x.Row;
      var yr = y.Row;

      var xc = x.Column;
      var yc = y.Column; 

      var dx = xc < yc ? GetMinDiff (xc, yc, gc) : GetMinDiff (yc, xc, gc);
      var dy = xr < yr ? GetMinDiff (xr, yr, gr) : GetMinDiff (yr, xr, gr);

      return dx + dy;
    }

    private int GetMinDiff (int low, int high, int max)
    {
      return Math.Min (high - low, max + low - high);
    }
  }
}
