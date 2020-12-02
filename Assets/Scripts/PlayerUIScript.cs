using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerUIScript : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI healthText;
    [SerializeField]
    private TextMeshProUGUI scoreText;
    [SerializeField]
    private TextMeshProUGUI inventoryText;

    private void Awake()
    {
        FindAllText();
    }

    void FindAllText()
    {
        if (healthText == null)
        {
            healthText = GameObject.Find("HealthText").GetComponent<TextMeshProUGUI>();
        }
        if (scoreText == null)
        {
            scoreText = GameObject.Find("ScoreText").GetComponent<TextMeshProUGUI>();
        }
        if (inventoryText == null)
        {
            inventoryText = GameObject.Find("InventoryText").GetComponent<TextMeshProUGUI>();
        }
    }

    private void OnEnable()
    {
        GetComponent<PlayerManagerScript>().OnHealthChange.AddListener(UpdateHealthUI);
        GetComponent<PlayerManagerScript>().OnScoreChange.AddListener(UpdateScoreUI);
    }

    private void OnDisable()
    {
        GetComponent<PlayerManagerScript>().OnHealthChange.RemoveListener(UpdateHealthUI);
        GetComponent<PlayerManagerScript>().OnScoreChange.RemoveListener(UpdateScoreUI);
    }

    public void UpdateHealthUI(int health)
    {
        healthText.text = "Health: " + health.ToString();
    }

    public void UpdateScoreUI(int score)
    {
        scoreText.text = "Score: " + score.ToString();
    }

}
