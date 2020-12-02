using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerManagerScript : MonoBehaviour
{
    // Player Values
    [SerializeField]
    private int health = 100;
    [SerializeField]
    private int score = 0;

    // Bool Values
    private bool isPaused = false;

    // Events
    public UnityEvent OnPauseToggle;
    public UnityEvent OnLoseGame;
    public UnityEvent_Int OnHealthChange;
    public UnityEvent_Int OnScoreChange;

    // Keycodes
    public KeyCode useKey = KeyCode.E;
    public KeyCode swapKey = KeyCode.I;

    void Awake()
    {
        isPaused = false;
        Time.timeScale = 1.0f;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        OnPauseToggle.AddListener(TogglePauseGame);
    }

    private void OnDisable()
    {
        OnPauseToggle.RemoveListener(TogglePauseGame);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OnPauseToggle?.Invoke();
        }
    }

    public void SetPlayerInfo(int newHealth, int newScore)
    {
        health = newHealth;
        score = newScore;
        OnHealthChange?.Invoke(newHealth);
        OnHealthChange?.Invoke(newScore);
    }

    public void ChangeHealth(int value)
    {
        health += value;
        OnHealthChange?.Invoke(health);
        if (health <= 0)
        {
            OnLoseGame?.Invoke();
        }
    }

    public void ChangeScore(int value)
    {
        score += value;
        OnScoreChange?.Invoke(score);
    }

    private void TogglePauseGame()
    {
        if (isPaused)
        {
            isPaused = false;
            Time.timeScale = 1.0f;
        }
        else
        {
            isPaused = true;
            Time.timeScale = 0.0f;
        }
    }

    private void OnDestroy()
    {
        OnPauseToggle.RemoveAllListeners();
        OnLoseGame.RemoveAllListeners();
        OnHealthChange.RemoveAllListeners();
        OnScoreChange.RemoveAllListeners();
    }
}


[System.Serializable]
public class UnityEvent_Int : UnityEvent<int>
{
}