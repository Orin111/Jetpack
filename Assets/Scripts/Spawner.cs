using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefab;
    public GameObject Spawn()
    {
        GameObject go = (GameObject)Instantiate(prefab, transform.position, Quaternion.identity);
        return go;
    }
}

