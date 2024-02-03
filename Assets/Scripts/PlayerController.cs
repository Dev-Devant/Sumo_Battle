using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour{

    private Rigidbody playerRb;
    public float Force = 2;
    private GameObject focal;
    void Start()   {
        playerRb = GetComponent<Rigidbody>();
        focal = GameObject.Find("FocalPoint");
    }

    void Update()    {
        float Vimp = Input.GetAxis("Vertical");
        float vhor = Input.GetAxis("Horizontal");
        Vector3 director = (Vector3.forward * Vimp + Vector3.left * vhor).normalized;

        playerRb.AddForce(director * Force * Vimp,ForceMode.Force);

    }
}
