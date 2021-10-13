using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    public GameObject[] spawnable_areas;
    void Start()
    {
        spawnable_areas = GameObject.FindGameObjectsWithTag("spawn");
        Spawn();
    }
    void Spawn()
    {

    }
}
