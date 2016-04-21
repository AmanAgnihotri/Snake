using strange.extensions.mediation.impl;

namespace Snake
{
  [Mediates (typeof (MainMenuView))]
  public class MainMenuMediator : Mediator
  {
    [Inject]
    public MainMenuView MainMenuView { get; set; }

    [Inject]
    public SetHighScoreSignal SetHighScoreSignal { get; set; }

    [Inject]
    public BindInputHandlerSignal BindInputHandlerSignal { get; set; }

    [Inject]
    public ShowSignal ShowSignal { get; set; }

    public override void OnRegister ()
    {
      MainMenuView.HighScore.gameObject.SetActive (false);

      MainMenuView.Signal.AddListener (SetupGame);

      SetHighScoreSignal.AddListener (SetHighScore);
    }

    public override void OnRemove ()
    {
      MainMenuView.Signal.RemoveListener (SetupGame);

      SetHighScoreSignal.RemoveListener (SetHighScore);
    }

    private void SetupGame (InputHandlerType inputHandlerType)
    {
      BindInputHandlerSignal.Dispatch (inputHandlerType);

      ShowSignal.Dispatch (ShowType.InGame);
    }

    private void SetHighScore (int score)
    {
      MainMenuView.HighScore.gameObject.SetActive (true);

      MainMenuView.HighScore.text = string.Format ("Highscore: {0:D4}", score);
    }
  }
}
