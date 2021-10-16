using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vampire : MonoBehaviour
{
    public Rigidbody body;
    public float timer_min;
    public float timer_max;
    float currentAttackTimer;
    public Vector3 speed = new Vector3(0, 0, -4);
    public Vector3 right = new Vector3(1, 0, 0);
    public Vector3 left = new Vector3(-1, 0, 0);
    public GameObject bat;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
        currentAttackTimer = Random.Range(timer_min, timer_max);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > 20)
        {
            body.MovePosition(transform.position + speed * Time.fixedDeltaTime);
        } else if (currentAttackTimer < 0)
        {
            int random = Random.Range(0, 3);
            Debug.Log(random);
            switch (random)
            {
                case 0:
                    //Summon bat
                    Instantiate(bat, new Vector3(transform.position.x, 1, 29), Quaternion.identity);
                    break;

                case 1:
                    //Move Left
                    if(transform.position.x > -4)
                    {
                        body.MovePosition(transform.position + left);
                    }
                    
                    break;

                case 2:
                    //Move Right
                    if (transform.position.x < 4)
                    {
                        Debug.Log(right);
                        Debug.Log(transform.position);
                        Debug.Log(transform.position + right);
                        body.MovePosition(transform.position + right);
                        
                    }
                    break;

                default:
                    return;
            }
            currentAttackTimer = Random.Range(timer_min, timer_max);
        } else
        {
            currentAttackTimer -= Time.deltaTime;
        }
         
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerControl>().reduceHearts(1);
            Destroy(gameObject);
        }
    }
}
