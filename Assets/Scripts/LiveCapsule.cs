using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiveCapsule : MonoBehaviour
{
    public void Die()
    {
        Debug.Log("You got an extra live");
        Destroy(gameObject);
    }
  
}
