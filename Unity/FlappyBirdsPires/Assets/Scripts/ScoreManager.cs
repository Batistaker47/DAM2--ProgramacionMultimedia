using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance; // Singleton instance of the ScoreManager

    [SerializeField] private TextMeshProUGUI _currentScore; // UI element for displaying current score
    [SerializeField] private TextMeshProUGUI _bestScore; // UI element for displaying best score

    private int score; // Current score

    private void Awake()
    {
        // Ensure only one instance of ScoreManager exists
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // Initialize current score display
        _currentScore.text = score.ToString();

        // Load best score from PlayerPrefs
        _bestScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();

        // Check and update high score if necessary
        UpdateHighScore();
    }

    // Update the high score if the current score is higher
    private void UpdateHighScore()
    {
        if (score > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", score);
            _bestScore.text = score.ToString();
        }
    }

    // Increment the current score and update the display
    public void UpdateScore()
    {
        score++;
        _currentScore.text = score.ToString();
        UpdateHighScore();
    }
}
