using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Animator animator;
    Rigidbody[] allRidigbodies;
    CapsuleCollider capsuleCollider;

    public Waypoint Waypoint;

    private void Awake()
    {
        capsuleCollider = GetComponent<CapsuleCollider>();
        allRidigbodies = GetComponentsInChildren<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
    }

    public void Die()
    {
        Waypoint.RemoveFromList(this);
        animator.enabled = false;
        for (int i = 0; i < allRidigbodies.Length; i++)
        {
            allRidigbodies[i].isKinematic = false;
            capsuleCollider.enabled = false;
        }
    }

    
}
