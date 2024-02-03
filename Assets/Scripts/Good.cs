using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Good : MonoBehaviour
{
    // Note that Start happens on Play but after Awake 
   
    void Start()
    {
        Game.instance.RegisterGood();
    }

    public void Die()
    {
        Debug.Log("Good Die");
        Game.instance.UnregisterGood();
        Destroy(gameObject);
    }
}
