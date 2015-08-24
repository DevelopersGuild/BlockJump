using UnityEngine;
using System.Collections;

[RequireComponent(typeof(EventManager))]
public class GameManager : MonoBehaviour
{
     public static GameManager Instance = null;
     public static EventManager Events = null;
     AdWrapper adWrapper;

     void Awake()
     {
          if (Instance == null)
          {
               Instance = gameObject.GetComponent<GameManager>();
          }
          if ((Instance) && (Instance.GetInstanceID() != GetInstanceID()))
          {
               DestroyImmediate(gameObject);
          }
          else
          {
               Instance = this;
               DontDestroyOnLoad(gameObject);
          }
          if (Events == null)
          {
               Events = Instance.GetComponent<EventManager>();
          }
     }

     // Use this for initialization
     void Start()
     {
          /*
          adWrapper = new AdWrapper();
          adWrapper.RequestBannerAd();
           * */
          GameManager.Events.AddEventListner(OnEventOccurred, EventManager.EventTypes.PlayerDeath);
     }


     public void SwitchLevel(int LevelNumber)
     {
          Application.LoadLevel(LevelNumber);
     }

     public void RestartLevel()
     {
          //this is the problem with the game not restarting...
          //Find solution or restart level by reseting varaibles.
          Application.LoadLevel(1);
     }

     public void ExitGame()
     {
          Application.Quit();
     }

     public void OnEventOccurred(EventManager.EventTypes typeOfEvent)
     {
          if(typeOfEvent == EventManager.EventTypes.PlayerDeath)
          {
               Debug.Log("Player Has died");
          }
     }
}

