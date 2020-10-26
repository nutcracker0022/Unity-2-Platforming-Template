using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class playerHealth : MonoBehaviour
{
    [SerializeField]
    private int health = 100;
    [SerializeField]
    private TextMeshProUGUI healthText;

    private void Start()
    {
        if (healthText == null)
        {
            healthText = GameObject.Find("HealthText").GetComponent<TextMeshProUGUI>();
        }
        healthText.text = "Health: " + health.ToString();
    }

    public int GetHealth()
    {
        return health;
    }

    public void SetHealth(int newHealth)
    {
        health = newHealth;
        healthText.text = "Health: " + health.ToString();
    }

    public void UpdateHealth(int value)
    {
        health += value;
        healthText.text = "Health: " + health.ToString();
    }
}
