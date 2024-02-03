using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Jetpack : MonoBehaviour
{
    public Vector3 leftThrust;
    public Vector3 rightThrust;
    public GameObject bulletPrefab;
    public float bulletForce;
    Vector3 fireDirection;
    private bool invincible = false; // Track invincibility state
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    void FixedUpdate()
    {
        Vector3 force = Vector3.zero;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            force += leftThrust;
            fireDirection = Vector3.left;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            force += rightThrust;
            fireDirection = Vector3.right;
        }
        rb.AddForce(force);
    }
    private void Update()
    {
        if (!Input.GetKeyDown(KeyCode.Space))
            return;

        GameObject go = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        Bullet bullet = go.GetComponent<Bullet>();
        bullet.force = fireDirection * bulletForce;
    }
    IEnumerator InvincibilityTimer(float duration)
    {
        yield return new WaitForSeconds(duration);
        invincible = false; // Disable invincibility after the specified duration
        Debug.Log("You are now visible again");
        gameObject.SetActive(true); // Make the Jetpack visible again
    }
    
    void OnCollisionEnter(Collision coll)
    {
        if (!invincible) // Check if invincible before handling collision
        {
            if (coll.gameObject.CompareTag("Good"))
            {
                Good good = coll.gameObject.GetComponent<Good>();
                good.Die();
            }
            else if (coll.gameObject.CompareTag("LiveCapsule"))
            {
                LiveCapsule livaC = coll.gameObject.GetComponent<LiveCapsule>();
                Game.instance.lives++;
                livaC.Die();
            }
        
            else if (coll.gameObject.CompareTag("InvincibilityCapsule"))
            {
                invincible = true; // Set the player as invincible
                InvincibilityCapsule invincibleC = coll.gameObject.GetComponent<InvincibilityCapsule>();
                invincibleC.Die(); // Start the invincibility coroutine
                StartCoroutine(InvincibilityTimer(invincibleC.invincibilityDuration)); // Start the timer
            }
            else if (coll.gameObject.CompareTag("Bad") || coll.gameObject.CompareTag("BadBouncer"))
            {
                Debug.Log("Bad");
                Destroy(this);
                gameObject.layer = 0;
                Game.instance.Die();
            }
        }
        
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bad"))
        {
            Destroy(this);
            gameObject.layer = 0;
            Game.instance.Die();
        }
    }
}
