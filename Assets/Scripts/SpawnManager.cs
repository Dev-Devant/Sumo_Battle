using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    recta de progresion enemigos:
    y = 0.5*ronda + 1
    recta de progracion powerups;
    solo si y > 0
    y = 0.5x -2
*/


public class SpawnManager : MonoBehaviour{

    public GameObject[] enemy;
    public GameObject[] powers;
    public float spawningArea = 9;
    private int ronda = 1;
    private GameObject[] npcs ;
    private string moveTag = "Player"; 
    private string killTag = "NPC";
    void Start()   {
        int index = Random.Range(0,enemy.Length);
        spawneador(enemy[index]);

    }

    void Update(){
    }

    private Vector3 randomPointInCircle(){
        float x = Random.Range(-spawningArea,spawningArea);
        float z = Random.Range(-spawningArea,spawningArea);
        return new Vector3(x,0,z);
    }

    private GameObject spawneador(GameObject objeto){
        Vector3 pos = randomPointInCircle();
        GameObject generated = Instantiate(objeto,pos,objeto.transform.rotation);
        return generated;
    }
    private void OnCollisionEnter(Collision ball){
        if(ball.gameObject.CompareTag(killTag)){
            Destroy(ball.gameObject);
            ronda += 1;
            for (int i = 0; i< ronda; i++){
                int index = Random.Range(0,enemy.Length);
                spawneador(enemy[index]);
            }
            if(ronda >= 4){
                for (int i = 0; i< 0.5 * ronda - 2; i++){
                    int index = Random.Range(0,powers.Length);
                    spawneador(powers[index]);                
                }
            }
        }
        if(ball.gameObject.CompareTag(moveTag)){
            ball.gameObject.transform.position = randomPointInCircle();
        }
    }


}
