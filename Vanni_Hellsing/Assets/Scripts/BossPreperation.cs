using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BossPreperation : MonoBehaviour
{
    public static bool CanSpawn;
    public bool SchneepirAvailable = true;
    public PlayerControl pc;
    public GameObject Schneepir;
    public GameObject SchneepirUI;
    // Start is called before the first frame update
    void Start()
    {
        CanSpawn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (pc.getScore() > 10000 && SchneepirAvailable)
        {
            CanSpawn = false;
            //Delete Everything
            GameObject[] prefabs = GameObject.FindGameObjectsWithTag("Vampire");
            foreach (GameObject prefab in prefabs)
            {
                Destroy(prefab);
            }
            GameObject[] prefabs2 = GameObject.FindGameObjectsWithTag("Stone");
            foreach (GameObject prefab in prefabs2)
            {
                Destroy(prefab);
            }
            GameObject[] prefabs3 = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject prefab in prefabs3)
            {
                Destroy(prefab);
            }
            GameObject[] prefabs4 = GameObject.FindGameObjectsWithTag("Bat");
            foreach (GameObject prefab in prefabs4)
            {
                Destroy(prefab);
            }
            //Spawn Schneepir
            GameObject g = Instantiate(Schneepir, new Vector3(0, 1, 20), Quaternion.identity);
            g.GetComponent<Schneepir>().textMesh = SchneepirUI.GetComponent<TextMeshProUGUI>();
            SchneepirUI.SetActive(true);
            SchneepirAvailable = false;
        }
    }
}
