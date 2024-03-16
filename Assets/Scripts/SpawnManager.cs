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

    private GameObject[] npcs ;
    private GameObject[] pow ;
    private string moveTag = "Player"; 
    private string killTag = "NPC";
    private GameObject player;
    private GuiScript guis ;
    private float auxiliarTimer = 0;
    private GameManager gm;
    void Start()   {       
        guis = GameObject.Find("Canvas").GetComponent<GuiScript>();
        player = GameObject.Find("Player");
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        resetNpcs();
        resetPlayer(player);
    }

    void Update(){
        if (!gm.Playing){
            auxiliarTimer += Time.deltaTime;
            if( auxiliarTimer > 5.0f && Input.anyKeyDown){
                gm.Playing = true;
                auxiliarTimer = 0.0f;
                resetNpcs();
                resetPlayer(player);
                guis.gameRestarter();
            }
        }
       
    }

    private Vector3 randomPointInCircle(){
        float x = Random.Range(-gm.spawningArea,gm.spawningArea);
        float z = Random.Range(-gm.spawningArea,gm.spawningArea);
        return new Vector3(x,0,z);
    }

    private GameObject spawneador(GameObject objeto){
        Vector3 pos = randomPointInCircle();
        GameObject generated = Instantiate(objeto,pos,objeto.transform.rotation);
        return generated;
    }
    private void OnCollisionEnter(Collision ball){
        if(!gm.Playing){
            return;
        }
        if(ball.gameObject.CompareTag(killTag)){
            Destroy(ball.gameObject);
            
            gm.restantes = npcs.Length -1;
            for(int i = 0; i < npcs.Length;i ++){
                if ( npcs[i] == null ) {
                    gm.restantes -= 1;
                }
            }

            if ( gm.restantes == 0){
                gm.ronda += 1; 
                
                npcs = new GameObject[gm.ronda];
                for (int i = 0; i< gm.ronda; i++){
                    int add = 0;
                    if(gm.ronda > 7){
                        add += 1;
                        if(gm.ronda > 10){
                            add += 1;
                        }
                    }
                    int index = Random.Range(0,enemy.Length - 2 + add);
                    npcs[i] =  spawneador(enemy[index]);
                }
                if(gm.ronda >= 5){
                    int maxPower = Mathf.FloorToInt(gm.ronda/2 - 2);
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
                gm.restantes = npcs.Length;
            }
        }
        if(ball.gameObject.CompareTag(moveTag)  ){
            resetPlayer(ball.gameObject);
            guis.gameOverizer(); 
            gm.Playing = false;
        }
    }

    public void resetNpcs(){
        int index = Random.Range(0,enemy.Length - 3);
        gm.ronda = 1;
        
        if(npcs != null){
            for (int i = 0; i < npcs.Length ;i++ ){
                if(npcs[i] == null){
                    continue;
                }
                Destroy(npcs[i]);
            }
        }
        
        npcs = new GameObject[gm.ronda];
        GameObject generated = spawneador(enemy[index]);
        npcs[0] = generated;
        pow = new GameObject[1];
    }
    public void resetPlayer(GameObject ball){
        ball.transform.position = randomPointInCircle();
        PlayerController pc = ball.GetComponent<PlayerController>();
        pc.resetPowerUp();
        for (int i= 0 ; i < pc.indicators.Length;i++){
            Indicator ind = pc.indicators[i].GetComponent<Indicator>();
            ind.activate = false;
        }

    }

}
