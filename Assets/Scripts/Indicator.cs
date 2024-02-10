using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Indicator : MonoBehaviour{

    private GameObject player;
    public bool activate = false;
    void Start()   {
        player = GameObject.Find("Player");
    }

    void Update()  {
        if (activate){
            transform.position = player.transform.position + Vector3.up * 2;
        }else{
            transform.position = new Vector3(0,20,20);
        }        
    }
}
