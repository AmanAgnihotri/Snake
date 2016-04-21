using strange.extensions.mediation.impl;

namespace Snake
{
  [Mediates (typeof (GameView))]
  public class GameMediator : Mediator
  {
    [Inject]
    public GameView GameView { get; set; }

    [Inject]
    public ShowSignal ShowSignal { get; set; }

    [Inject]
    public SetupMainMenuSignal SetupMainMenuSignal { get; set; }

    [Inject]
    public StartGameSignal StartGameSignal { get; set; }

    [Inject]
    public GameOverSignal GameOverSignal { get; set; }

    [Inject]
    public SetupAfterGameSignal SetupAfterGameSignal { get; set; }

    public override void OnRegister ()
    {
      ShowSignal.AddListener (Show);

      GameOverSignal.AddListener (ShowAfterGame);
    }

    public override void OnRemove ()
    {
      ShowSignal.RemoveListener (Show);

      GameOverSignal.RemoveListener (ShowAfterGame);
    }

    private void Show (ShowType type)
    {
      switch (type)
      {
        case ShowType.MainMenu:
          ShowMainMenu ();
          break;
        case ShowType.InGame:
          ShowInGame ();
          break;
      }
    }

    private void ShowMainMenu ()
    {
      SetActive (true, false, false);

      SetupMainMenuSignal.Dispatch ();
    }

    private void ShowInGame ()
    {
      SetActive (false, true, false);

      StartGameSignal.Dispatch ();
    }

    private void ShowAfterGame (bool hasWon, int score)
    {
      SetActive (false, false, true);

      SetupAfterGameSignal.Dispatch (hasWon, score);
    }

    private void SetActive (bool mainMenu, bool inGame, bool afterGame)
    {
      GameView.MainMenu.SetActive (mainMenu);

      GameView.InGame.SetActive (inGame);

      GameView.AfterGame.SetActive (afterGame);
    }
  }
}
