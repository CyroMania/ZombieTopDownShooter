using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunFiring : MonoBehaviour
{
    private Animator gunAnim;
    public int maxAmmo = 10;



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
}
