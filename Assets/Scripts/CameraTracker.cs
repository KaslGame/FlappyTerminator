using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTracker : MonoBehaviour
{
    [SerializeField] private Transform _plane;
    [SerializeField] private float _xOffest;

    private void Update()
    {
        transform.position = new Vector3(_plane.position.x - _xOffest, transform.position.y, transform.position.z);
    }
}
