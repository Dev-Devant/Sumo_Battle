using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour{

    private Rigidbody playerRb;
    public float Force = 2;
    private float contactForce = 15;
    private GameObject focal;
    public bool hasPowerUp = false;
    public GameObject VFXPowerup ; 

    public GameObject[] indicators;

    private Vector3 initSize ;
    private float initForce ;
    private float initContactForce ;

    void Start()   {
        playerRb = GetComponent<Rigidbody>();
        focal = GameObject.Find("FocalPoint");
        initSize = transform.localScale;
        initForce = Force;
        initContactForce = contactForce;
    }

    void Update()    {
        float Vimp = Input.GetAxis("Vertical");
        float vhor = Input.GetAxis("Horizontal");
        Vector3 director = (Vector3.forward * Vimp - Vector3.left * vhor);
        playerRb.AddForce(director * Force * Time.deltaTime ,ForceMode.Impulse);
    }

    void OnTriggerEnter( Collider other ){
        bool madeBig    =  other.CompareTag("PowerUpBig");
        bool madeFast   =  other.CompareTag("PowerUpSpeed");
        bool madeStrong =  other.CompareTag("PowerUpForce");

        bool isAPowerup =  madeBig || madeFast || madeStrong ;

        if ( isAPowerup && !hasPowerUp){
            hasPowerUp = true;
            Destroy( other.gameObject );
            Instantiate(VFXPowerup,transform.position,VFXPowerup.transform.rotation);
            if ( madeBig ){
                gameObject.transform.localScale  *= 2;
                indicators[0].GetComponent<Indicator>().activate = true;
            }
            if ( madeFast ){
                Force  *= 1.5f;
            }
            if ( madeStrong ){
                contactForce  *= 5.0f;
            }        
            StartCoroutine(wait(10));
        }        

    }

    void OnCollisionEnter (Collision other){
        if (other.gameObject.CompareTag("NPC")) {
            Rigidbody enemyRb= other.gameObject.GetComponent<Rigidbody>();
            Vector3 dir = (other.transform.position - transform.position).normalized;
            enemyRb.AddForce(dir * contactForce , ForceMode.Impulse);
        }
    }

    IEnumerator wait(float timer){
        yield return new WaitForSeconds(timer);
        hasPowerUp = false;
        transform.localScale = initSize;
        Force = initForce;
        contactForce = initContactForce;
        indicators[0].GetComponent<Indicator>().activate = false;
    }

}
