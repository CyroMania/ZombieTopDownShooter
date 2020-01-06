using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpTrigger : MonoBehaviour
{
    private GameObject WeaponShotgun;
    private void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
    }

    public void ShotgunAmmo()
    {
        WeaponShotgun = GameObject.Find("Shotgun");
        var Shotgun = WeaponShotgun.GetComponent("Weapon");
        Debug.Log("Shotgun Ammo Gained");
        Shotgun.SendMessage("GainAmmo", 10);
    }

    public void PistolAmmo()
    {
        Debug.Log("Pistol Ammo Gained");
    }
}
