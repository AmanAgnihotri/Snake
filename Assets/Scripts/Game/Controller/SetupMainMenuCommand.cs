using strange.extensions.command.impl;

namespace Snake
{
  public class SetupMainMenuCommand : Command
  {
    [Inject]
    public SetHighScoreSignal SetHighScoreSignal { get; set; }

    [Inject]
    public IHighScoreService HighScoreService { get; set; }

    public override void Execute ()
    {
      var highScore = HighScoreService.GetHighScore ();

      if (highScore > 0)
      {
        SetHighScoreSignal.Dispatch (highScore);
      }
    }
  }
}
