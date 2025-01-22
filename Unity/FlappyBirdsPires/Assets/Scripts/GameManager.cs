using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // Singleton instance of the GameManager

    [SerializeField] private GameObject _gameOverMenu; // Reference to the Game Over menu UI

    private void Awake()
    {
        // Ensure only one instance of GameManager exists
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

        // Initialize game time
        Time.timeScale = 1.0f;
    }

    // Handle game over condition
    public void GameOver()
    {
        // Activate the Game Over menu UI
        _gameOverMenu.SetActive(true);

        // Pause the game
        Time.timeScale = 0f;
    }

    // Restart the current level
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // Load the main menu scene
    public void Menu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}