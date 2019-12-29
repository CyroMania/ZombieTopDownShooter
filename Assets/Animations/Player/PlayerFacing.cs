using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFacing : MonoBehaviour
{
    static Animator Anim;
    public Camera theCamera;
    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 target = theCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector3 difference = target - transform.position;
        if (difference.x < difference.y && difference.y * -1 < difference.x)
        {
            Anim.Play("FacingBackward");
        }
        else if (difference.x > difference.y && difference.y > 0)
        {
            Anim.Play("FacingBackwardRight");
        }
        else if(difference.y * -1 > difference.x && difference.y > 0)
        {
            Anim.Play("FacingBackwardLeft");
        }
        else if (difference.x > -1 * difference.y)
        {
            Anim.Play("FacingForwardRight");
        }
        else if (difference.x < difference.y)
        {
            Anim.Play("FacingForwardLeft");
        }
        else
        {
            Anim.Play("FacingForward");
        }
    }
}
