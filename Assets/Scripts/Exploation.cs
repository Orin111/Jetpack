using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exploation : MonoBehaviour
{
    public GameObject explosionPrefab;
    public void OnTriggerEnter(Collider collider)
    {
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}

