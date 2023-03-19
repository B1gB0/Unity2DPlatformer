using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class Detection : MonoBehaviour
{
    [SerializeField] private UnityEvent _reached;
    [SerializeField] private UnityEvent _standing;
    [SerializeField] private UnityEvent _gone;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            _reached?.Invoke();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            _standing?.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            _gone?.Invoke();
        }
    }
}
