using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    public int ronda = 1;
    public int restantes = 1;
    private GameObject[] npcs ;
    private GameObject[] pow ;
    private string moveTag = "Player"; 
    private string killTag = "NPC";
    void Start()   {
        int index = Random.Range(0,enemy.Length);
        npcs = new GameObject[ronda];
        GameObject generated = spawneador(enemy[index]);
        npcs[0] = generated;
        pow = new GameObject[1];
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
            
            restantes = npcs.Length -1;
            for(int i = 0; i < npcs.Length;i ++){
                if ( npcs[i] == null ) {
                    restantes -= 1;
                }
            }

            if ( restantes == 0){
                ronda += 1; 
                
                npcs = new GameObject[ronda];
                for (int i = 0; i< ronda; i++){
                    int index = Random.Range(0,enemy.Length);
                    npcs[i] =  spawneador(enemy[index]);
                }
                if(ronda >= 4){
                    int maxPower = Mathf.FloorToInt(ronda/2 - 2);
                    for (int i = 0; i< pow.Length; i++){
                        if(pow[i] != null){
                            Destroy(pow[i]);
                        }                        
                    }
                    pow = new GameObject[maxPower];
                    for (int i = 0; i< maxPower; i++){
                        int index = Random.Range(0,powers.Length);
                        pow[i] = spawneador(powers[index]);                
                    }
                }
                restantes = npcs.Length;
            }
        }
        if(ball.gameObject.CompareTag(moveTag)){
            ball.gameObject.transform.position = randomPointInCircle();
            PlayerController pc = ball.gameObject.GetComponent<PlayerController>();
            pc.resetPowerUp();
            for (int i= 0 ; i < pc.indicators.Length;i++){
                Indicator ind = pc.indicators[i].GetComponent<Indicator>();
                ind.activate = false;
            }
        }
    }


}
