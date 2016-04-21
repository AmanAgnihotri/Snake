using UnityEngine;
using System.Collections;

namespace Snake
{
  public class Game : IGame
  {
    [Inject]
    public ISnake Snake { get; set; }

    [Inject]
    public IPellet Pellet { get; set; }

    [Inject]
    public UpdateScoreSignal UpdateScoreSignal { get; set; }

    [Inject]
    public GameOverSignal GameOverSignal { get; set; }

    public bool IsOver { get; set; }

    public int Score { get; private set; }

    public int MaxScore { get; private set; }

    public float TimeSkipPerFrame { get; private set; }

    public Game (int maxScore, float timeSkipPerFrame)
    {
      MaxScore = maxScore;

      TimeSkipPerFrame = timeSkipPerFrame;
    }

    public IEnumerator Update ()
    {
      Snake.Initialize ();

      Pellet.Update ();

      IsOver = false;

      while (!IsOver)
      {
        var cell = Snake.GetNextCell ();

        if (cell.IsActive () && Pellet.Cell != cell)
        {
          EndGame (false);
        }
        else
        {
          Snake.AddHead (cell);

          if (Pellet.Cell == cell)
          {
            UpdatePelletScore ();
          }
          else
          {
            Snake.RemoveTail ();
          }
        }

        yield return new WaitForSeconds (TimeSkipPerFrame);
      }
    }

    public void Reset ()
    {
      IsOver = true;

      Score = 0;

      Snake.Deactivate ();

      Pellet.Cell.SetActive (false);
    }

    private void UpdatePelletScore ()
    {
      if (Score >= MaxScore)
      {
        EndGame (true);
      }
      else
      {
        Pellet.Update ();

        UpdateScoreSignal.Dispatch (++Score);
      }
    }

    private void EndGame (bool hasWon)
    {
      GameOverSignal.Dispatch (hasWon, Score);
    }
  }
}
