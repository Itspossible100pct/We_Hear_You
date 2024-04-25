using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleOnAmplitude : MonoBehaviour
{
    public float _startScale, _maxScale;
    public bool _useBuffer;
    private Material _material;
    public float _red, _green, _blue;
    
    // Start is called before the first frame update
    void Start()
    {
        _material = GetComponent<MeshRenderer>().materials[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (!_useBuffer)
        {
            transform.localScale = new Vector3((AudioPeer.amplitude * _maxScale) + _startScale,
                (AudioPeer.amplitude * _maxScale) + _startScale, (AudioPeer.amplitude * _maxScale) + _startScale);
            Color _color = new Color(_red * AudioPeer.amplitude, _green * AudioPeer.amplitude,
                _blue * AudioPeer.amplitude);
            _material.SetColor("_EmissionColor", _color);
        }

        if (_useBuffer)
        {
            transform.localScale = new Vector3((AudioPeer.amplitudeBuffer * _maxScale) + _startScale,
                (AudioPeer.amplitudeBuffer * _maxScale) + _startScale, (AudioPeer.amplitudeBuffer * _maxScale) + _startScale);
            Color _color = new Color(_red * AudioPeer.amplitudeBuffer, _green * AudioPeer.amplitudeBuffer,
                _blue * AudioPeer.amplitudeBuffer);
            _material.SetColor("_EmissionColor", _color);
        }
    }
}
