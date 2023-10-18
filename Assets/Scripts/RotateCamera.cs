using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    public float speedRotation;

    void Start()
    {
        
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        this.transform.Rotate(Vector3.up, speedRotation * horizontalInput * Time.deltaTime);
    }
}
