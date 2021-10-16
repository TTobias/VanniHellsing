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


    public int health = 3;
    public int maxHealth = 3;

    public int score;


    void Update()
    {
        //Scarving
        if(onCarving){
            // 0=up, 1=right, 2=left, 3=down
            int dir =   Input.GetButtonDown("up")? 0:
                        Input.GetButtonDown("right")? 1: 
                        Input.GetButtonDown("left")? 2:
                        Input.GetButtonDown("down")? 3: -1;
            
            if(dir >= 0 && dir < 4){
                makeCarve(dir);
            }
        }

        //Shooting
        if(Input.GetButtonDown("attack")){
            if(bolts > 0){
                Debug.Log("SHOOTING SUCCESSFULL");
                makeShot();
            }else{
                Debug.Log("SHOOTING FAILED");
            }
        }

    }

    void FixedUpdate(){
        doMovement();

        //Scarving
        if(!onCarving && bolts < maxBolts && sticks > 0){
            createNewCarve();
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





    public bool onCarving = false;
    public int carvingProgress = 0;
    public int carvingMax = 3;
    public int[] carveDirections;
    // 0=up, 1=right, 2=left, 3=down
    public void makeCarve(int dir){
        if(carveDirections[carvingProgress] == dir){
            Debug.Log("CARVE BUTTON CONFIRMED");
            //PROGRESS
            carvingProgress++;
            if(carvingProgress == carvingMax){
                bolts++;
                sticks--;
                onCarving = false;
            }

        }else{
            Debug.Log("CARVING FAILED");
            //FAILURE
            sticks--;
            onCarving = false;
        }
    }

    public void createNewCarve(){
        onCarving = true;
        carvingProgress = 0;
        int[] dirs = new int[carvingMax];
        for(int i = 0; i<carvingMax; i++){
            dirs[i] = randomDir();
        }
        carveDirections = dirs;
    }

    int randomDir(){
        float tmp = Random.Range(0f,10f);
        // 0=up, 1=right, 2=left, 3=down
        return tmp<3.5f?0: tmp<5.5f?1: tmp<7.5f? 2: 3;
    }



    public void makeShot(){
        bolts--;
        //TODO Shot
    }


    public void takeDamage(){

    }

    public void setSticks(int x)
    {
        if (sticks < 10)
        {
            sticks++;
        }
    }

    public void reduceHearts(int x)
    {
        health--;
    }


}
