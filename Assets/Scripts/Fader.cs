using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class Fader : MonoBehaviour
{
    [SerializeField] [Range(0f, 5f)] private float _duration;

    private AudioSource _audioSource;
    private float _currentVolume;
    private Coroutine _fadeVolumeProcess; 

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void StartFadeIn()
    {
        _fadeVolumeProcess = StartCoroutine(Fade(_duration, 1f));
    }

    public void StartFadeOut()
    {
        _fadeVolumeProcess = StartCoroutine(Fade(_duration, 0f));
    }

    private IEnumerator Fade(float duration, float targetVolume)
    {
        if(_fadeVolumeProcess != null)
            StopCoroutine(_fadeVolumeProcess);

        _currentVolume = _audioSource.volume;

        float _deltaVolume = targetVolume - _currentVolume;

        if (_audioSource.volume == 0)
            _audioSource.Play();

        var waitForFixedUpdate = new WaitForFixedUpdate();

        while (_currentVolume != targetVolume)
        {
            _audioSource.volume += _deltaVolume * Time.fixedDeltaTime / duration;
            
            if (_audioSource.volume == 0)
                _audioSource.Stop();
            
            yield return waitForFixedUpdate;
        }
    }
}
