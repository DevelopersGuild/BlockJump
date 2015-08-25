using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class EventManager : MonoBehaviour
{
     public delegate void Listener(EventManager.EventTypes eventType);

     public enum EventTypes { PlayerDeath, PlayerLeftGround, RestartGame };

     private Dictionary<EventTypes, List<Listener>> eventList = new Dictionary<EventTypes,List<Listener>>();

     public void AddEventListner(Listener listener, EventTypes eventName)
     {
          if(eventList.ContainsKey(eventName) == true)
          {
               eventList[eventName].Add(listener);
          }
          else
          {
               eventList.Add(eventName, new List<Listener>());
               eventList[eventName].Add(listener);
          }
     }

     public void CallEvent(EventTypes eventName)
     {
          if(eventList.ContainsKey(eventName) == false)
          {
               return;
          }
          foreach(Listener eventListner in eventList[eventName])
          {
               eventListner(eventName);
          }
     }
}
