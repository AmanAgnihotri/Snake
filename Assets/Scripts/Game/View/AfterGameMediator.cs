using strange.extensions.mediation.impl;

namespace Snake
{
  [Mediates (typeof (AfterGameView))]
  public class AfterGameMediator : Mediator
  {
    [Inject]
    public AfterGameView AfterGameView { get; set; }

    [Inject]
    public ShowSignal ShowSignal { get; set; }

    [Inject]
    public SetupAfterGameSignal SetupAfterGameSignal { get; set; }

    public override void OnRegister ()
    {
      AfterGameView.Signal.AddListener (HandleType);

      SetupAfterGameSignal.AddListener (SetupValues);
    }

    public override void OnRemove ()
    {
      AfterGameView.Signal.RemoveListener (HandleType);

      SetupAfterGameSignal.RemoveListener (SetupValues);
    }

    private void HandleType (ShowType type)
    {
      ShowSignal.Dispatch (type);
    }

    private void SetupValues (bool hasWon, int score)
    {
      AfterGameView.State.text = hasWon ? "Game Won!" : "Game Over!";

      AfterGameView.Score.text = string.Format ("Score: {0:D4}", score);
    }
  }
}
