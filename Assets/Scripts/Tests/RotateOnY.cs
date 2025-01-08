using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateOnY : MonoBehaviour
{
    public float rotationSpeed = 1f;

    void Start()
    {

    }

    void Update()
    {
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }
}
