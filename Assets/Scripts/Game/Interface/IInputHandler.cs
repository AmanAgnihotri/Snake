using System.Collections;

namespace Snake
{
  public interface IInputHandler
  {
    IEnumerator Update ();

    IEnumerator UpdateEscape ();
  }
}
