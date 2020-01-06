using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using System.Collections;

public class DestroyOnDie : MonoBehaviour
{
    public float waitTime = 4f;

    public void  Die()
    {
        float timeWaited = 0f;
        while (timeWaited < waitTime)
        {
            timeWaited += Time.deltaTime;
        }
        if (timeWaited >= waitTime)
        {
            Destroy(gameObject);

        }

    }
}
