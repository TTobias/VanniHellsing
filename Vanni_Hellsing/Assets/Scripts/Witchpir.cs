using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Witchpir : MonoBehaviour
{
    public GameObject potion;
    public bool direction = true;
    public int hp = 15, hpMax = 15;
    public Rigidbody body;
    public Vector3 speed = new Vector3(2, 0, 0);
    public int phase = 1;
    float currentAttackTimer;
    public float timer_min;
    public float timer_max;


    //public TextMeshProUGUI textMesh;
    public Image bossIcon;
    public Image bossbar;
    public Image bossbarBg;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
        currentAttackTimer = Random.Range(timer_min, timer_max);
        hp = hpMax;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        bossbar.fillAmount = (float)hp / (float)hpMax;

        if (direction)
        {
            if (transform.position.x > 4)
            {
                direction = false;
            }
            body.MovePosition(transform.position + speed * Time.fixedDeltaTime);
        }
        else
        {
            if (transform.position.x < -4)
            {
                direction = true;
            }
            body.MovePosition(transform.position - speed * Time.fixedDeltaTime);
        }
        if (currentAttackTimer < 0)
        {
            currentAttackTimer = Random.Range(timer_min, timer_max);

            switch (phase)
            {
                case 1:
                    int random = Random.Range(0, 2);
                    Debug.Log(random);
                    switch (random)
                    {
                        case 0:
                            Instantiate(potion, new Vector3(transform.position.x, 1, 23), Quaternion.identity);
                            //StartCoroutine(nameof(attack));
                            break;

                        case 1:
                            Instantiate(potion, new Vector3(transform.position.x, 1, 23), Quaternion.identity);
                            break;

                        default:
                            break;
                    }
                    break;
                case 2:
                    for (int i = 0; i < 2; i++)
                    {
                        int random2 = Random.Range(0, 2);
                        int random4 = Random.Range(0, 10);
                        int random5 = Random.Range(-4, 5);
                        switch (random2)
                        {
                            case 0:
                                Instantiate(potion, new Vector3(transform.position.x, 1, 23), Quaternion.identity);
                                break;

                            case 1:
                                Instantiate(potion, new Vector3(transform.position.x, 1, 23), Quaternion.identity);
                                break;

                            default:
                                break;
                        }
                    }
                    break;
                case 3:
                    for (int i = -4; i < 4; i = i + 2)
                    {
                        int random2 = Random.Range(0, 2);
                        int random4 = Random.Range(0, 10);
                        switch (random2)
                        {
                            case 0:
                                Instantiate(potion, new Vector3(transform.position.x, 1, 23), Quaternion.identity);
                                break;

                            case 1:
                                Instantiate(potion, new Vector3(transform.position.x, 1, 23), Quaternion.identity);
                                break;

                            default:
                                break;
                        }
                    }
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

            WorldMovement.stage = 3;
            BossPreperation.CanSpawn = true;

            Destroy(this.gameObject);
        }
        else if (hp <= 5)
        {
            phase = 3;
        }
        else if (hp <= 10)
        {
            phase = 2;
        }
    }

    IEnumerator attack()
    {
        yield return new WaitForSeconds(2.0f);
        Debug.Log("attack");

    }
}
