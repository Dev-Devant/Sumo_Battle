using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour{

    private GameObject player;
    private Rigidbody enemyRB;
    public float force = 10;

    void Start()    {
        player = GameObject.Find("Player");
        enemyRB = GetComponent<Rigidbody>();
      }
    
    void Update()    {
        Vector3 vectDist = (player.transform.position - transform.position).normalized;

        enemyRB.AddForce(vectDist * force);

    }
}
