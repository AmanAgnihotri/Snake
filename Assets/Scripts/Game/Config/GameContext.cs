using strange.extensions.context.impl;

namespace Snake
{
  public class GameContext : MVCSContext
  {
    public GameContext (ContextView contextView) : base (contextView) {}

    protected override void mapBindings ()
    {
      implicitBinder.ScanForAnnotatedClasses ("Snake");

      injectionBinder.Bind<ShowSignal> ().ToSingleton ();
      injectionBinder.Bind<UpdateScoreSignal> ().ToSingleton ();
      injectionBinder.Bind<SetHighScoreSignal> ().ToSingleton ();
      injectionBinder.Bind<SetupAfterGameSignal> ().ToSingleton ();

      commandBinder.Bind<BindDataSignal> ().To<BindDataCommand> ().Once ();
      commandBinder.Bind<BindInputHandlerSignal> ().To<BindInputHandlerCommand> ().Pooled ();

      commandBinder.Bind<SetupMainMenuSignal> ().To<SetupMainMenuCommand> ().Pooled ();

      commandBinder.Bind<StartGameSignal> ().To<StartGameCommand> ().Pooled ();
      commandBinder.Bind<GameOverSignal> ().To<GameOverCommand> ().Pooled ();
    }

    public override void Launch ()
    {
      injectionBinder.GetInstance<BindDataSignal> ().Dispatch ();

      injectionBinder.GetInstance<ShowSignal> ().Dispatch (ShowType.MainMenu);
    }
  }
}
