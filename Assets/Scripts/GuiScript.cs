using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GuiScript : MonoBehaviour{

    public TMP_Text guiRondas;
    public TMP_Text guiEnemys;
    public TMP_Text guiPowers;
    public GameObject gameOver;
    private SpawnManager spwManager;
    private PlayerController pc;

    void Start()    {
        spwManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();     
        pc = GameObject.Find("Player").GetComponent<PlayerController>();
        gameOver.SetActive(false);
    }

    void Update()    {
        guiRondas.text = "Rondas: " + spwManager.ronda;
        guiEnemys.text = "Quedan: " + spwManager.restantes;
        guiPowers.text = "" + pc.PowerName;
    }

    public void gameOverizer(){
        gameOver.SetActive(true);
    }
    public void gameRestarter(){
        gameOver.SetActive(false);
    }
}