using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VinylPlaybackManager : MonoBehaviour
{
    [SerializeField] private GameObject _audioPeer;
    [SerializeField] private GameObject _multiSpawner;


    [SerializeField] private AudioSource _audioSource;

    [SerializeField] private AudioClip _digitalSongVersion;
    [SerializeField] private AudioClip _vinylSongVersion;

    private bool _isSongPlaying = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Needle"))
        {
            PlaySongAfterCrackle();
        }
    }

    public void PlaySongAfterCrackle()
    {
        if (!_isSongPlaying)
        {
            _isSongPlaying = true;
            StartCoroutine(PlaySongAfterDelay(2f));
            //_audioPeer.SetActive(true);
            //_multiSpawner.SetActive(true);
        }
    }

    public void StopSongOnNeedleLifted()
    {
        _audioSource.Stop();
    }

    public bool IsSongFinished()
    {
        return !_audioSource.isPlaying;
    }

    private IEnumerator PlaySongAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        _audioSource.clip = _vinylSongVersion;
        _audioSource.Play();
    }

    public void ResetPlayback()
    {
        _isSongPlaying = false;
    }
}
