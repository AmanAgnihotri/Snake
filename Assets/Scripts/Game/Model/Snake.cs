using UnityEngine;
using System.Collections.Generic;

namespace Snake
{
  public class Snake : ISnake
  {
    [Inject]
    public IGrid Grid { get; set; }

    public Direction CurrentDirection { get; private set; }

    public Direction NextDirection { get; set; }

    public Cell Head { get { return cells.First.Value; } }

    private LinkedList<Cell> cells;

    private Color headColor, bodyColor;

    private int initialSize;

    private static readonly Dictionary<Direction, Position> directions = new Dictionary<Direction, Position> {
      { Direction.Right, new Position (0, 1) },
      { Direction.Down, new Position (1, 0) },
      { Direction.Left, new Position (0, -1) },
      { Direction.Up, new Position (-1, 0) }
    };

    public Snake (Color headColor, Color bodyColor, int initialSize)
    {
      this.headColor = headColor;
      this.bodyColor = bodyColor;

      this.initialSize = initialSize;

      cells = new LinkedList<Cell> ();
    }

    public void Initialize ()
    {
      NextDirection = CurrentDirection = Direction.Up;

      int centerRow = Grid.Rows >> 1;
      int centerColumn = Grid.Columns >> 1;

      for (int i = 0; i < initialSize; ++i)
      {
        var cell = Grid.Cells[centerRow + i, centerColumn];

        cells.AddLast (cell);

        cell.SetActive (true, bodyColor);
      }

      Head.SetActive (true, headColor);
    }

    public Cell GetNextCell ()
    {
      CurrentDirection = NextDirection;

      var direction = directions [CurrentDirection];

      var row = Head.Row + direction.Row;
      var column = Head.Column + direction.Column;

      Grid.Validate (ref row, ref column);

      return Grid.Cells [row, column];
    }

    public void AddHead (Cell cell)
    {
      Head.SetActive (true, bodyColor);

      cells.AddFirst (cell);

      cell.SetActive (true, headColor);
    }

    public void RemoveTail ()
    {
      cells.Last.Value.SetActive (false);

      cells.RemoveLast ();
    }

    public void Deactivate ()
    {
      foreach (var cell in cells)
      {
        cell.SetActive (false);
      }

      cells.Clear ();
    }
  }
}
