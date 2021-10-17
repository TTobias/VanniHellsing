using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolt : MonoBehaviour
{
    public Rigidbody body;
    public float speed = 12f;
    public PlayerControl pc;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        body.MovePosition(transform.position + Vector3.forward * Time.fixedDeltaTime * speed);

        if(this.transform.position.z > 200f){
            Destroy(this.gameObject);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Stone"))
        {
            SoundManager.instance.PlaySound("StoneHit", gameObject);
            Destroy(gameObject);
        }
        else if (other.gameObject.CompareTag("Enemy"))
        {
            SoundManager.instance.PlaySound("EnemyHit", gameObject);
            pc.increaseScore(100);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        else if (other.gameObject.CompareTag("Vampire"))
        {
            SoundManager.instance.PlaySound("EnemyHit", gameObject);
            pc.increaseScore(1000);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        else if (other.gameObject.CompareTag("Schneepir"))
        {
            SoundManager.instance.PlaySound("EnemyHit", gameObject);
            other.gameObject.GetComponent<Schneepir>().reduceHp();
            Destroy(gameObject);
        }
        else if (other.gameObject.CompareTag("Bat"))
        {
            SoundManager.instance.PlaySound("EnemyHit", gameObject);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
