using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DestroyOnDie : MonoBehaviour
{
    public void Die()
    {
        Destroy(gameObject);
    }
}
