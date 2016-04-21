using System;
using System.IO;
using UnityEngine;

namespace Snake
{
  [Implements (typeof (IHighScoreService))]
  public class HighScoreService : IHighScoreService
  {
    private int highScore = 0;

    private string filePath = Application.persistentDataPath + "/" + "HighScore";

    public int GetHighScore ()
    {
      if (File.Exists(filePath) && highScore <= 0)
      {
        LoadHighScore ();
      }

      return highScore;
    }

    public void Persist (int score)
    {
      if (score > highScore)
      {
        highScore = score;
      }

      File.WriteAllText (filePath, string.Format ("{0}", score));
    }

    private void LoadHighScore ()
    {
      Int32.TryParse (File.ReadAllText(filePath), out highScore);
    }
  }
}
