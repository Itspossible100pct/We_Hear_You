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

    private void OnTriggerEnter(Collider other)
    {
        //if (other.CompareTag("Needle"))
        {
            Debug.Log("Entered for Needle");
       
            OnNeedleDrops();
            OnDelayAfterNeedle();
        }
    }

    private void OnTriggerExit(Collider other)
    {
       // if (other.CompareTag("Needle"))
        {
            Debug.Log("Exit for Needle");
            OnNeedleLifted();
        }
        
    }

    public void OnNeedleDrops()
    {
        _audioSource.PlayOneShot(_needleDrops[Random.Range(0, _needleDrops.Length)]);
    }

    public void OnDelayAfterNeedle()
    {
        StartCoroutine(PlayCrackleAfterDelay(0.5f));
        
    }

    public void OnNeedleLifted()
    {
        _audioSource.Stop();
        //_vinylPlaybackManager.StopSongOnNeedleLifted();
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
