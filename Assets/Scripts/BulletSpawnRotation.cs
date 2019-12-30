using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawnRotation : MonoBehaviour
{
    public Camera theCamera;
    public float adjustmentAngle = 0.0f;
    void Update()
    {
        Vector3 target = theCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector3 difference = target - transform.position;
        difference.Normalize();
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, rotZ + adjustmentAngle));


    }

}
