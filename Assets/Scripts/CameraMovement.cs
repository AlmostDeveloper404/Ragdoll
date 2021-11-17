using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] Transform PlayerTransform;
    [SerializeField] Vector3 Offset;
    private void LateUpdate()
    {
        transform.position = PlayerTransform.position + Offset;
    }
}
