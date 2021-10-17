using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BossPreperation : MonoBehaviour
{
    public static bool CanSpawn;
    public bool SchneepirAvailable = true;
    public PlayerControl pc;
    public GameObject Schneepir;


    //public GameObject SchneepirUI;
    public Image bossIcon;
    public Image bossbar;
    public Image bossbarBg;


    // Start is called before the first frame update
    void Start()
    {
        CanSpawn = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (pc.getScore() > 10000 && SchneepirAvailable)
        {
            Debug.Log("Schneepir Spawned");

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
            Schneepir s = g.GetComponent<Schneepir>();
            //g.GetComponent<Schneepir>().textMesh = SchneepirUI.GetComponent<TextMeshProUGUI>();
            bossbar.enabled = true;
            bossbarBg.enabled = true;
            bossIcon.enabled = true;

            s.bossbar = bossbar;
            s.bossbarBg = bossbarBg;
            s.bossIcon = bossIcon;
            //SchneepirUI.SetActive(true);
            
            SchneepirAvailable = false;
        }
    }
}
