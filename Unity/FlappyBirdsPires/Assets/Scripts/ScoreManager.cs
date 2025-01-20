using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    [SerializeField] TextMeshProUGUI _currentScore;
    [SerializeField] TextMeshProUGUI _bestScore;

    private int score;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        _currentScore.text = score.ToString();

        _bestScore.text = PlayerPrefs.GetInt("HighScore",0).ToString();
        UpdateHighScore();
    }

    private void UpdateHighScore()
    {
        if(score > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", score);
            _bestScore.text = score.ToString();
        }
        
    }
    public void UpdateScore()
    {
        score++;
        _currentScore.text = score.ToString();
        UpdateHighScore();
    }
}
