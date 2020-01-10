using UnityEngine;
using System.Collections;
public class HurtTrigger : MonoBehaviour
{
    public int damage;
    public float resetTime = 0.25f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.transform.SendMessage("TakeDamage", damage, SendMessageOptions.DontRequireReceiver);
        GetComponent<Collider2D>().enabled = false;
        StartCoroutine(ResetTrigger(resetTime));
        gameObject.SendMessageUpwards("InContact", true);
    }
    IEnumerator ResetTrigger(float inResetTime)
    {
        yield return new WaitForSeconds(inResetTime);
        Debug.Log("Reset");
        GetComponent<Collider2D>().enabled = true;
    }
}
