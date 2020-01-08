using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammunition : MonoBehaviour
{
    public int ShotgunAmmo = 12;

    public void SendShotgunAmmo(GameObject gameObject)
    {
        gameObject.SendMessage("SetRemainingAmmo", ShotgunAmmo);
    }

    public void SetShotgunAmmo(int inShotgunAmmo)
    {
        ShotgunAmmo = inShotgunAmmo;
    }

    public void IncreaseShotgunAmmo(int inBullets)
    {
        ShotgunAmmo += inBullets;
    }
}
