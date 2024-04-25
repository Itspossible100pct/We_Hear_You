using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmSwivel : MonoBehaviour
{
    [SerializeField] private Transform _recordCenter;
    [SerializeField] private float speed = 1.0f;
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private VinylPlaybackManager _vinylPlaybackManager; // Correct reference to the VinylPlaybackManager script
    private bool _isMovingToLimit = false;

    void OnTriggerStay(Collider other)
    {
        // Check if the collider is the vinyl
        if (other.gameObject.CompareTag("Vinyl") && _vinylPlaybackManager.IsSongFinished() && !_isMovingToLimit)
        {
            //StartCoroutine(MoveToLimitAfterDelay(3.0f)); // 3 seconds delay
            Debug.Log("move to limit after delay here");
        }
    }

    private IEnumerator MoveToLimitAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        _isMovingToLimit = true;
        //MoveArmToHingeLimit();
    }

    private void MoveArmToHingeLimit()
    {
        Vector3 direction = (_recordCenter.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        Quaternion limitedRotation = Quaternion.RotateTowards(transform.rotation, lookRotation, 66.75426f); // Use the hinge limit here

        _rb.MoveRotation(Quaternion.Slerp(transform.rotation, limitedRotation, Time.deltaTime * speed));
    }
}