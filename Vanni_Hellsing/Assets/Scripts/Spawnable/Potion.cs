using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{
    public Rigidbody body;
    public float speed = 5f;
    public PlayerControl pc;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        body.MovePosition(transform.position + Vector3.back * Time.fixedDeltaTime * speed);

        if (this.transform.position.z > 200f)
        {
            Destroy(this.gameObject);
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
