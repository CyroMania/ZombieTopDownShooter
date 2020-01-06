using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PickUp : MonoBehaviour
{
    public UnityEvent OnPickUp;

    private Transform tr;
    public float scaleMultiplier = 3f;
    private float scaleMin;
    private float scaleMax;

    private Vector3 MaxScaleVector;
    private Vector3 MinScaleVector;

    private bool isOscillating = false;
    void Start()
    {
        isOscillating = true;
        tr = gameObject.GetComponent<Transform>();
        scaleMin = tr.localScale.x;
        scaleMax = scaleMin * scaleMultiplier;
        MaxScaleVector = new Vector3(scaleMax, scaleMax, 1); 
        MinScaleVector = new Vector3(scaleMin, scaleMin, 1);
        StartCoroutine(Oscillate());
    }

    // Update is called once per frame
    void Update()
    {
        if (!isOscillating)
        {
            isOscillating = true;
            StartCoroutine(Oscillate());
        }
    }


    IEnumerator Oscillate()
    {
        while (tr.localScale.x < MaxScaleVector.x)
        {
            tr.localScale = new Vector3(tr.localScale.x * 1.02f, tr.localScale.y * 1.02f, 1f);
            yield return new WaitForSeconds(0.02f);

        }

        while (tr.localScale.y > MinScaleVector.y)
        {
            tr.localScale = new Vector3(tr.localScale.x / 1.02f, tr.localScale.y / 1.02f, 1f);
            yield return new WaitForSeconds(0.02f);

        }
        isOscillating = false;
    }


    private void OnDestroy()
    {
        OnPickUp.Invoke();
    }
}
