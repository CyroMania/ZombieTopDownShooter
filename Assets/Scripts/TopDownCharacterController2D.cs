using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TopDownCharacterController2D : MonoBehaviour
{
    public float speed = 2f;
    public float maxEnergy = 5f;
    private float energy;

    private bool cantRun = false;
    private float runningSpeed;

    public Image EnergyBar;

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        energy = maxEnergy;
    }
    void FixedUpdate()
    {
        runningSpeed = 1;
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");


        if (!cantRun)
        {
            runningSpeed += Input.GetAxis("Fire3");
        }



        rb.velocity = new Vector2(x, y) * speed * runningSpeed;
        rb.angularVelocity = 0.0f;

        if (runningSpeed > 1)
        {
            if (energy >= 0)
            {
                energy -= Time.deltaTime;
            }
            else
            {
                cantRun = true;
                StartCoroutine(Exhausted());
            }
        }
        else
        {
            if (energy < maxEnergy)
            {
                energy += Time.deltaTime;
            }
        }

        EnergyBar.fillAmount = (energy / maxEnergy);
    }

    IEnumerator Exhausted()
    {
        Debug.Log("Exhausted...");
        while (energy < maxEnergy)
        {
            yield return new WaitForSeconds(0.01f);
        }
        cantRun = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
