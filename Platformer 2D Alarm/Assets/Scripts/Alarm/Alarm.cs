using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _targetAudio;
    [SerializeField] private Detection _detection;
    [SerializeField] private float _recoveryRate;

    private Coroutine _coroutine;

    private void OnEnable()
    {
        _detection.ChangedAction += OnChangedState;
    }

    private void OnDisable()
    {
        _detection.ChangedAction -= OnChangedState;
    }

    public void OnChangedState(float targetValue)
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }

        _coroutine = StartCoroutine(ChangeVolume(targetValue));
    }

    private IEnumerator ChangeVolume(float targetValue)
    {
        while (_targetAudio.volume != targetValue)
        {
            _targetAudio.volume = Mathf.MoveTowards(_targetAudio.volume, targetValue, _recoveryRate * Time.deltaTime);

            yield return null;
        }
    }
}