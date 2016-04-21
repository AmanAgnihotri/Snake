using System.Collections;

namespace Snake
{
  public abstract class UserInputHandler : AbstractInputHandler
  {
    public override IEnumerator Update ()
    {
      while (!Game.IsOver)
      {
        HandleInput ();

        yield return null;
      }
    }

    public abstract void HandleInput ();
  }
}
