using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public class ParamCube : MonoBehaviour
{
    public int _band;
    public float _startScale, _maxScale;
    public bool _useBuffer;
    private Material _material;
    
    // Start is called before the first frame update
    void Start()
    {
        _material = GetComponent<MeshRenderer>().materials[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (_useBuffer)
        {
            transform.localScale = new Vector3(transform.localScale.x,
                (AudioPeer._audioBandBuffer[_band] * _maxScale) + _startScale, transform.localScale.z);
            Color _color = new Color(AudioPeer._audioBandBuffer[_band], AudioPeer._audioBandBuffer[_band],
                AudioPeer._audioBandBuffer[_band]);
            _material.SetColor("EmissionColor", _color);

        }
        if (!_useBuffer)
        {
            transform.localScale = new Vector3(transform.localScale.x,
                (AudioPeer._audioBand[_band] * _maxScale) + _startScale, transform.localScale.z);
            Color _color = new Color(AudioPeer._audioBandBuffer[_band], AudioPeer._audioBandBuffer[_band],
                AudioPeer._audioBandBuffer[_band]);
            _material.SetColor("EmissionColor", _color);

        }
        
    }
}
