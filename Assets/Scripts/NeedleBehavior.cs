using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class NeedleBehavior : MonoBehaviour
{
    [SerializeField] private VinylPlaybackManager _vinylPlaybackManager; 

    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip[] _needleDrops;
    [SerializeField] private AudioClip _crackleSound;
    [SerializeField] private AudioClip _vinylEndLoop;
    
    // Start is called before the first frame update
    void Start()
    {
        if (_audioSource == null)
        {
            _audioSource = GetComponent<AudioSource>();
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Vinyl"))
        {
            _audioSource.PlayOneShot(_needleDrops[Random.Range(0, _needleDrops.Length)]);
        }
        
    }

    void OnCollisionStay()
    {
        StartCoroutine(PlayCrackleAfterDelay(1.0f));
        
    }

    private void OnCollisionExit(Collision other)
    {
        _audioSource.Stop();
    }

    private IEnumerator PlayCrackleAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        _audioSource.clip = _crackleSound;
        _audioSource.loop = true;
        _audioSource.Play();
        
        if(_vinylPlaybackManager.IsSongFinished() == true)
        {
            _audioSource.clip = _vinylEndLoop;
            _audioSource.Play();
        }
        
    }
    
}
