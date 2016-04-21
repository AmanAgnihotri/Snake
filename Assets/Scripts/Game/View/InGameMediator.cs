using strange.extensions.mediation.impl;

namespace Snake
{
  [Mediates (typeof (InGameView))]
  public class InGameMediator : Mediator
  {
    [Inject]
    public InGameView InGameView { get; set; }

    [Inject]
    public UpdateScoreSignal UpdateScoreSignal { get; set; }

    public override void OnRegister ()
    {
      UpdateScoreSignal.AddListener (UpdateScore);
    }

    public override void OnRemove ()
    {
      UpdateScoreSignal.RemoveListener (UpdateScore);
    }

    private void UpdateScore (int score)
    {
      InGameView.Score.text = string.Format ("Score: {0:D4}", score);
    }
  }
}
