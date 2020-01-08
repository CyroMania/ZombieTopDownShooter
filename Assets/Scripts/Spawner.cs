using UnityEngine;
public class Spawner : MonoBehaviour
{
    public float SpawnRate = 0.1f;

    private int Result;

    public GameObject prefabToSpawn;
    public float adjustmentAngle = 0;
    public void Spawn()
    {
        float SpawnChance = (1 / SpawnRate);
        Result = Mathf.RoundToInt(Random.Range(1, SpawnChance));
        if (Result == 1)
        {
            Vector3 rotationInDegrees = transform.eulerAngles;
            rotationInDegrees.z += adjustmentAngle;
            Quaternion rotationInRadians = Quaternion.Euler(rotationInDegrees);
            Instantiate(prefabToSpawn, transform.position, rotationInRadians);
        }
    }
}

