using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snowball : MonoBehaviour
{
    public Rigidbody body;
    public Vector3 speed = new Vector3(0, 0, -4);
    public Vector3 scaleChange = new Vector3(0.01f, 0.01f, 0.01f);
    
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        body.MovePosition(transform.position + speed * Time.fixedDeltaTime);
        body.transform.localScale += scaleChange * Time.fixedDeltaTime;
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
