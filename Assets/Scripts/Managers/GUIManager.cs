using UnityEngine;
using System.Collections;

public class GUIManager : MonoBehaviour
{
     public Canvas ScoreCanvas = null;
     // Use this for initialization
     void Start()
     {
          if(ScoreCanvas != null)
          {
               ScoreCanvas.enabled = false;
          }
          GameManager.Events.AddEventListner(OnEventOccurred, EventManager.EventTypes.PlayerDeath);
          GameManager.Events.AddEventListner(OnEventOccurred, EventManager.EventTypes.RestartGame);
     }

     public void OnEventOccurred(EventManager.EventTypes typeOfEvent)
     {
          if(typeOfEvent == EventManager.EventTypes.PlayerDeath)
          {
               ScoreCanvas.enabled = true;
          }
          if(typeOfEvent == EventManager.EventTypes.RestartGame)
          {
               ScoreCanvas.enabled = false;
          }
          
     }

     public void HideScoreCanvas()
     {
          ScoreCanvas.enabled = false;
     }
}


