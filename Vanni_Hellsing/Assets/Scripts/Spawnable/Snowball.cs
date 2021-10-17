using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snowball : MonoBehaviour
{
    public Rigidbody body;
    public float speedFactor = 1f;
    //public Vector3 speed = new Vector3(0, 0, -4);
    public Vector3 scaleChange = new Vector3(0.01f, 0.01f, 0.01f);
    public Vector3 roatationChange = new Vector3(0, 3, 0);
    
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        body.MovePosition(transform.position + Vector3.back * WorldMovement.movementSpeed * 2f * speedFactor * Time.fixedDeltaTime);
        body.transform.localScale += scaleChange * Time.fixedDeltaTime;
        body.transform.Rotate(roatationChange * Time.fixedDeltaTime);

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
