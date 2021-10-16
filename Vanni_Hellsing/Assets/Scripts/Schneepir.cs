using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Schneepir : MonoBehaviour
{
    public GameObject snowball;
    public GameObject iceblock;
    public bool direction = true;
    public int hp;
    public TextMeshProUGUI textMesh;
    public Rigidbody body;
    public Vector3 speed = new Vector3(1, 0, 0);
    public int phase;
    float currentAttackTimer;
    public float timer_min;
    public float timer_max;
    // Start is called before the first frame update
    void Start()
    {
        hp = 10;
        body = GetComponent<Rigidbody>();
        phase = 1;
        currentAttackTimer = Random.Range(timer_min, timer_max);
    }

    // Update is called once per frame
    void Update()
    {
        textMesh.text = "Boss: " + hp;
        if (direction)
        {
            if(transform.position.x > 4)
            {
                direction = false;
            }
            body.MovePosition(transform.position + speed * Time.fixedDeltaTime);
        }
        else
        {
            if(transform.position.x < -4)
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
                            Instantiate(iceblock, new Vector3(transform.position.x, 1, 25), Quaternion.identity);
                            break;

                        case 1:
                            Instantiate(snowball, new Vector3(transform.position.x, 1, 25), Quaternion.identity);
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
                                Instantiate(iceblock, new Vector3(random5, 1, 25-random4), Quaternion.identity);
                                break;

                            case 1:
                                Instantiate(snowball, new Vector3(random5, 1, 25-random4), Quaternion.identity);
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
                                Instantiate(iceblock, new Vector3(i, 1, 25-random4), Quaternion.identity);
                                break;

                            case 1:
                                Instantiate(snowball, new Vector3(i, 1, 25-random4), Quaternion.identity);
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
        if (hp == 0)
        {

        }
        else if (hp <= 3)
        {
            phase = 3;
        }
        else if (hp <= 6)
        {
            phase = 2;
        }
    }
}
