using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPush : MonoBehaviour
{
    [SerializeField] private Animator _buttonAnimatorController;
    [SerializeField] private Animator _armAnimatorController;
    [SerializeField] private GameObject _vinyl;
    
    // void OnCollisionEnter (Collision col) 
    // {
    //     if (col.gameObject.CompareTag("Player"))
    //     {
    //         Debug.Log("Button pushed");
    //         _buttonAnimatorController.SetBool("IsPushed", true);
    //     }
    //     
    // }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Button pushed");
            //_buttonAnimatorController.SetBool("IsPushed", true);
            _buttonAnimatorController.enabled = true;
            StartCoroutine(ButtonTriggered());
            
        }
    }

    private IEnumerator ButtonTriggered()
    {
        yield return new WaitForSeconds(1);
        _armAnimatorController.enabled = true;
        yield return new WaitForSeconds(2);
        _vinyl.GetComponent<TurntableController>().enabled = true;
        _buttonAnimatorController.enabled = false;
    }
    
    
}
