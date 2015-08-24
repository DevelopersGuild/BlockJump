using UnityEngine;
using System.Collections;

public class Ground : MonoBehaviour
{
     private bool doesGroundKillsPlayer = false;
     // Use this for initialization
     void Start()
     {
          GameManager.Events.AddEventListner(OnEventOccurred, EventManager.EventTypes.PlayerLeftGround);
     }

     // Update is called once per frame
     void Update()
     {

     }

     public bool GetDoesGroundKillPlayer()
     {
          return doesGroundKillsPlayer;
     }

     public void OnEventOccurred(EventManager.EventTypes eventType)
     {
          if(eventType == EventManager.EventTypes.PlayerLeftGround)
          {
               doesGroundKillsPlayer = true;
          }
     }
}
