using UnityEngine.UI;
using strange.extensions.signal.impl;
using strange.extensions.mediation.impl;

namespace Snake
{
  public class MainMenuView : View
  {
    public Text HighScore;

    internal Signal<InputHandlerType> Signal = new Signal<InputHandlerType> ();

    public void Play ()
    {
      Signal.Dispatch (InputHandlerType.Player);
    }

    public void PlayBoundedAI ()
    {
      Signal.Dispatch (InputHandlerType.BoundedAI);
    }

    public void PlayUnboundedAI ()
    {
      Signal.Dispatch (InputHandlerType.UnboundedAI);
    }
  }
}
