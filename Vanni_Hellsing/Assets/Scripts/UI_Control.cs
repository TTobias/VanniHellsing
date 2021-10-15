using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Control : MonoBehaviour
{

    public PlayerControl pc;

    public Text health;
    public Text score;
    public Text resources;
    public Text arrows;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        health.text = "Health: "+pc.health;
        score.text = "Score: "+pc.score;
        resources.text = "Sticks: "+pc.sticks+"\nBolts: "+pc.bolts;
        arrows.text = toDirection(pc.carveDirections[0]) + toDirection(pc.carveDirections[1]) + toDirection(pc.carveDirections[2]);
    }


    string toDirection(int dir){
        switch (dir)
        {
            case(0): return "Up ";
            case(1): return "Right ";
            case(2): return "Left ";
            case(3): return "Down ";
            default: return " ";
        }
    }
}
