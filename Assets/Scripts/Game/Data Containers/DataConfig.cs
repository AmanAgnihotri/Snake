using UnityEngine;

namespace Snake
{
  public class PelletConfig
  {
    public Color Color { get; set; }

    public int RowInset { get; set; }

    public int ColumnInset { get; set; }
  }

  public class SnakeConfig
  {
    public Color HeadColor { get; set; }

    public Color BodyColor { get; set; }

    public int InitialSize { get; set; }
  }

  public class GridConfig
  {
    public int Rows { get; set; }

    public int Columns { get; set; }
  }

  public class DataConfig
  {
    public Color BackgroundColor { get; set; }

    public PelletConfig Pellet { get; set; }

    public SnakeConfig Snake { get; set; }

    public GridConfig Grid { get; set; }

    public float TimeSkipPerFrame { get; set; }
  }
}
