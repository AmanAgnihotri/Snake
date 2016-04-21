using strange.extensions.command.impl;

namespace Snake
{
  public class GameOverCommand : Command
  {
    [Inject]
    public bool HasWon { get; set; }

    [Inject]
    public int Score { get; set; }

    [Inject]
    public IGame Game { get; set; }

    [Inject]
    public IRoutineRunner RoutineRunner { get; set; }

    [Inject]
    public IHighScoreService HighScoreService { get; set; }

    public override void Execute ()
    {
      Game.Reset ();

      RoutineRunner.StopAllRoutines ();

      HighScoreService.Persist (Score);
    }
  }
}
