using UnityEngine;
using strange.extensions.command.impl;

namespace Snake
{
  public class StartGameCommand : Command
  {
    [Inject]
    public IGame Game { get; set; }

    [Inject]
    public IInputHandler InputHandler { get; set; }

    [Inject]
    public IRoutineRunner RoutineRunner { get; set; }

    [Inject]
    public UpdateScoreSignal UpdateScoreSignal { get; set; }

    public override void Execute ()
    {
      Camera.main.orthographicSize = Screen.height / 2f;

      UpdateScoreSignal.Dispatch (0);

      RoutineRunner.StartRoutine (Game.Update ());

      RoutineRunner.StartRoutine (InputHandler.Update ());

      RoutineRunner.StartRoutine (InputHandler.UpdateEscape ());
    }
  }
}
