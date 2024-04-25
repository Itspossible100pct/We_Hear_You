using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerButtonTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Animator _armAnimatorController;
    

    private void OnTriggerEnter(Collider other)
    {
        
            _armAnimatorController.SetBool("TurntableSwitchedOn", true);
        
        
    }
}
