using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Snake
{
  public abstract class AbstractInputHandler : IInputHandler
  {
    [Inject]
    public ISnake Snake { get; set; }

    [Inject]
    public IGame Game { get; set; }

    [Inject]
    public GameOverSignal GameOverSignal { get; set; }

    private static readonly Dictionary<Direction, Direction> opposites = new Dictionary<Direction, Direction>
    {
      { Direction.Right, Direction.Left },
      { Direction.Down, Direction.Up },
      { Direction.Left, Direction.Right },
      { Direction.Up, Direction.Down }
    };

    public IEnumerator UpdateEscape ()
    {
      while (!Game.IsOver)
      {
        if (Input.GetKeyDown (KeyCode.Escape))
        {
          GameOverSignal.Dispatch (false, Game.Score);
        }

        yield return null;
      }
    }

    protected void Handle (Direction direction)
    {
      if (Snake.NextDirection != direction && Snake.CurrentDirection != opposites [direction])
      {
        Snake.NextDirection = direction;
      }
    }

    public abstract IEnumerator Update ();
  }
}
