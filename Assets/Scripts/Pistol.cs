using UnityEngine;
using System.Collections;
using UnityEngine.Events;
public class Pistol : MonoBehaviour
{
    public UnityEvent OnReload;
    public UnityEvent EndReload;

    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public GameObject Parent;

    public int maxMagazineAmmo = 10;
    private int RemainingAmmo = 30;
    public int currentMagazineAmmo;
    public float ReloadTime = 3f;

    public bool UnlimitedAmmo = true;
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
            if (RemainingAmmo == 0)
            {
                canReload = false;
            }
            else
            {
                canReload = true;
            }

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
            if (RemainingAmmo == 0)
            {
                canReload = false;
            }
            else
            {
                canReload = true;
            }

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
        OnReload.Invoke();
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
            }
        }
        else
        {
            currentMagazineAmmo = maxMagazineAmmo;
        }
        EndReload.Invoke();
        isReloading = false;
    }



    private void OnEnable()
    {
        if (gameObject.name == "Shotgun")
        {
            var ParentWeaponScript = Parent.GetComponent("Ammunition");
            ParentWeaponScript.SendMessage("SendShotgunAmmo", gameObject);
        }
    }

    private void OnDisable()
    {
        if (gameObject.name == "Shotgun")
        {
            var ParentWeaponScript = Parent.GetComponent("Ammunition");
            ParentWeaponScript.SendMessage("SetShotgunAmmo", RemainingAmmo);
        }
    }

    public void IncreaseRemainingAmmo(int AmmoGained)
    {

        Debug.Log("Ammo has been gained");
        RemainingAmmo += AmmoGained;

    }

    public void SetRemainingAmmo(int inAmmo)
    {
        RemainingAmmo = inAmmo;
    }
}
