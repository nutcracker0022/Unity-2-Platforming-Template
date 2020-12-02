using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class playerInventory : MonoBehaviour
{
    public List<bool> inventory = new List<bool>();
    public int currentIndex;

    public TextMeshProUGUI inventoryText;

    private void Start()
    {
        if (inventoryText == null)
        {
            inventoryText = GameObject.Find("InventoryText").GetComponent<TextMeshProUGUI>();
        }
        UpdateUI();
    }

    public void UpdateUI()
    {
        if (inventory.Count == 0)
        {
            inventoryText.text = "Inventory: None";
        }
        else
        {
            // Display current item in inventory
        }
    }

    public void SwapInventory(int direction)
    {
        if (inventory.Count != 0)
        {
            currentIndex = (currentIndex + direction) % inventory.Count;
        }
        else
        {
            currentIndex = 0;
        }
        UpdateUI();
    }

    public void UseInventory()
    {
        if (inventory.Count > 0)
        {
            // Use Item here
            inventory.RemoveAt(currentIndex);
            SwapInventory(-1);
        }
    }
}
