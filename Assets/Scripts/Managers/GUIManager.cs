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
     }

     public void OnEventOccurred(EventManager.EventTypes typeOfEvent)
     {
          ScoreCanvas.enabled = true;
     }
}


