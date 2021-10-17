using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Bolt : MonoBehaviour
{
    public Rigidbody body;
    public float speed = 12f;
    public PlayerControl pc;
    public GameObject PoisonGas;
    public GameObject points;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
    }


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
            int random = Random.Range(1, 6);
            switch (random)
            {
                case 1:
                    SoundManager.instance.PlaySound("GhoulDeath1", gameObject);
                    break;
                case 2:
                    SoundManager.instance.PlaySound("GhoulDeath2", gameObject);
                    break;
                case 3:
                    SoundManager.instance.PlaySound("GhoulDeath3", gameObject);
                    break;
                case 4:
                    SoundManager.instance.PlaySound("GhoulDeath4", gameObject);
                    break;
                default:
                    SoundManager.instance.PlaySound("GhoulDeath5", gameObject);
                    break;
            }
            pc.increaseScore(100);
            GameObject g = Instantiate(points, new Vector3(transform.position.x, transform.position.y+1, transform.position.z), Quaternion.identity);
            g.GetComponent<TextMeshPro>().text = "+100";
            Destroy(g, 0.5f);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        else if (other.gameObject.CompareTag("Vampire"))
        {
            SoundManager.instance.PlaySound("EnemyHit", gameObject);
            pc.increaseScore(1000);
            GameObject g = Instantiate(points, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), Quaternion.identity);
            g.GetComponent<TextMeshPro>().text = "+1000";
            int random = Random.Range(1, 3);
            switch (random)
            {
                case 1:
                    SoundManager.instance.PlaySound("VampireDeath1", gameObject);
                    break;
                case 2:
                    SoundManager.instance.PlaySound("VampireDeath2", gameObject);
                    break;
                default:
                    SoundManager.instance.PlaySound("VampireDeath3", gameObject);
                    break;
            }
            Destroy(g, 0.5f);
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
        else if (other.gameObject.CompareTag("Witchpir"))
        {
            SoundManager.instance.PlaySound("EnemyHit", gameObject);
            other.gameObject.GetComponent<Witchpir>().reduceHp();
            Destroy(gameObject);
        }
        else if (other.gameObject.CompareTag("Potion"))
        {
            Instantiate(PoisonGas, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.Euler(0, 90, 0));
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
