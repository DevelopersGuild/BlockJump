using UnityEngine;
using System.Collections;

public class LoadAndSaveManager : MonoBehaviour
{

    public int GetScore()
    {
        return LoadScore();
    }

    public void SaveHighScore(int highScore)
    {
        PlayerPrefs.SetInt("HighScore", highScore);
        PlayerPrefs.Save();
    }

    public int LoadScore()
    {
        if(PlayerPrefs.HasKey("HighScore"))
        {
            return PlayerPrefs.GetInt("HighScore");
        }
        else
        {
            return 0;
        }
    }
}
