using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour{
    public float rotationSpeed = 10;

    void Start()    {
        
    }
    void Update()   {
        float Himp = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up,rotationSpeed * Himp * Time.deltaTime);

    }
}
