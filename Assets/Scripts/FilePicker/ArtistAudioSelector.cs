using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Serialization;

public class ArtistAudioSelector : MonoBehaviour
{
    [SerializeField] AudioSource _targetAudioSource;

    private void Awake()
    {
        // Get the AudioSource component from the GameObject
        _targetAudioSource = GetComponent<AudioSource>();
    }
     
    public void OnAddAudioClicked()
    {
        PickAudio();
    }
    
    // Method to pick audio from the gallery
    public void PickAudio()
    {
        // Request permission and get audio paths from gallery
        NativeGallery.Permission permission = NativeGallery.GetAudiosFromGallery((paths) =>
        {
            if (paths != null && paths.Length > 0)
            {
                foreach (string path in paths)
                {
                    LoadMediaMultiple(path);
                }
            }
            else
            {
                Debug.Log("No audio files selected or permission denied.");
            }
        }, "Select an Audio", "audio/*");
    }
    
   
    // Load audio from the provided path
    private void LoadMediaMultiple(string path)
    {
        if (string.IsNullOrEmpty(path))
        {
            Debug.Log("No path provided or path is empty.");
        }
        else
        {
            LoadAudio(path); // Assuming LoadAudio method is corrected to handle the path
        }
    }

    // Method to load audio from a path
    private void LoadAudio(string path)
    {
        string pathUpdate = path;

        if (Application.isMobilePlatform)
        {
            pathUpdate = "file://" + path;
        }

        StartCoroutine(LoadAudioCoroutine(pathUpdate));
    }
    
    // Coroutine to handle web request for loading audio
    private IEnumerator LoadAudioCoroutine(string uri)
    {
        using (UnityWebRequest request = UnityWebRequestMultimedia.GetAudioClip(uri, AudioType.UNKNOWN))
        {
            ((DownloadHandlerAudioClip)request.downloadHandler).streamAudio = true;
            ((DownloadHandlerAudioClip)request.downloadHandler).compressed = true;

            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.Log("Error loading audio: " + request.error);
            }
            else
            {
                AudioClip audioClip = DownloadHandlerAudioClip.GetContent(request);
                Debug.Log("Audio loaded successfully.");

                // Assign the loaded audio clip to the external AudioSource
                if (_targetAudioSource != null)
                {
                    _targetAudioSource.clip = audioClip;

                    // Start coroutine to play audio after a delay
                    StartCoroutine(PlayAudioAfterDelay(3.0f, 0.5f));
                }
                else
                {
                    Debug.LogError("Target AudioSource is not assigned.");
                }
            }
        }
    }


    
    // Coroutine to play audio after a specified delay
    private IEnumerator PlayAudioAfterDelay(float delay, float volume)
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(delay);

        // Set the volume and play the audio
        if (_targetAudioSource != null)
        {
            _targetAudioSource.volume = volume;
            _targetAudioSource.Play();
        }
        else
        {
            Debug.LogError("Target AudioSource is not assigned.");
        }
    }
}
