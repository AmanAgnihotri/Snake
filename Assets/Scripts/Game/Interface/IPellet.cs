namespace Snake
{
  public interface IPellet
  {
    Cell Cell { get; }

    void Update ();
  }
}
