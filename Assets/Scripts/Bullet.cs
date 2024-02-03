using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject explosionPrefab;
    public Rigidbody rigid;
    public Vector3 force;
    public Vector3 rand; // Declare the variable

    public float explosionForce = 20.0f;

    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        rigid.velocity = force;

        rand = Random.onUnitSphere; // Initialize rand in the Start method
    }

    void FixedUpdate()
    {
        rigid.velocity = rigid.velocity.normalized * 4;
    }

    void OnCollisionEnter(Collision other)
    {
        rigid.velocity += rand;
    }
    public void OnTriggerEnter(Collider collider)
    {
        if (collider.attachedRigidbody != null)
        {
            if (collider.attachedRigidbody.CompareTag("BadBouncer"))
            {
                Bouncer bouncer = collider.gameObject.GetComponent<Bouncer>();
                if (bouncer != null)
                {
                    bouncer.Die(Game.instance);
                }
            }

            if (collider.attachedRigidbody.CompareTag("Cannon"))
            {
                Cannon cannon = collider.gameObject.GetComponent<Cannon>();
                if (cannon != null)
                {
                    Cannon.CannonLives--;
                    Debug.Log("CannonLives: " + Cannon.CannonLives);
                    if (Cannon.CannonLives == 0)
                    {
                        cannon.Die(Game.instance);
                    }
                }
            }
        }

        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

}