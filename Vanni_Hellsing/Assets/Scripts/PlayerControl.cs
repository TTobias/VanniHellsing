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
        //Scarving
        if(onScarving){
            // 0=up, 1=right, 2=left, 3=down
            int dir =   Input.GetButtonDown("up")? 0:
                        Input.GetButtonDown("right")? 1: 
                        Input.GetButtonDown("left")? 2:
                        Input.GetButtonDown("down")? 3: -1;
            
            if(dir >= 0 && dir < 4){
                makeScarve(dir);
            }
        }

        //Shooting
        if(Input.GetButtonDown("attack") && bolts > 0){
            makeShot();
        }

    }

    void FixedUpdate(){
        doMovement();

        //Scarving
        if(!onScarving && bolts < maxBolts && sticks > 0){
            createNewScarve();
        }
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





    public bool onScarving = false;
    public int scarvingProgress = 0;
    public int scarvingMax = 3;
    public int[] scarveDirections;
    // 0=up, 1=right, 2=left, 3=down
    public void makeScarve(int dir){
        
    }

    public void createNewScarve(){
        
    }



    public void makeShot(){
        bolts--;
    }
}
