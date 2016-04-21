using UnityEngine;

namespace Snake
{
  public class Grid : IGrid
  {
    public int Rows { get; private set; }

    public int Columns { get; private set; }

    public float CellSize { get; private set; }

    public Cell[,] Cells { get; private set; }

    public Grid (int rows, int columns)
    {
      Rows = rows;

      Columns = columns;

      var rowBasedCellSize = (float) Screen.height / Rows;
      var columnBasedCellSize = (float) Screen.width / Columns ;

      CellSize = Mathf.Min (rowBasedCellSize, columnBasedCellSize);

      InitializeCells ();
    }

    public void Validate (ref int row, ref int column)
    {
      row %= Rows;
      column %= Columns;

      if (row < 0)
      {
        row += Rows;
      }

      if (column < 0)
      {
        column += Columns;
      }
    }

    private void InitializeCells ()
    {
      var defaultCell = GetDefaultCell ();

      Cells = new Cell[Rows, Columns];

      float offsetX = GetOffsetFor (Columns);
      float offsetY = GetOffsetFor (Rows);

      for (int row = 0; row < Rows; ++row)
      {
        for (int column = 0; column < Columns; ++column)
        {
          var cell = Object.Instantiate (defaultCell) as GameObject;

          var position = cell.transform.position;

          position.x = -offsetX + column * CellSize;
          position.y = offsetY - row * CellSize;

          cell.transform.position = position;

          Cells[row, column] = new Cell (row, column, cell);
        }
      }
    }

    private GameObject GetDefaultCell ()
    {
      GameObject cell = Resources.Load<GameObject> ("Cell");

      cell.transform.localScale = new Vector3 (CellSize, CellSize, 1);

      cell.SetActive (false);

      return cell;
    }

    private float GetOffsetFor (int value)
    {
      return (value - 1) * (CellSize / 2f);
    }
  }
}
