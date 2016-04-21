using UnityEngine;
using System.Collections;

namespace Snake
{
  public class SwipeHandler : UserInputHandler
  {
    private float screenDiagonalSize;
    private float minimumSwipeDistanceInPixels;

    private bool touchStarted;
    private Vector2 touchStartPosition;

    public float minSwipeDistance = 0.04f;

    [PostConstruct]
    public void Initialize ()
    {
      screenDiagonalSize = Mathf.Sqrt (Screen.width * Screen.width + Screen.height * Screen.height);

      minimumSwipeDistanceInPixels = minSwipeDistance * screenDiagonalSize; 
    }

    public override void HandleInput ()
    {
      if (Input.touchCount > 0)
      {
        var touch = Input.touches [0];

        switch (touch.phase)
        {
          case TouchPhase.Began:
            touchStarted = true;
            touchStartPosition = touch.position;
            break;

          case TouchPhase.Ended:
            if (touchStarted)
            {
              HandleSwipe (touch);
              touchStarted = false;
            }
            break;

          case TouchPhase.Canceled:
            touchStarted = false;
            break;
        }
      }
    }

    private void HandleSwipe (Touch touch)
    {
      Vector2 lastPosition = touch.position;
      float distance = Vector2.Distance (lastPosition, touchStartPosition);

      if (distance > minimumSwipeDistanceInPixels)
      {
        float dy = lastPosition.y - touchStartPosition.y;
        float dx = lastPosition.x - touchStartPosition.x;

        float angle = Mathf.Rad2Deg * Mathf.Atan2 (dx, dy);

        angle = (360 + angle - 45) % 360;

        if (angle < 90)
          Handle (Direction.Right);
        else if (angle < 180)
          Handle (Direction.Down);
        else if (angle < 270)
          Handle (Direction.Left);
        else
          Handle (Direction.Up);
      }
    }
  }
}
