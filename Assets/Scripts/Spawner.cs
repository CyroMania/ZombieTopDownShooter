using UnityEngine;
public class Spawner : MonoBehaviour
{
    public int SpawnChance = 1;
    private int Result;

    public GameObject prefabToSpawn;
    public float adjustmentAngle = 0;
    public void Spawn()
    {
        Result = Random.Range(1, SpawnChance);
        if (Result == 1)
        {
            Vector3 rotationInDegrees = transform.eulerAngles;
            rotationInDegrees.z += adjustmentAngle;
            Quaternion rotationInRadians = Quaternion.Euler(rotationInDegrees);
            Instantiate(prefabToSpawn, transform.position, rotationInRadians);
        }
    }
}

