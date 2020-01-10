using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Magazine : MonoBehaviour
{
    public Image MagazineAmmo;

    public Sprite PistolAmmo_10;
    public Sprite PistolAmmo_9;
    public Sprite PistolAmmo_8;
    public Sprite PistolAmmo_7;
    public Sprite PistolAmmo_6;
    public Sprite PistolAmmo_5;
    public Sprite PistolAmmo_4;
    public Sprite PistolAmmo_3;
    public Sprite PistolAmmo_2;
    public Sprite PistolAmmo_1;

    public Sprite ShotgunAmmo_6;
    public Sprite ShotgunAmmo_5;
    public Sprite ShotgunAmmo_4;
    public Sprite ShotgunAmmo_3;
    public Sprite ShotgunAmmo_2;
    public Sprite ShotgunAmmo_1;

    public Sprite EmptyMagazine;

    private int CurrentMagazineAmmo;
    private string CurrentWeapon;

    private void Start()
    {
        CurrentWeapon = "Pistol";
        CurrentMagazineAmmo = 10;
    }

    void Update()
    {
        if (CurrentWeapon == "Pistol")
        {
            if (CurrentMagazineAmmo == 10)
                MagazineAmmo.sprite = PistolAmmo_10;

            else if (CurrentMagazineAmmo == 9)
                MagazineAmmo.sprite = PistolAmmo_9;

            else if (CurrentMagazineAmmo == 8)
                MagazineAmmo.sprite = PistolAmmo_8;

            else if (CurrentMagazineAmmo == 7)
                MagazineAmmo.sprite = PistolAmmo_7;

            else if (CurrentMagazineAmmo == 6)
                MagazineAmmo.sprite = PistolAmmo_6;

            else if (CurrentMagazineAmmo == 5)
                MagazineAmmo.sprite = PistolAmmo_5;

            else if (CurrentMagazineAmmo == 4)
                MagazineAmmo.sprite = PistolAmmo_4;

            else if (CurrentMagazineAmmo == 3)
                MagazineAmmo.sprite = PistolAmmo_3;

            else if (CurrentMagazineAmmo == 2)
                MagazineAmmo.sprite = PistolAmmo_2;

            else if (CurrentMagazineAmmo == 1)
                MagazineAmmo.sprite = PistolAmmo_1;

            else
                MagazineAmmo.sprite = EmptyMagazine;
        }

        else if (CurrentWeapon == "Shotgun")
        {
            if (CurrentMagazineAmmo == 6)
                MagazineAmmo.sprite = ShotgunAmmo_6;

            else if (CurrentMagazineAmmo == 5)
                MagazineAmmo.sprite = ShotgunAmmo_5;

            else if (CurrentMagazineAmmo == 4)
                MagazineAmmo.sprite = ShotgunAmmo_4;

            else if (CurrentMagazineAmmo == 3)
                MagazineAmmo.sprite = ShotgunAmmo_3;

            else if (CurrentMagazineAmmo == 2)
                MagazineAmmo.sprite = ShotgunAmmo_2;

            else if (CurrentMagazineAmmo == 1)
                MagazineAmmo.sprite = ShotgunAmmo_1;

            else
                MagazineAmmo.sprite = EmptyMagazine;
        }
    }

    public void SetMagazineAmmo(int inCurrentMagazineAmmo)
    {
        CurrentMagazineAmmo = inCurrentMagazineAmmo;
    }

    public void SetCurrentWeapon(string inCurrentWeapon)
    {
        CurrentWeapon = inCurrentWeapon;
    }
}
