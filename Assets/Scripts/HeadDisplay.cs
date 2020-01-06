using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeadDisplay : MonoBehaviour
{
    Animator Anim;
    private void Start()
    {
        Anim = GetComponent<Animator>();
    }
    public void UpdateImage()
    {
        Anim.SetInteger("Health", PlayerPrefs.GetInt("PlayerHealth"));
    }
}
