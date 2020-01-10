using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunFacing : MonoBehaviour
{
    static Animator Anim;
    public Camera theCamera;
    public GameObject Parent;
    private bool isFiring;
    private bool isReloading;
    Vector3 MoveInfront;
    Vector3 MoveBehind;


    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        float Fire = Input.GetAxis("Fire1");

        if (Fire > 0f)
        {
            Anim.SetBool("isFiring", true);
        }
        else
        {
            Anim.SetBool("isFiring", false);
        }




        isFiring = Anim.GetBool("isFiring");
        Vector3 target = theCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector3 difference = target - transform.position;
        if (difference.x < difference.y && difference.y * -1 < difference.x)
        {
            Anim.SetBool("facingLeft", false);
            Anim.SetBool("facingRight", false);
            Anim.SetBool("facingForward", false);
        }
        else if (difference.x > difference.y && difference.y > 0)
        {
            MoveBehind = new Vector3(Parent.transform.position.x, Parent.transform.position.y, -0.5f);
            transform.position = MoveBehind;
            Anim.SetBool("facingLeft", false);
            Anim.SetBool("facingRight", true);
            Anim.SetBool("facingForward", false);
        }
        else if (difference.y * -1 > difference.x && difference.y > 0)
        {
            MoveBehind = new Vector3(Parent.transform.position.x, Parent.transform.position.y, -0.5f);
            transform.position = MoveBehind;
            Anim.SetBool("facingLeft", true);
            Anim.SetBool("facingRight", false);
            Anim.SetBool("facingForward", false);
        }
        else if (difference.x > -1 * difference.y)
        {
            MoveInfront = new Vector3(Parent.transform.position.x, Parent.transform.position.y, -1.5f);
            transform.position = MoveInfront;
            Anim.SetBool("facingLeft", false);
            Anim.SetBool("facingRight", true);
            Anim.SetBool("facingForward", true);
        }
        else if (difference.x < difference.y)
        {
            MoveInfront = new Vector3(Parent.transform.position.x, Parent.transform.position.y, -1.5f);
            transform.position = MoveInfront;
            Anim.SetBool("facingLeft", true);
            Anim.SetBool("facingRight", false);
            Anim.SetBool("facingForward", true);
        }
        else
        {
            Anim.SetBool("facingLeft", false);
            Anim.SetBool("facingRight", false);
            Anim.SetBool("facingForward", true);
        }

        float InputX = Input.GetAxis("Horizontal");
        float InputY = Input.GetAxis("Vertical");





    }
}
