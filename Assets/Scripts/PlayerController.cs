using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour{

    private Rigidbody playerRb;
    public float Force = 2;
    private GameObject focal;
    public bool hasPowerUp = false;
    public GameObject VFXPowerup ; 
    void Start()   {
        playerRb = GetComponent<Rigidbody>();
        focal = GameObject.Find("FocalPoint");
    }

    void Update()    {
        float Vimp = Input.GetAxis("Vertical");
        float vhor = Input.GetAxis("Horizontal");
        Vector3 director = (Vector3.forward * Vimp - Vector3.left * vhor);
        playerRb.AddForce(director * Force * Time.deltaTime ,ForceMode.Impulse);
    }

    void OnTriggerEnter( Collider other ){
        if (hasPowerUp) {
            return;
        }

        if ( other.CompareTag("PowerUpBig")){
            hasPowerUp = true;
            Destroy( other.gameObject );
            GameObject VFX = Instantiate(VFXPowerup,transform.position,VFXPowerup.transform.rotation);
            gameObject.transform.localScale  *= 2;
        }
        if ( other.CompareTag("PowerUpSpeed")){
            hasPowerUp = true;
            Destroy( other.gameObject );
            GameObject VFX = Instantiate(VFXPowerup,transform.position,VFXPowerup.transform.rotation);
            Force  *= 1.5f;
        }
        if ( other.CompareTag("PowerUpForce")){
            hasPowerUp = true;
            Destroy( other.gameObject );
            GameObject VFX = Instantiate(VFXPowerup,transform.position,VFXPowerup.transform.rotation);
            Force  *= 1.5f;
        }

    }

    void OnCollisionEnter (Collision other){
        if (other.gameObject.CompareTag("Enemy")) {
            Rigidbody enemyRb= other.gameObject.GetComponent<Rigidbody>();
            Vector3 dir = (other.transform.position - transform.position);
            enemyRb.AddForce(dir.normalized * 10 , ForceMode.Impulse);
        }



    }
}
