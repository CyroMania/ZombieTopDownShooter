using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using UnityEngine.UI;
public class Weapon : MonoBehaviour
{
    public UnityEvent OnReload;
    public UnityEvent EndReload;

    public AudioSource CantReload;
    public AudioSource Reloading;

    public Image ReloadBar;

    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public GameObject Parent;

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
                        if (currentMagazineAmmo != maxMagazineAmmo)
                        {
                            StartCoroutine(Reload());
                            isReloading = true;
                            return;
                        }
                    }

                }
                else
                {
                    CantReload.Play();
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
                    if (currentMagazineAmmo != maxMagazineAmmo)
                    {
                        StartCoroutine(Reload());
                        isReloading = true;
                        return;
                    }
                }
            }
            else
            {
                CantReload.Play();
            }
        }
    }

    

    IEnumerator Reload()
    {
        float TimeReloaded = 0f;
        OnReload.Invoke();
        Reloading.Play();
        Debug.Log("Reloading...");

        while (TimeReloaded < ReloadTime)
        {
            yield return new WaitForSeconds(0.01f);
            TimeReloaded += 0.01f;
            ReloadBar.fillAmount = TimeReloaded / ReloadTime;
        }

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

        yield break;
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
            Parent.SendMessage("SetShotgunAmmo", RemainingAmmo);
        }
    }

    public void IncreaseRemainingAmmo(int AmmoGained)
    {
            RemainingAmmo += AmmoGained;
    }

    public void SetRemainingAmmo(int inAmmo)
    {
        RemainingAmmo = inAmmo;
    }
}
