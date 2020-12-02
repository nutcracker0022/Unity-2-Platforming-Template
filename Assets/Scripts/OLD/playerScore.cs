using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class playerScore : MonoBehaviour
{
    [SerializeField]
    private int score = 0;
    [SerializeField]
    private TextMeshProUGUI scoreText;

    private void Start()
    {
        if (scoreText == null)
        {
            scoreText = GameObject.Find("ScoreText").GetComponent<TextMeshProUGUI>();
        }
        scoreText.text = "Score: " + score.ToString();
    }

    public int GetScore()
    {
        return score;
    }

    public void SetScore(int newHealth)
    {
        score = newHealth;
        scoreText.text = "Score: " + score.ToString();
    }

    public void UpdateScore(int value)
    {
        score += value;
        scoreText.text = "Score: " + score.ToString();
    }
}
