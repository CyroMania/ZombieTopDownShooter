using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PickUpTrigger : MonoBehaviour
{
    public GameObject Weapon;
    public UnityEvent ShotgunAmmoPickUp;
    private void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Contains("ShotgunBullet"))
        {
            ShotgunAmmo();
        }
        Destroy(collision.gameObject);

    }

    public void ShotgunAmmo()
    {
        ShotgunAmmoPickUp.Invoke();
    }

    public void PistolAmmo()
    {
        Debug.Log("Pistol Ammo Gained");
    }
}
