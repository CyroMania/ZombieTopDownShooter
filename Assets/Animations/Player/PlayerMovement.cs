using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    static Animator Anim;
    public Camera theCamera;
    private Rigidbody2D Rb;
    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponent<Animator>();
        Rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
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
            Anim.SetBool("facingLeft", false);
            Anim.SetBool("facingRight", true);
            Anim.SetBool("facingForward", false);
        }
        else if(difference.y * -1 > difference.x && difference.y > 0)
        {
            Anim.SetBool("facingLeft", true);
            Anim.SetBool("facingRight", false);
            Anim.SetBool("facingForward", false);
        }
        else if (difference.x > -1 * difference.y)
        {
            Anim.SetBool("facingLeft", false);
            Anim.SetBool("facingRight", true);
            Anim.SetBool("facingForward", true);
        }
        else if (difference.x < difference.y)
        {
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

        Vector2 Stationary = new Vector2(0, 0);

        if ((InputY != 0 || InputX != 0) && Rb.velocity != Stationary)
        {
            Anim.SetBool("isMoving", true);
        }
        else
        {
            Anim.SetBool("isMoving", false);
        }
    }
}
