using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
[System.Serializable]
public class OnDamagedEvent : UnityEvent<int> { }
public class HealthSystem : MonoBehaviour
{
    public int health = 10;
    public UnityEvent onDie;
    public OnDamagedEvent onDamaged;


    public void TakeDamage(int damage)
    {
        health -= damage;
        PlayerPrefs.SetInt("PlayerHealth", health);
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

