using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GUIScore : MonoBehaviour
{
    public Text HighScore;
    public Text Score;

    // Use this for initialization
    void Start()
    {
        GameManager.Events.AddEventListner(OnEventOccurred, EventManager.EventTypes.PlayerDeath);
        HighScore.text = "High Score " + GameManager.LoadSave.GetScore().ToString();
    }

    public void OnEventOccurred(EventManager.EventTypes eventType)
    {
        if (eventType == EventManager.EventTypes.PlayerDeath)
        {
            if(GameManager.Instance.CalculateScore() > GameManager.LoadSave.GetScore())
            {
                HighScore.text = "New High Score! " + GameManager.Instance.CalculateScore().ToString();
            }
            Score.text = "Score " + GameManager.Instance.CalculateScore().ToString();
        }
        GameManager.Instance.SaveHighScore();
    }



}
