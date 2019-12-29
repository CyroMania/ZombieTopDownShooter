using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponFacing : MonoBehaviour
{
    static Animator Anim;
    public Camera theCamera;
    public GameObject Parent;
    private bool Firing;

    private Vector3 MoveBehind = new Vector3(0f, 0f, 0f);
    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Firing = Anim.GetBool("isFiring");
        Vector3 target = theCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector3 difference = target - transform.position;
            if (difference.x < difference.y && difference.y * -1 < difference.x)
            {
                Anim.Play("Weapon_Pistol_Backward");
                Vector3 MoveInfront = new Vector3(Parent.transform.position.x, Parent.transform.position.y, -1f);
                transform.position = MoveInfront;
            }
            else if (difference.x > difference.y && difference.y > 0)
            {
                Anim.Play("Weapon_Pistol_BackwardRight");
                Vector3 MoveBehind = new Vector3(Parent.transform.position.x, Parent.transform.position.y, 0f);
                transform.position = MoveBehind;
            }
            else if (difference.y * -1 > difference.x && difference.y > 0)
            {
                Anim.Play("Weapon_Pistol_BackwardLeft");
            }
            else if (difference.x > -1 * difference.y)
            {
                Anim.Play("Weapon_Pistol_ForwardRight");
                Vector3 MoveInfront = new Vector3(Parent.transform.position.x, Parent.transform.position.y, -1f);
                transform.position = MoveInfront;
            }
            else if (difference.x < difference.y)
            {
                Anim.Play("Weapon_Pistol_ForwardLeft");
            }
            else
            {
                Anim.Play("Weapon_Pistol_Forward");
            }

        Debug.Log(transform.position);
    }
}
