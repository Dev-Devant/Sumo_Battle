using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GuiScript : MonoBehaviour{

    public TMP_Text guiRondas;
    public TMP_Text guiEnemys;
    public TMP_Text guiPowers;
    public GameObject gameOver;
    private PlayerController pc;
    private GameManager gm;
    void Start()    {
        pc = GameObject.Find("Player").GetComponent<PlayerController>();
        gameOver.SetActive(false);
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();

    }

    void Update()    {
        guiRondas.text = "Rondas: " + gm.ronda;
        guiEnemys.text = "Quedan: " + gm.restantes;
        guiPowers.text = "" + pc.PowerName;
    }

    public void gameOverizer(){
        gameOver.SetActive(true);
    }
    public void gameRestarter(){
        gameOver.SetActive(false);
    }
}
