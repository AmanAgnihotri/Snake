using UnityEngine;

namespace Snake
{
  public class KeyboardHandler : UserInputHandler
  {
    public override void HandleInput ()
    {
      switch (Input.inputString.ToUpper ())
      {
        case "D": Handle (Direction.Right); break;
        case "S": Handle (Direction.Down); break;
        case "A": Handle (Direction.Left); break;
        case "W": Handle (Direction.Up); break;
      }
    }
  }
}
