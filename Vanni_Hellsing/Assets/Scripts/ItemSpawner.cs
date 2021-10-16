using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject wood;
    public float timer_min;
    public float timer_max;
    float currentSpawnTimer;
    public LayerMask baselayer;
    // Start is called before the first frame update
    void Start()
    {
        currentSpawnTimer = Random.Range(timer_min,timer_max);
    }

    // Update is called once per frame
    void Update()
    {
        if(currentSpawnTimer <0){
            int x = Random.Range(-4, 4);
            transform.position = new Vector3(x, 1, 70);

            Collider[] hitColliders = Physics.OverlapSphere(new Vector3(x, 1, 70), 1, baselayer, QueryTriggerInteraction.UseGlobal);
            foreach (var hitCollider in hitColliders)
            {
                if (hitCollider.gameObject.CompareTag("Enemy") || hitCollider.gameObject.CompareTag("Wood") || hitCollider.gameObject.CompareTag("Stone") || hitCollider.gameObject.CompareTag("Spawner"))
                {
                    Debug.Log(hitCollider.gameObject.name);
                    return;
                }

            }
            Instantiate(wood,new Vector3(x,1,70),Quaternion.identity);

            currentSpawnTimer = Random.Range(timer_min,timer_max);
        }else{
            currentSpawnTimer -= Time.deltaTime;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 1);
    }
}
