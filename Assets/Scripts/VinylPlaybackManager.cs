using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VinylPlaybackManager : MonoBehaviour
{
    
    
    
    [SerializeField] private AudioSource _audioSource;

    [SerializeField] private AudioClip _digitalSongVersion;
    [SerializeField] private AudioClip _vinylSongVersion;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.CompareTag("Needle"))
        {
            Debug.Log("Collision happened");
            _audioSource.clip = _vinylSongVersion;
            _audioSource.Play();
        }
        
    }

    public bool IsSongFinished()
    {
        return !_audioSource.isPlaying;
    }
    
}
