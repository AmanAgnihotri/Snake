using UnityEngine.UI;
using strange.extensions.signal.impl;
using strange.extensions.mediation.impl;

namespace Snake
{
  public class AfterGameView : View
  {
    public Text State;

    public Text Score;

    internal Signal<ShowType> Signal = new Signal<ShowType> ();

    public void Restart ()
    {
      Signal.Dispatch (ShowType.InGame);
    }

    public void GotoMainMenu ()
    {
      Signal.Dispatch (ShowType.MainMenu);
    }
  }
}
