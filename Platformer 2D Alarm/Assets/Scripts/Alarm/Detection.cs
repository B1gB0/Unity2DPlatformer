using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class Detection : MonoBehaviour
{
    private readonly float _minValue = 0f;
    private readonly float _maxValue = 1f;

    public UnityAction <float> ChangedAction;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            ChangedAction?.Invoke(_maxValue);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            ChangedAction?.Invoke(_minValue);
        }
    }
}