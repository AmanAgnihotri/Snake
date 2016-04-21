using strange.extensions.context.impl;

namespace Snake
{
  public class GameBootstrap : ContextView
  {
    private void Awake ()
    {
      context = new GameContext (this);
    }
  }
}
