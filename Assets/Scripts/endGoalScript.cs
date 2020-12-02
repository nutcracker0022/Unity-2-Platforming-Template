using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGoalScript : MonoBehaviour
{
    public UnityEngine.Events.UnityEvent OnPlayerFinish;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            OnPlayerFinish?.Invoke();
        }
    }
}
