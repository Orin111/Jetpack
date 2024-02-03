using System.Collections;
using UnityEngine;

public class InvincibilityCapsule : MonoBehaviour
{
    public float invincibilityDuration = 5.0f; // Duration of invincibility

    public void Die()
    {
        StartCoroutine(ActivateInvincibility());
    }

    private IEnumerator ActivateInvincibility()
    {
        gameObject.SetActive(false);
        Debug.Log("You are now invisible for 5 sec");
        yield return new WaitForSeconds(invincibilityDuration);
    }
}