using UnityEngine;
using TMPro; 

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    private int currentScore = 0;

    void Start()
    {
        currentScore = 0;
        UpdateScoreUI();
    }

    public void AddScore(int amount)
    {
        currentScore += amount;
        UpdateScoreUI();
    }

    void UpdateScoreUI()
    {
        scoreText.text = "Score: " + currentScore.ToString();
    }
}