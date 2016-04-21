namespace Snake
{
  public interface IHighScoreService
  {
    int GetHighScore ();

    void Persist (int score);
  }
}
