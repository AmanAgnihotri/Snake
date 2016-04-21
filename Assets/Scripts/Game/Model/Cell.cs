using UnityEngine;

namespace Snake
{
  public class Cell
  {
    public int Row { get; private set; }

    public int Column { get; private set; }

    private GameObject gameObject;

    private SpriteRenderer renderer;

    public Cell (int row, int column, GameObject gameObject)
    {
      Row = row;

      Column = column;

      this.gameObject = gameObject;

      renderer = gameObject.GetComponent<SpriteRenderer> ();
    }

    public bool IsActive ()
    {
      return gameObject.activeSelf;
    }

    public void SetActive (bool value)
    {
      gameObject.SetActive (value);
    }

    public void SetActive (bool value, Color color)
    {
      gameObject.SetActive (value);

      renderer.color = color;
    }
  }
}
