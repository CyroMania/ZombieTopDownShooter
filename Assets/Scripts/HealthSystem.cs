using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
[System.Serializable]
public class OnDamagedEvent : UnityEvent<int> { }
public class HealthSystem : MonoBehaviour
{
    public int health = 100;
    public UnityEvent onDie;
    public OnDamagedEvent onDamaged;

    private void Start()
    {
        PlayerPrefs.SetInt("PlayerHealth", 100);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (gameObject.CompareTag("Player"))
        {
            PlayerPrefs.SetInt("PlayerHealth", health);
        }
        onDamaged.Invoke(health);

        if (health < 1)
        {
            onDie.Invoke();
        }
    }

    public void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}

