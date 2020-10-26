using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerManager : MonoBehaviour
{
    // Player specific components
    [SerializeField]
    private playerHealth healthComponent;
    [SerializeField]
    private playerScore scoreComponent;

    // Boolean values
    private bool isGamePaused = false;

    // UI stuff
    public GameObject pauseMenu;
    public GameObject winMenu;
    public GameObject loseMenu;

    // Keycodes
    public KeyCode useKey = KeyCode.E;
    public KeyCode swapKey = KeyCode.I;

    void Start()
    {
        // Makes sure game is "unpaused"
        isGamePaused = false;
        Time.timeScale = 1.0f;

        // Make sure all components and menus are filled in
        CheckPlayerComponents();
        FindAllMenus();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
        if (healthComponent.GetHealth() <= 0)
        {
            LoseGame();
        }
        if (Input.GetKeyDown(useKey))
        {

        }
        if (Input.GetKeyDown(swapKey))
        {

        }
    }

    void CheckPlayerComponents()
    {
        if (healthComponent == null)
        {
            healthComponent = GameObject.Find("PlayerInfo").GetComponent<playerHealth>();
        }
        if (scoreComponent == null)
        {
            scoreComponent = GameObject.Find("PlayerInfo").GetComponent<playerScore>();
        }
    }

   void FindAllMenus()
    {
        if (winMenu == null)
        {
            winMenu = GameObject.Find("WinGameMenu");
            winMenu.SetActive(false);
        }
        if (loseMenu == null)
        {
            loseMenu = GameObject.Find("LoseGameMenu");
            loseMenu.SetActive(false);
        }
        if (pauseMenu == null)
        {
            pauseMenu = GameObject.Find("PauseGameMenu");
            pauseMenu.SetActive(false);
        }
    }

    public void WinGame()
    {
        Time.timeScale = 0.0f;
        winMenu.SetActive(true);
    }

    public void LoseGame()
    {
        Time.timeScale = 0.0f;
        loseMenu.SetActive(true);
    }

    public void PauseGame()
    {
        if (isGamePaused)
        {
            // Unpause game
            Time.timeScale = 1.0f;
            pauseMenu.SetActive(false);
            isGamePaused = false;
        }
        else
        {
            // Pause game
            Time.timeScale = 0.0f;
            pauseMenu.SetActive(true);
            isGamePaused = true;
        }
    }

    public void ChangeHealth(int value)
    {
        healthComponent.UpdateHealth(value);
    }

    public void ChangeScore(int value)
    {
        scoreComponent.UpdateScore(value);
    }

}
