using UnityEngine;
using System.Collections;

[RequireComponent(typeof(EventManager))]
public class GameManager : MonoBehaviour, IListner
{
     public static GameManager Instance
     {
          get
          {
               if (instance == null)
               {
                    instance = new GameObject("GameManager").AddComponent<GameManager>();
               }
               return instance;
          }
     }

     public static EventManager Events
     {
          get
          {
               if(events == null)
               {
                    events = instance.GetComponent<EventManager>();
               }
               return events;
          }
     }

     private static GameManager instance = null;
     private static EventManager events = null;
     AdWrapper adWrapper;

     void Awake()
     {
          if ((instance) && (instance.GetInstanceID() != GetInstanceID()))
          {
               DestroyImmediate(gameObject);
          }
          else
          {
               instance = this;
               DontDestroyOnLoad(gameObject);
          }
     }

     // Use this for initialization
     void Start()
     {
          adWrapper = new AdWrapper();
          adWrapper.RequestBannerAd();
          GameManager.Events.AddEventListner(this, EventManager.EventTypes.PlayerDeath);
     }

     // Update is called once per frame
     void Update()
     {

     }

     public void SwitchLevel(int LevelNumber)
     {
          Application.LoadLevel(LevelNumber);
     }

     public void RestartLevel()
     {
          Application.LoadLevel(Application.loadedLevel);
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

