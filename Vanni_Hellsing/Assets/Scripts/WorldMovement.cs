using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldMovement : MonoBehaviour
{
    public static float movementSpeed = 10f;
    public static int stage = 1;

    public float tmpPos = 0f;

    public int loadTiles = 12;
    public GameObject[] tiles;

    public float tileSize = 10f;

    public float groundHeight = 1f;



    public GameObject tilePrefab;
    public GameObject[] stage1Prefabs, stage2Prefabs, stage3Prefabs, stage4Prefabs, stage5Prefabs;


    public void Start()
    {
        tiles = new GameObject[loadTiles];
        for(int i = 0; i<tiles.Length; i++){
            tiles[i] = Instantiate(nextTile());
            tiles[i].transform.position = new Vector3(0,groundHeight,(1+i)*tileSize);
        }
    }

    public void FixedUpdate()
    {
        for(int i = 0; i<tiles.Length; i++){
            tiles[i].transform.position = new Vector3(tiles[i].transform.position.x, tiles[i].transform.position.y,tiles[i].transform.position.z -movementSpeed*0.1f);
        }
        tmpPos -= movementSpeed*0.1f;
        if(tmpPos < -(2*tileSize)){
            tmpPos += tileSize;
            Destroy(tiles[0]);
            for(int i = 1; i<loadTiles;i++){
                tiles[i-1] = tiles[i];
            }
            tiles[tiles.Length-1] = Instantiate(nextTile());
            tiles[tiles.Length-1].transform.position = new Vector3(0, groundHeight, loadTiles*tileSize + tmpPos);
        }
    }


    GameObject nextTile(){
        switch(stage){
            case(1):
                return randomElement(stage1Prefabs);
            case(2):
                return randomElement(stage2Prefabs);
            case(3):
                return randomElement(stage3Prefabs);
            case(4):
                return randomElement(stage4Prefabs);
            case(5):
                return randomElement(stage5Prefabs);
        }
        return null;
    }


    GameObject randomElement(GameObject[] arr){
        int r = Random.Range(0, arr.Length);
        return arr[r];
    }
}
