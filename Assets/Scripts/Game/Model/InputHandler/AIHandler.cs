using UnityEngine;
using System.Collections;

namespace Snake
{
  public class AIHandler : AbstractInputHandler
  {
    [Inject]
    public IPellet Pellet { get; set; }

    [Inject]
    public IPathfinder Pathfinder { get; set; }

    private Cell snakeHead;

    public override IEnumerator Update ()
    {
      while (!Game.IsOver)
      {
        snakeHead = Snake.Head;

        var directions = Pathfinder.GetDirections (snakeHead, Pellet.Cell);

        var isPathAvailable = false;

        foreach (var dir in directions)
        {
          isPathAvailable = true;

          Handle (dir);

          while (snakeHead == Snake.Head)
          {
            yield return new WaitForSeconds (Game.TimeSkipPerFrame);
          }

          snakeHead = Snake.Head;
        }

        if (!isPathAvailable)
        {
          while (snakeHead == Snake.Head)
          {
            yield return new WaitForSeconds (Game.TimeSkipPerFrame);
          }
        }
      }
    }
  }
}
