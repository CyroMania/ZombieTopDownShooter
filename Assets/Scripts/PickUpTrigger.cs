using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpTrigger : MonoBehaviour
{
    public GameObject Weapon;
    private void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
    }

    public void ShotgunAmmo()
    {
        Debug.Log("Shotgun Ammo Picked Up");
        //var WeaponScript = ;
        //WeaponScript;
        Weapon.SendMessage("IncreaseShotgunAmmo", 6);
    }

    public void PistolAmmo()
    {
        Debug.Log("Pistol Ammo Gained");
    }
}
