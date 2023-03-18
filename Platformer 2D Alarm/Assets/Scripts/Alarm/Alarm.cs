using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class Alarm : MonoBehaviour
{
    [SerializeField] private float _requiredVolume;
    [SerializeField] private float _recoveryRate;
    [SerializeField] private AudioSource _targetAudio;

    private bool isExit;

    private void FixedUpdate()
    {
        if (isExit)
        {
            _targetAudio.volume = Mathf.MoveTowards(_targetAudio.volume, _requiredVolume, -_recoveryRate * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            isExit = false;
            _targetAudio.Play();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            _targetAudio.volume = Mathf.MoveTowards(_targetAudio.volume, _requiredVolume, _recoveryRate * Time.deltaTime);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            isExit = true;
        }
    }
}