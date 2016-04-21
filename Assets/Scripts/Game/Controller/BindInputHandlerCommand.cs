using strange.extensions.command.impl;

namespace Snake
{
  public class BindInputHandlerCommand : Command
  {
    [Inject]
    public InputHandlerType InputHandlerType { get; set; }

    public override void Execute ()
    {
      injectionBinder.Unbind<IInputHandler> ();

      injectionBinder.Unbind<IPathfinder> ();

      if (InputHandlerType == InputHandlerType.Player)
      {
        #if UNITY_EDITOR || UNITY_STANDALONE || UNITY_WEBPLAYER
        injectionBinder.Bind<IInputHandler> ().To<KeyboardHandler> ().ToSingleton ();
        #elif UNITY_IOS || UNITY_ANDROID || UNITY_WP8 || UNITY_WP8_1
        injectionBinder.Bind<IInputHandler> ().To<SwipeHandler> ().ToSingleton ();
        #endif
      }
      else
      {
        injectionBinder.Bind<IInputHandler> ().To<AIHandler> ().ToSingleton ();

        if (InputHandlerType == InputHandlerType.BoundedAI)
        {
          injectionBinder.Bind<IPathfinder> ().To<BoundedPathfinder> ().ToSingleton ();
        }
        else
        {
          injectionBinder.Bind<IPathfinder> ().To<UnboundedPathfinder> ().ToSingleton ();
        }
      }
    }
  }
}
