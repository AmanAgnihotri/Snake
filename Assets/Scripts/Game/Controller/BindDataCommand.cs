using UnityEngine;
using strange.extensions.command.impl;

namespace Snake
{
  public class BindDataCommand : Command
  {
    [Inject]
    public IDataConfigService DataConfigService { get; set; }

    [Inject]
    public IHighScoreService HighScoreService { get; set; }

    public override void Execute ()
    {
      DataConfigService.GetDataConfig ().Then (BindData);
    }

    private void BindData (DataConfig data)
    {
      Camera.main.backgroundColor = data.BackgroundColor;

      BindGrid (data.Grid);

      BindPellet (data.Pellet, data.Grid);

      BindSnake (data.Snake);

      BindGame (data);
    }

    private void BindGrid (GridConfig g)
    {
      var grid = new Grid (g.Rows, g.Columns);

      injectionBinder.Bind<IGrid> ().ToValue (grid).ToSingleton ();
    }

    private void BindPellet (PelletConfig p, GridConfig g)
    {
      while ((p.RowInset << 1) >= g.Rows)
      {
        p.RowInset >>= 1;
      }

      while ((p.ColumnInset << 1) >= g.Columns)
      {
        p.ColumnInset >>= 1;
      }

      var pellet = new Pellet (p.Color, p.RowInset, p.ColumnInset);

      injectionBinder.Bind<IPellet> ().ToValue (pellet).ToSingleton ();
    }

    private void BindSnake (SnakeConfig s)
    {
      var snake = new Snake (s.HeadColor, s.BodyColor, s.InitialSize);

      injectionBinder.Bind<ISnake> ().ToValue (snake).ToSingleton ();
    }

    private void BindGame (DataConfig d)
    {
      var g = d.Grid;
      var p = d.Pellet;

      var maxScore = (g.Rows - (p.RowInset << 1)) * (g.Columns - (p.ColumnInset << 1));

      var game = new Game (maxScore, d.TimeSkipPerFrame);

      injectionBinder.Bind<IGame> ().ToValue (game).ToSingleton ();
    }
  }
}
