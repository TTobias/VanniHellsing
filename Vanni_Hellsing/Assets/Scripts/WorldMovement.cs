using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldMovement : MonoBehaviour
{
    public float movementSpeed = 1f;
    public float tmpPos = 0f;

    public int loadTiles = 10;
    public GameObject[] tiles;

    public float tileSize = 10f;
    public GameObject tilePrefab;


    public void Start()
    {
        tiles = new GameObject[loadTiles];
        for(int i = 0; i<tiles.Length; i++){
            tiles[i] = Instantiate(tilePrefab);
            tiles[i].transform.position = new Vector3(0,0,(1+i)*tileSize);
        }
    }

    public void FixedUpdate()
    {
        for(int i = 0; i<tiles.Length; i++){
            tiles[i].transform.position = new Vector3(tiles[i].transform.position.x, tiles[i].transform.position.y,tiles[i].transform.position.z -movementSpeed);
        }
        tmpPos -= movementSpeed;
        if(tmpPos < -(2*tileSize)){
            tmpPos += tileSize;
            Destroy(tiles[0]);
            for(int i = 1; i<loadTiles;i++){
                tiles[i-1] = tiles[i];
            }
            tiles[tiles.Length-1] = Instantiate(tilePrefab);
            tiles[tiles.Length-1].transform.position = new Vector3(0, 0, loadTiles*tileSize + tmpPos);
        }
    }
}
