using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _targetAudio;
    [SerializeField] private float _requiredVolume;
    [SerializeField] private float _recoveryRate;

    public void IncreaseVolume()
    {
        _targetAudio.volume = Mathf.MoveTowards(_targetAudio.volume, _requiredVolume, _recoveryRate * Time.deltaTime);
    }

    public void StartReduceVolume()
    {
        StartCoroutine(ReduceVolume());
    }

    private IEnumerator ReduceVolume()
    {
        while(_targetAudio.volume > 0)
        {
            _targetAudio.volume = Mathf.MoveTowards(_targetAudio.volume, _requiredVolume, -_recoveryRate * Time.deltaTime);

            yield return null;
        }
    }
}