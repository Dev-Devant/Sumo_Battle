using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour{

    public float spawningArea = 9;
    public int ronda = 1;    
    public bool Playing = true;
    public int restantes = 1;

    void Start()    {
        Application.targetFrameRate = 60;
        
    }

    void Update()    {
        
    }
}
