using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnalyticsManager : MonoBehaviour
{
    private LogFile log;
    private PlayerMove player;

    // Singleton
    static private AnalyticsManager instance;
    static public AnalyticsManager Instance 
    {
        get 
        {
            if (instance == null) 
            {
                Debug.LogError("There is no AnalyticsManager in the scene.");
            }            
            return instance;
        }
    }
    void Awake() 
    {
        if (instance != null)
        {
            // there is already an AnalyticsManager in the scene, destory this one
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    void Start()
    {
        // find the logfile script
        log = gameObject.GetComponent<LogFile>();
        player = FindObjectOfType<PlayerMove>();
    }

    void Update()
    {
        if (log != null) 
        {
			// write the time and the players x and y positions to the file
			log.WriteLine(Time.time,
                 player.transform.position.x,
                 player.transform.position.y);
		}
    }
}
