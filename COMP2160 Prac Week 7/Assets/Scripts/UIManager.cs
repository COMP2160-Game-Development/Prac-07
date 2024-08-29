using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    // Singleton
    static private UIManager instance;
    static public UIManager Instance 
    {
        get 
        {
            if (instance == null) 
            {
                Debug.LogError("There is not UIManager in the scene.");
            }            
            return instance;
        }
    }

    [SerializeField] private Text scoreText;
    [SerializeField] private Text livesText;
    [SerializeField] private Text gameOverText;
    [SerializeField] private string scoreFormat = "Score: {0}";
    [SerializeField] private string livesFormat = "Lives: {0}";
    [SerializeField] private string winText = "YOU WIN!!!";
    [SerializeField] private string loseText = "YOU LOSE!!!";

    [SerializeField] private GameObject gameOverPanel;

    void Awake() 
    {
        if (instance != null)
        {
            // there is already a UIManager in the scene, destory this one
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    void Start()
    {
        gameOverPanel.SetActive(false);
        GameManager.Instance.GameOverEvent += ShowGameOver;
    }

    void Update()
    {
        scoreText.text = string.Format(scoreFormat, GameManager.Instance.Score);        
        livesText.text = string.Format(livesFormat, GameManager.Instance.LivesRemaining);        
    }

    void ShowGameOver(bool win)
    {
        if (win)
        {
            gameOverText.text = winText;
        }
        else 
        {
            gameOverText.text = loseText;
        }
        gameOverPanel.SetActive(true);
    }

    public void Restart()
    {
        // reload this scene
        SceneManager.LoadScene(0);
        gameOverPanel.SetActive(false);
    }
}
