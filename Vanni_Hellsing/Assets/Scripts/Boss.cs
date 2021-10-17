using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Boss : MonoBehaviour
{
    public int hp = 10, hpMax = 10;
    public int phase = 1;
    float currentAttackTimer;
    public float timer_min;
    public float timer_max;

    
    //public TextMeshProUGUI textMesh;
    public Image bossIcon;
    public Image bossbar;
    public Image bossbarBg;



    void Start()
    {
        currentAttackTimer = Random.Range(timer_min, timer_max);
        hp = hpMax;
    }


    void FixedUpdate()
    {
        //textMesh.text = "Boss: " + hp;
        bossbar.fillAmount = (float)hp / (float)hpMax;

        if (currentAttackTimer < 0)
        {
            currentAttackTimer = Random.Range(timer_min, timer_max);

            switch (phase)
            {
                case 1:
                    currentAttackTimer = Random.Range(5, 10);
                    break;
                case 2:
                    currentAttackTimer = Random.Range(5, 10);
                    break;
                case 3:
                    currentAttackTimer = Random.Range(5, 10);
                    break;

                default:
                    break;
            }
        }
        else
        {
            currentAttackTimer -= Time.deltaTime;
        }
    }

    public void reduceHp()
    {
        hp -= 1;
        if (hp <= 0)
        {
            bossIcon.enabled = false;
            bossbar.enabled = false;
            bossbar.fillAmount = 1f;
            bossbarBg.enabled = false;
        }
    }
}
