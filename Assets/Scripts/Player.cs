using UnityEngine;
public class Player : MonoBehaviour
{
    private Animator gunAnim;
    public delegate void UpdateHealth(int newHealth);
    public static event UpdateHealth OnUpdateHealth;
    private void Start()
    {
        gunAnim = GetComponent<Animator>();
    }




    private void Update()
    {


        if (Input.GetMouseButton(0))
        {
            gunAnim.SetBool("isFiring", true);
        }
        else
        {
            gunAnim.SetBool("isFiring", false);
        }

    }
    public void SendHealthData(int health)
    {
        if (OnUpdateHealth != null)
        {
            OnUpdateHealth(health);
        }
    }
}
