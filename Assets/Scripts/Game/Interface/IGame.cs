using System.Collections;

namespace Snake
{
  public interface IGame
  {
    bool IsOver { get; }

    int Score { get; }

    int MaxScore { get; }

    float TimeSkipPerFrame { get; }

    IEnumerator Update ();

    void Reset ();
  }
}
