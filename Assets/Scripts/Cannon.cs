using System.Collections;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public GameObject applePrefab;
    private Coroutine shootingCoroutine;
    public float secondsShoot = 5f;
    public float shootForce = 100;
    public static int CannonLives = 3;
    public Vector3 offset;
    public Game game;

    void Start()
    {
        shootingCoroutine = StartCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        while (true)
        {
            yield return new WaitForSeconds(secondsShoot); 
            if (applePrefab != null) // Check if the applePrefab is not null before instantiating
            {
                Vector3 position = transform.position + offset;
                GameObject apple = Instantiate(applePrefab, position, Quaternion.identity);
                Vector3 direction = (game.jetman.transform.position - position).normalized;
                //Debug.Log("Direction: " + direction);
                apple.GetComponent<Rigidbody>().AddForce(direction * shootForce);
            }
        }
    }

    public void Die(Game game)
    {
        Game.score += 100;
        Debug.Log("Score: " + Game.score);
        Debug.Log("Great! the cannon tree die");

        if (shootingCoroutine != null)
        {
            Debug.Log("Stopping coroutine");
            StopCoroutine(shootingCoroutine);
        }
        else
        {
            Debug.Log("Coroutine is null!");
        }

        Destroy(gameObject);
    }
}