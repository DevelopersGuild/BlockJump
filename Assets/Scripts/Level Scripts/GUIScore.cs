using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GUIScore : MonoBehaviour
{
     public Text Score;
     
     // Use this for initialization
     void Start()
     {
          GameManager.Events.AddEventListner(OnEventOccurred, EventManager.EventTypes.PlayerDeath);
     }

     public void OnEventOccurred(EventManager.EventTypes eventType)
     {
          if(eventType == EventManager.EventTypes.PlayerDeath)
          {
               Score.text = "Score " + CalculateScore().ToString();
          }
     }
     
     private int CalculateScore()
     {
          int score;
          score = (int)Time.time * 10;
          return score;
     }


}
