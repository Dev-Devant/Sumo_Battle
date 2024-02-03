using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour{

    public GameObject[] enemy;
    public float spawningArea = 9;

    void Start()    {
       spawneador();
    }

    void Update(){
    }

    private GameObject spawneador(){
        int index = Random.Range(0,enemy.Length);
        float x = Random.Range(-spawningArea,spawningArea);
        float z = Random.Range(-spawningArea,spawningArea);
        GameObject generated = Instantiate(enemy[index],new Vector3(x,0,z),enemy[index].transform.rotation);
        return generated;
    }



}
