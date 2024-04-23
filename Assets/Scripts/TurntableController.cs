using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TurntableController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.DORotate(new Vector3(0.0f, 360.0f, 0.0f), 2.0f, RotateMode.FastBeyond360)
            .SetLoops(-1, LoopType.Restart)
            .SetRelative()
            .SetEase(Ease.Linear);
    }
   
}
