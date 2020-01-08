using UnityEngine;
using System.Collections;
public class Weapon : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawn;

    public int maxMagazineAmmo = 10;
    public int RemainingAmmo = 30;
    public int currentMagazineAmmo;
    public float ReloadTime = 3f;

    public bool UnlimitedAmmo = false;
    public float fireTime = 0.3f;
    private bool isFiring = false;
    private bool isReloading = false;
    private bool canReload = true;


    private void Start()
    {
        currentMagazineAmmo = maxMagazineAmmo;
    }


    private void SetFiring()
    {
        isFiring = false;
    }
    private void Fire()
    {
        Debug.Log("Firing");
        isFiring = true;
        currentMagazineAmmo--;

        Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        if (GetComponent<AudioSource>() != null)
        {
            GetComponent<AudioSource>().Play();
        }
        Invoke("SetFiring", fireTime);
    }
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (currentMagazineAmmo > 0)
            {
                if (!isReloading)
                {
                    if (!isFiring)
                    {
                        Fire();
                    }
                }
            }
            else
            {
                if (canReload)
                {
                    if (!isReloading)
                    {
                        StartCoroutine(Reload());
                        isReloading = true;
                        return;
                    }
                }
                else
                {
                    Debug.Log("Can't Reload");
                }
            }
        }

        if (Input.GetKey("r"))
        {
            if (canReload)
            {
                if (!isReloading)
                {
                    StartCoroutine(Reload());
                    isReloading = true;
                    return;
                }
            }
        }
    }

    

    IEnumerator Reload()
    {

        Debug.Log("Reloading...");

        yield return new WaitForSeconds(ReloadTime);

        if (!UnlimitedAmmo)
        {
            int AmmoNeeded = maxMagazineAmmo - currentMagazineAmmo;
            if (AmmoNeeded <= RemainingAmmo)
            {
                currentMagazineAmmo = maxMagazineAmmo;
                RemainingAmmo -= AmmoNeeded;
            }
            else
            {
                currentMagazineAmmo += RemainingAmmo;
                RemainingAmmo = 0;
                canReload = false;
            }
        }
        else
        {
            currentMagazineAmmo = maxMagazineAmmo;
        }
        isReloading = false;
    }

    public void GainAmmo(int AmmoGained)
    {
        Debug.Log("Ammo has been gained");
        RemainingAmmo += AmmoGained;
    }

    private void OnEnable()
    {
        if (gameObject.name == "Shotgun")
        {
            RemainingAmmo = Ammunitio
        }
    }

}
