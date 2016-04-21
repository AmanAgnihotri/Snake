namespace Snake
{
  public interface IGrid
  {
    int Rows { get; }

    int Columns { get; }

    Cell[,] Cells { get; }

    void Validate (ref int row, ref int column);
  }
}
