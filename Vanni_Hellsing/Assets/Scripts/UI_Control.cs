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
    public Sprite leftArrowA;
    public Sprite rightArrowA;
    public Sprite downArrowA;
    public Sprite upArrowA;


    public Image bossIcon;
    public Image bossBar;
    public Image bossBarBg;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (pc.sticks > 0 && pc.bolts < 5)
        {
            for (int i = 0; i < arrows.Length; i++)
            {
                arrows[i].enabled = true;
                arrows[i].sprite = toDirection(pc.carveDirections[i]);
            }
            for (int i = 0; i < pc.carvingProgress; i++)
            {
                arrows[i].sprite = toDirectionA(pc.carveDirections[i]);
            }
        }
        else
        {
            for (int i = 0; i < arrows.Length; i++)
            {
                arrows[i].enabled = false;
            }
        }
        
        
        //Score
        score.text = pc.getScore() + " ";
        WoodCount.text = ": " + pc.sticks;
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

    Sprite toDirectionA(int dir)
    {
        switch (dir)
        {
            case (0): return upArrowA;
            case (1): return rightArrowA;
            case (2): return leftArrowA;
            case (3): return downArrowA;
            default: return rightArrowA;
        }
    }
}
