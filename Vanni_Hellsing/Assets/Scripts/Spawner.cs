using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject obj;
    public float timer_min, timer_max;
    float currentSpawnTimer;
    public LayerMask baselayer;

    public float spawnDistance = 70f;

    public bool spawnDuringBoss = true;
    


    void Start()
    {
        currentSpawnTimer = Random.Range(timer_min, timer_max);
    }



    void FixedUpdate(){

        if(spawnDuringBoss || BossPreperation.CanSpawn){

            if(currentSpawnTimer < 0){

                //X position of the spawning object
                int x = Random.Range(-4, 4);
                transform.position = new Vector3(x, 0, spawnDistance);

                //Collider Check
                Collider[] hitColliders = Physics.OverlapSphere(new Vector3(x, 1, 70), 1, baselayer, QueryTriggerInteraction.UseGlobal);
                foreach (var hitCollider in hitColliders)
                {
                    if (hitCollider.gameObject.CompareTag("Enemy") || hitCollider.gameObject.CompareTag("Wood") || hitCollider.gameObject.CompareTag("Stone") || hitCollider.gameObject.CompareTag("Spawner"))
                    {
                        Debug.Log(hitCollider.gameObject.name);
                        return;
                    }

                }
                Instantiate(obj ,new Vector3(x,0,70),Quaternion.identity);

                currentSpawnTimer = Random.Range(timer_min,timer_max);
            }else{
                currentSpawnTimer -= Time.fixedDeltaTime;
            }
        }
    }



    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 1);
    }
}
