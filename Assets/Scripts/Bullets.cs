using UnityEngine;
public class Bullets : MonoBehaviour
{
    public float moveSpeed = 100.0f;
    public int damage = 1;
    private void Start()
    {
        GetComponent<Rigidbody2D>().AddForce(transform.right * moveSpeed);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        other.transform.SendMessage("TakeDamage", damage, SendMessageOptions.DontRequireReceiver);
        Die();
    }
    private void OnBecameInvisible()
    {
        Die();
    }
    private void Die()
    {
        Destroy(gameObject);
    }
}
