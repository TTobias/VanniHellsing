using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : MonoBehaviour
{
    public Rigidbody body;
    public float speedFactor = 1.2f;
    //public Vector3 speed = new Vector3(0, 0, -6);
    
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        body.MovePosition(transform.position + Vector3.back * speedFactor * WorldMovement.movementSpeed * 2f * Time.fixedDeltaTime);

        if(this.transform.position.z < -20f){
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

