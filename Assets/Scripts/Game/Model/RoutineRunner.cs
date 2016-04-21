using UnityEngine;
using System.Collections;
using strange.extensions.context.api;
using strange.extensions.injector.api;

namespace Snake
{
  [Implements (typeof (IRoutineRunner), InjectionBindingScope.CROSS_CONTEXT)]
  public class RoutineRunner : IRoutineRunner
  {
    [Inject (ContextKeys.CONTEXT_VIEW)]
    public GameObject ContextView { get; set; }

    private RoutineRunnerBehaviour Runner { get; set; }

    [PostConstruct]
    public void PostConstruct ()
    {
      Runner = ContextView.AddComponent<RoutineRunnerBehaviour> ();
    }

    public Coroutine StartRoutine (IEnumerator routine)
    {
      return Runner.StartCoroutine (routine);
    }

    public void StopAllRoutines ()
    {
      Runner.StopAllCoroutines ();
    }

    private class RoutineRunnerBehaviour : MonoBehaviour {}
  }
}
