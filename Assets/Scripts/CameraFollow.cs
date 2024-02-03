using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float springiness;
    public Vector3 offset;

    // delete or comment out this :
    // void Start(){
    // offset = transform.position - target.position ;
    // }

    void Update()
    {
        target = Game.instance.jetman.transform;
        if (Game.instance.jetman == null || target == null) return;
        transform.position = Vector3.Lerp(transform.position, target.position +
        offset, springiness * Time.deltaTime);
    }
}



