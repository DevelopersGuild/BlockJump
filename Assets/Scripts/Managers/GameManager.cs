using UnityEngine;
using System.Collections;

[RequireComponent(typeof(EventManager))]
[RequireComponent(typeof(LoadAndSaveManager))]
public class GameManager : MonoBehaviour
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
            if (events == null)
            {
                events = instance.GetComponent<EventManager>();
            }
            return events;
        }
    }

    public static LoadAndSaveManager LoadSave
    {
        get
        {
            if(loadSave == null)
            {
                loadSave = instance.GetComponent<LoadAndSaveManager>();
            }
            return loadSave;
        }
    }

    void Awake()
    {
        if ((instance) && (instance.GetInstanceID() != GetInstanceID()))
        {
            DestroyImmediate(gameObject);
        }
        else
        {
            instance = this;
            //DontDestroyOnLoad(gameObject);
        }
    }

    private static GameManager instance = null;
    private static EventManager events = null;
    private static LoadAndSaveManager loadSave = null;
    private float timeSinceLevelStart = 0;
    private int score = 0;
    AdWrapper adWrapper;


    // Use this for initialization
    void Start()
    {
        /*
        adWrapper = new AdWrapper();
        adWrapper.RequestBannerAd();
         * */
        Events.AddEventListner(OnEventOccurred, EventManager.EventTypes.PlayerDeath);
        Events.AddEventListner(OnEventOccurred, EventManager.EventTypes.PlayerLeftGround);
    }


    public void SwitchLevel(int LevelNumber)
    {
        Application.LoadLevel(LevelNumber);
    }

    public void RestartLevel()
    {
        SwitchLevel(0);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void OnEventOccurred(EventManager.EventTypes typeOfEvent)
    {
        if (typeOfEvent == EventManager.EventTypes.PlayerDeath)
        {
            Debug.Log("Player Has died");
        }
        if(typeOfEvent == EventManager.EventTypes.PlayerLeftGround)
        {
            timeSinceLevelStart = Time.time;
        }
    }

    public float GetLevelTime()
    {
        return timeSinceLevelStart;
    }

    public int CalculateScore()
    {
        score = (int)(Time.time - timeSinceLevelStart) * 10;
        return score;
    }

    public void SaveHighScore()
    {
        if(CheckForNewHighScore())
        {
            loadSave.SaveHighScore(score);
        }
    }

    public bool CheckForNewHighScore()
    {
        if(score > GetHighScore())
        {
            return true;
        }
        return false;
    }

    public int GetHighScore()
    {
        return loadSave.GetScore();
    }
}

