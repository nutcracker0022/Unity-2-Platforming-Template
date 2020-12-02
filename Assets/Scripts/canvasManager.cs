using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class canvasManager : MonoBehaviour
{
    // UI
    public GameObject pauseMenu;
    public GameObject winMenu;
    public GameObject loseMenu;

    // References
    private PlayerManagerScript player;
    private EndGoalScript goal;

    void Awake()
    {
        FindAllMenus();
        FindRefences();
    }

    private void OnEnable()
    {
        player?.OnPauseToggle.AddListener(TogglePauseMenu);
        player?.OnLoseGame.AddListener(ShowLoseScreen);
        goal?.OnPlayerFinish.AddListener(ShowWinScreen);
    }

    private void OnDisable()
    {
        player?.OnPauseToggle.RemoveListener(TogglePauseMenu);
        player?.OnLoseGame.RemoveListener(ShowLoseScreen);
        goal?.OnPlayerFinish.RemoveListener(ShowWinScreen);
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

    void FindRefences()
    {
        if (player == null)
        {
            player = GameObject.FindWithTag("Player")?.GetComponent<PlayerManagerScript>();
        }
        if (goal == null)
        {
            goal = GameObject.FindWithTag("Finish")?.GetComponent<EndGoalScript>();
        }
    }

    public void TogglePauseMenu()
    {
        pauseMenu.SetActive(!pauseMenu.activeSelf);
    }

    public void ShowWinScreen()
    {
        Time.timeScale = 0.0f;
        winMenu.SetActive(true);
    }

    public void ShowLoseScreen()
    {
        Time.timeScale = 0.0f;
        loseMenu.SetActive(true);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }

    public void ResetLevel()
    {
        LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextLevel()
    {
        LoadScene((SceneManager.GetActiveScene().buildIndex+1)%SceneManager.sceneCountInBuildSettings);
    }

    public void LoadScene(int buildIndex)
    {
        SceneManager.LoadScene(buildIndex);
    }
}

