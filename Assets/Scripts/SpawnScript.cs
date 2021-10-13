using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    private GameObject[] spawnable_areas;
    private List<GameObject> Prefabs = new List<GameObject>();
    public GameObject Breadboard;
    public GameObject Sensor;
    public GameObject Arduino;
    private bool[] bools = new bool[200];
    void Start()
    {
        spawnable_areas = GameObject.FindGameObjectsWithTag("spawn");
        Prefabs.Add(Breadboard);
        Prefabs.Add(Breadboard);
        Prefabs.Add(Sensor);
        Prefabs.Add(Arduino);
        Spawn();
    }
    void Update()
    {
        //if (Input.GetKeyDown("r"))
        //{
        //    bools = new bool[100];
        //    spawnable_areas = GameObject.FindGameObjectsWithTag("spawn");
        //    DeleteSpawnedObjectsWithTag("spawnable");
        //    Spawn();
        //}
    }
    void Spawn()
    {
        for (int i = 0; i < Prefabs.Count; i++)
        {
            int rand;
            do
            {
                rand = Random.Range(1, spawnable_areas.Length);
            } while (bools[rand] == true);
            GameObject temp = Instantiate(Prefabs[i], spawnable_areas[rand].transform.position, Quaternion.identity);
            bools[rand] = true;
        }
    }
    //void DeleteSpawnedObjectsWithTag(string tag)
    //{
    //    GameObject[] objs;
    //    objs = GameObject.FindGameObjectsWithTag(tag);
    //    for(int i = 0; i < objs.Length; i++)
    //    {
    //        Destroy(objs[i]);
    //    }
    //}
}
