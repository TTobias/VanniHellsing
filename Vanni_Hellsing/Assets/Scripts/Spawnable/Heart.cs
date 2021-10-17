using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    public Rigidbody body;
    public float speedFactor = 1f;
    //public Vector3 speed = new Vector3(0, 0, -4);
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        body.MovePosition(transform.position + Vector3.back * WorldMovement.movementSpeed * speedFactor * 2f * Time.fixedDeltaTime);
        body.MoveRotation(Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + 5f, transform.rotation.eulerAngles.z));

        if (this.transform.position.z < -20f)
        {
            Destroy(this.gameObject);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            
            other.gameObject.GetComponent<PlayerControl>().increaseHearts();
            Destroy(gameObject);
        }
    }
}
