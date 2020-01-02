using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WaveSystem : MonoBehaviour
{
    public enum SpawnState { Spawning, Waiting, Counting };
    public UnityEvent OnWaveComplete;

    [System.Serializable]
    public class Wave
    {
        public string name;
        public Transform enemy;
        public int count;
        public float delay;
    }

    public Transform[] SpawnPoints;
    public Wave[] Waves;


    private int NextWave = 0;
    public float timeBetweenWaves = 5f;
    public float waveCountdown;

    private float searchCountdown = 1f;

    private SpawnState State = SpawnState.Counting;
    private void Start()
    {
        waveCountdown = timeBetweenWaves;
    }

    private void Update()
    {
        if (State == SpawnState.Waiting)
        {
            if (!EnemyIsAlive())
            {
                WaveCompleted();
                return;
            }
            else
            {
                return;
            }
        }


        if (waveCountdown <= 0)
        {
            if (State != SpawnState.Spawning)
            {
                StartCoroutine(NewWave(Waves[NextWave]));
            }
        }
        else
        {
            waveCountdown -= Time.deltaTime;
        }
    }

    void WaveCompleted()
    {
        OnWaveComplete.Invoke();
        State = SpawnState.Counting;
        waveCountdown = timeBetweenWaves;

        if (NextWave + 1 > Waves.Length - 1)
        {
            Debug.Log("All Waves Completed! Loop Time");
            NextWave = 0;
        }
        else
        {
            NextWave++;
        }

    }

    IEnumerator NewWave(Wave _wave)
    {
        State = SpawnState.Spawning;

        for (int i = 0; i < _wave.count; i++)
        {
            SpawnEnemy(_wave.enemy);
            yield return new WaitForSeconds(_wave.delay);
        }

        State = SpawnState.Waiting;
        yield break;
    }

    bool EnemyIsAlive()
    {
        searchCountdown -= Time.deltaTime; 
        if(searchCountdown <= 0f)
        {
            searchCountdown = 1f;
            if (GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                return false;
            }
        }
        return true;
    }


    void SpawnEnemy(Transform _enemy)
    {
        Transform _sp = SpawnPoints[Random.Range(0, SpawnPoints.Length)];
        Instantiate(_enemy, _sp.position, _sp.rotation);
    }
}
