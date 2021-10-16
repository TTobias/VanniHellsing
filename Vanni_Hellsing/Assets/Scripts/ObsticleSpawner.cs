using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObsticleSpawner : MonoBehaviour
{
    public GameObject stone;
    public float timer_min;
    public float timer_max;
    float currentSpawnTimer;
    // Start is called before the first frame update
    void Start()
    {
        currentSpawnTimer = Random.Range(timer_min, timer_max);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentSpawnTimer < 0)
        {
            int x = Random.Range(-4, 4);
            Instantiate(stone, new Vector3(x, 1, 70), Quaternion.identity);

            currentSpawnTimer = Random.Range(timer_min, timer_max);
        }
        else
        {
            currentSpawnTimer -= Time.deltaTime;
        }
    }
}
