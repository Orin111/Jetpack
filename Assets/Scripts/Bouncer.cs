using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;
public class Bouncer : MonoBehaviour
{
    private float speed = 5; Rigidbody rigid;
    void Start()
    {
        rigid = GetComponent<Rigidbody>(); rigid.velocity = Random.onUnitSphere;
    }
    void FixedUpdate()
    {
        rigid.velocity = rigid.velocity.normalized * speed;
    }
    void OnCollisionEnter(Collision col)
    {
        rigid.velocity = rigid.velocity + Random.onUnitSphere;
    }
    public void Die(Game game)
    {
        Game.score += 200;
        Debug.Log("Score: " + Game.score);
        Debug.Log("Great! the bouncer die");
        Destroy(gameObject);
    }
}

