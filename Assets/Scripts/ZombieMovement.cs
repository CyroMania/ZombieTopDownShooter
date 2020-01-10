using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ZombieMovement : MonoBehaviour
{
    //public Transform target;
    public UnityEvent IsDead;
    private Transform player;
    private Animator Anim;
    private SpriteRenderer Sr;
    private bool ActivatedCoroutine = false;
    public float speed = 5.0f;

    public bool isDead = false;
    public bool isTouching = false;
    private float TargetX;
    private float ZombieX;
    private float TargetY;
    private float ZombieY;


    private void Start()
    {
        Anim = GetComponent<Animator>();
        Sr = GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }



    private void Update()
    {
        if (!ActivatedCoroutine)
        {
            if (isDead)
            {
                Anim.SetBool("hasDied", true);
                StartCoroutine(HasDied());
                ActivatedCoroutine = true;
            }
            else
            {
                Vector3 difference = player.transform.position - transform.position;
                TargetX = player.transform.position.x;
                ZombieX = gameObject.transform.position.x;
                TargetY = player.transform.position.y;
                ZombieY = gameObject.transform.position.y;

                if ((difference.x > .6 || difference.y > .6 || difference.x < -.6 || difference.y < -.6) && (isTouching = true))
                {
                    isTouching = false;
                }


                if (!Anim.GetCurrentAnimatorStateInfo(0).IsName("Zombie_Walk"))
                {
                    Anim.SetBool("hasSpawned", false);
                }
                else
                {
                    Anim.SetBool("hasSpawned", true);
                }


                if (player != null && Anim.GetBool("hasSpawned"))
                {
                    if (!isTouching)
                    {
                        if (TargetY > ZombieY)
                        {
                            transform.position = Vector3.MoveTowards(new Vector3(ZombieX, ZombieY, -1.5f), player.position, speed * 0.01f);
                        }
                        else
                        {
                            transform.position = Vector3.MoveTowards(new Vector3(ZombieX, ZombieY, -0.5f), player.position, speed * 0.01f);
                        }
                    }
                }



                if (TargetX < ZombieX)
                {
                    Sr.flipX = true;
                }
                else
                {
                    Sr.flipX = false;
                }

            }

        }


    }
    public void SetTarget(Transform newTarget)
    {
        player = newTarget;
    }

    public void InContact(bool Touching)
    {
        isTouching = Touching;
    }

    IEnumerator HasDied()
    {

        yield return new WaitForSeconds(6f);
        IsDead.Invoke();
    }

    public void SetBoolHasDied(bool state)
    {
        isDead = state;
    }
}
