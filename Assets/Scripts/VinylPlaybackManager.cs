using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VinylPlaybackManager : MonoBehaviour
{



    [SerializeField] private AudioSource _audioSource;

    [SerializeField] private AudioClip _digitalSongVersion;
    [SerializeField] private AudioClip _vinylSongVersion;



    public void OnWaitAfterCrackle()
    {
        StartCoroutine(PlaySongAfterDelay(2f));
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
}
