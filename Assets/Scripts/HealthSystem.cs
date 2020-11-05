using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
[System.Serializable]
public class OnDamagedEvent : UnityEvent<int> { }
public class HealthSystem : MonoBehaviour
{
    public int lives = 1;
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
            lives--;
            if (lives < 1)
            {
                GameOver();
            }
        }
    }

    public void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void GainLife()
    {
        lives++;
    }
}

