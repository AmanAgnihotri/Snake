namespace Snake
{
  public interface ISnake
  {
    Direction CurrentDirection { get; }

    Direction NextDirection { get; set; }

    Cell Head { get; }

    void Initialize ();

    Cell GetNextCell ();

    void AddHead (Cell cell);

    void RemoveTail ();

    void Deactivate ();
  }
}
