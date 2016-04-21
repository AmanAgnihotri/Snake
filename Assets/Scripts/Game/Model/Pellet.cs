using UnityEngine;

namespace Snake
{
  public class Pellet : IPellet
  {
    [Inject]
    public IGrid Grid { get; set; }

    public Cell Cell { get; private set; }

    private Color color;

    private int availableCellsCount;

    private Cell[] availableCells;

    private int minRow, maxRow, minColumn, maxColumn;

    private static readonly System.Random Random = new System.Random ();

    public Pellet (Color color, int rowInset, int columnInset)
    {
      this.color = color;

      minRow = rowInset;

      minColumn = columnInset;
    }

    [PostConstruct]
    public void Initialize ()
    {
      maxRow = Grid.Rows - minRow;
      maxColumn = Grid.Columns - minColumn;

      availableCellsCount = (maxRow - minRow) * (maxColumn - minColumn);

      availableCells = new Cell[availableCellsCount];
    }

    public void Update ()
    {
      UpdateAvailableCells ();

      Cell = availableCells [Random.Next (availableCellsCount)];

      Cell.SetActive (true, color);
    }

    private void UpdateAvailableCells ()
    {
      availableCellsCount = 0;

      for (int row = minRow; row < maxRow; row++)
      {
        for (int column = minColumn; column < maxColumn; column++)
        {
          var cell = Grid.Cells[row, column];

          if (!cell.IsActive ())
          {
            availableCells[availableCellsCount++] = cell;
          }
        }
      }
    }
  }
}
