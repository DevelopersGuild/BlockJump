using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public interface IListner
{
     void OnEventOccurred(EventManager.EventTypes eventName);
}
public class EventManager : MonoBehaviour
{

     public enum EventTypes { PlayerDeath, PlayerLeftGround };

     private Dictionary<EventTypes, List<IListner>> eventList = new Dictionary<EventTypes,List<IListner>>();
     // Use this for initialization
     void Start()
     {

     }

     public void AddEventListner(IListner listener, EventTypes eventName)
     {
          if(eventList.ContainsKey(eventName) == true)
          {
               eventList[eventName].Add(listener);
          }
          else
          {
               eventList.Add(eventName, new List<IListner>());
               eventList[eventName].Add(listener);
          }
     }

     public void CallEvent(EventTypes eventName)
     {
          if(eventList.ContainsKey(eventName) == false)
          {
               return;
          }
          foreach(IListner eventListner in eventList[eventName])
          {
               eventListner.OnEventOccurred(eventName);
          }
     }
}
