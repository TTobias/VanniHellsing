using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_Control : MonoBehaviour
{

    public PlayerControl pc;

    
    public TextMeshProUGUI score;
    public TextMeshProUGUI WoodCount;
    public TextMeshProUGUI BoltCount;
    
    public int arrow = 3;
    public int maxArrows = 3;
    public Image[] arrows;
    public Sprite leftArrow;
    public Sprite rightArrow;
    public Sprite downArrow;
    public Sprite upArrow;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
        //resources.text = "Sticks: "+pc.sticks+"\nBolts: "+pc.bolts;
        for (int i = 0; i < arrows.Length; i++)
        {
            arrows[i].sprite = toDirection(pc.carveDirections[i]);
        }
        //Score
        score.text = pc.score +"";
        WoodCount.text = ": "+pc.sticks;
        BoltCount.text = ": " + pc.bolts;
    }
    Sprite toDirection(int dir){
        switch (dir)
        {
            case(0): return upArrow ;
            case(1): return rightArrow;
            case(2): return leftArrow;
            case(3): return downArrow;
            default: return rightArrow;
        }
    }
}
