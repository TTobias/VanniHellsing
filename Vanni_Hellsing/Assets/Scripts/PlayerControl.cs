using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float shiftSpeed = 2f;
    public float borderWidth = 5f;


    public int bolts = 0;
    public int sticks = 0;

    public int maxBolts = 5;
    public int maxSticks = 10;



    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void FixedUpdate(){
        doMovement();
    }

    void doMovement(){
        float dir = Input.GetAxis("Horizontal");
        float newX = this.transform.position.x + dir*shiftSpeed;
        if(newX > borderWidth){
            newX = borderWidth;
        }else if(newX < -borderWidth){
            newX = -borderWidth;
        }

        this.transform.position = new Vector3(newX, this.transform.position.y, this.transform.position.z);
    }
}
