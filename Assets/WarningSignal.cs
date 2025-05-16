using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class WarningSignal : MonoBehaviour
{
    private AudioSource _audioSource;
    private float _volumeStep = 0.1f;
    private float _minVolumeValue = 0f;
    private float _maxVolumeValue = 1f;
    private float _delay = 1f;
    private Coroutine _coroutine;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = 0.1f;
    }

    public void EnableSignal()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }

        _audioSource.Play();
        _coroutine = StartCoroutine(IncreaseVolume());
    }

    public void DisableSignal()
    {

        StopCoroutine(_coroutine);
        _coroutine = StartCoroutine(DecreaseVolume());

    }

    private IEnumerator DecreaseVolume()
    {
        var wait = new WaitForSeconds(_delay);

        while (_audioSource.isPlaying && _audioSource.volume > _minVolumeValue)
        {
            _audioSource.volume -= _volumeStep;
            yield return wait;
        }

        _audioSource.Stop();
    }

    private IEnumerator IncreaseVolume()
    {
        var wait = new WaitForSeconds(_delay);

        while (_audioSource.isPlaying && _audioSource.volume < _maxVolumeValue)
        {
            _audioSource.volume += _volumeStep;
            yield return wait;
        }
    }
}
