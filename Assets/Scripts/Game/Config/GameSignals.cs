using strange.extensions.signal.impl;

namespace Snake
{
  public class BindDataSignal : Signal {}

  public class BindInputHandlerSignal : Signal<InputHandlerType> {}

  public class ShowSignal : Signal<ShowType> {}

  public class SetupMainMenuSignal : Signal {}

  public class UpdateScoreSignal : Signal<int> {}

  public class StartGameSignal : Signal {}

  public class SetHighScoreSignal : Signal<int> {}

  public class GameOverSignal : Signal<bool, int> {}

  public class SetupAfterGameSignal : Signal<bool, int> {}
}
