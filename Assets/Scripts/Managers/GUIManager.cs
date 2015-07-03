using UnityEngine;
using System.Collections;

public class GUIManager : MonoBehaviour, IListner
{
     public Canvas ScoreCanvas = null;
     // Use this for initialization
     void Start()
     {
          if(ScoreCanvas != null)
          {
               ScoreCanvas.enabled = false;
          }
          GameManager.Events.AddEventListner(this, EventManager.EventTypes.PlayerDeath);
     }

     // Update is called once per frame
     void Update()
     {

     }

     public void OnEventOccurred(EventManager.EventTypes typeOfEvent)
     {
          ScoreCanvas.enabled = true;
     }
}
