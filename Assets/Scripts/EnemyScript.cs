using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour{

    private GameObject player;
    private Rigidbody enemyRB;
    public float force = 10;
    private GameManager gm;
    void Start()    {
        player = GameObject.Find("Player");
        enemyRB = GetComponent<Rigidbody>();
         gm = GameObject.Find("GameManager").GetComponent<GameManager>();
      }
    
    void Update()    {
        if(gm.Playing){
            Vector3 vectDist = (player.transform.position - transform.position).normalized;
            enemyRB.AddForce(vectDist * force);
        }
    }
}
