using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Layers : MonoBehaviour
{
    // Singleton
    static private Layers instance;
    static public Layers Instance 
    {
        get 
        {
            if (instance == null)
            {
                Debug.LogError("There is no Layers instance in the scene.");
            }
            return instance;
        }
    }

    public LayerMask player;
    public LayerMask terrain;
    public LayerMask missile;
    public LayerMask radar;
    public LayerMask bullet;
    public LayerMask bomb;
    public LayerMask checkpoint;
    
    void Awake()
    {   
        if (instance != null) 
        {
            // destroy duplicates
            Destroy(gameObject);            
        }
        else 
        {
            instance = this;
        }
    }
}
