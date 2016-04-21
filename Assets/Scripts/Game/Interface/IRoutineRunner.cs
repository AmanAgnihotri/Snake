using UnityEngine;
using System.Collections;

namespace Snake
{
  public interface IRoutineRunner
  {
    Coroutine StartRoutine (IEnumerator routine);

    void StopAllRoutines ();
  }
}
