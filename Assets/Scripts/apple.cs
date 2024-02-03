using UnityEngine;

public class Apple : MonoBehaviour
{
    public float destroyYPosition = -10f; 

    void Update()
    {
        // Check if the apple's Y position is below the destroyYPosition
        if (transform.position.y <= destroyYPosition)
        {
            Destroy(gameObject); // Destroy the apple GameObject
        }
    }
}