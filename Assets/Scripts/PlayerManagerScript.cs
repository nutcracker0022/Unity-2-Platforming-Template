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

    //Inventory Elements
    [SerializeField]
    private List<Collectable> inventory = new List<Collectable>();
    private int currentSelection = 0;
    public UnityEvent_Collectable OnInventoryAdd;
    public UnityEvent_Collectable OnInventoryChange;
    public UnityEvent_Int OnInventoryRemove;

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
        OnHealthChange?.Invoke(health);
        OnScoreChange?.Invoke(score);
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
        //====== Start of new Input check ======
        if (Input.GetKeyDown(useKey) && inventory.Count > 0)
        {
            inventory[currentSelection].Use();
            InventoryRemove(currentSelection);
        }
        if (Input.GetKeyDown(swapKey) && inventory.Count > 0)
        {
            currentSelection = (currentSelection + 1) % inventory.Count;
            //OnInventoryChange?.Invoke(inventory[currentSelection]);
        }
        //====== End of new Input check ======
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

    //====== Start of new Functions ======
    private void InventoryAdd(Collectable item)
    {
        item.player = this.gameObject;
        item.transform.parent = null;
        inventory.Add(item);
        item.gameObject.SetActive(false);
    }

    private void InventoryRemove(int index)
    {
        inventory.RemoveAt(index);
        if(inventory.Count > 0)
        {
            currentSelection = (currentSelection - 1) % inventory.Count;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Collectable item = collision.GetComponent<Collectable>();
        if (item != null)
        {
            InventoryAdd(item);
        }
    }
    //====== End of new Functions ======


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

[System.Serializable]
public class UnityEvent_Collectable: UnityEvent<Collectable>
{
}