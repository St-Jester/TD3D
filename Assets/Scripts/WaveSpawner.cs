using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;


public class WaveSpawner : MonoBehaviour {
    [System.Serializable]
    public struct Wave
    {
        public string name;
        public float rate;//frequency of spawn  
        public int count;//amount of enemies
        public GameObject enemy;
    }

    enum WaveState
    {
        SPAWNING,//spawnenemy
        WAITING,//waitforkilling
        COUNTING//countdown
    }

    WaveState state = WaveState.COUNTING;

    int nextWaveIndex = 0;
    int AliveEnemies;
    public float timeBetween = 5f;

    public float  waveCountdown;

    public Wave[] waves;
    public Transform spawnPoint;

    public Text countdownTimerText;

    private void Start()
    {
        Enemy.KillEvent += OnEnemyKilled;
      

        waveCountdown = timeBetween;
        AliveEnemies = waves[0].count;
    }

    private void Update()
    {
        if(nextWaveIndex >= waves.Length)
        {
            Debug.Log("Completed");
            enabled = false;
            return;
        }
        if (state == WaveState.WAITING)
        {
            //check if killed;
            //Debug.Log("Waiting for wave to complete");
            if(AllEnemiesKilled())
            {
                state = WaveState.COUNTING;
                waveCountdown = timeBetween;
                nextWaveIndex++;
            }

        }
        else
            if(waveCountdown <= 0f)
            {
                if(state != WaveState.SPAWNING)
                {
                    AliveEnemies = waves[nextWaveIndex].count;

                    StartCoroutine(SpawnWave(waves[nextWaveIndex]));
                }
            }
            else
            {
                waveCountdown -= Time.deltaTime;
            }


        countdownTimerText.text = Mathf.Floor(waveCountdown+1).ToString();
    }

    IEnumerator SpawnWave(Wave _wave)
    {
        Debug.Log(_wave.name);
        state = WaveState.SPAWNING;
        //spawn cycle here
        for (int i = 0; i < _wave.count; i++)
        {
            SpawnEnemy(_wave.enemy);
            yield return new WaitForSeconds(1f / _wave.rate);
        }

        state = WaveState.WAITING;

        yield break;
    }
    
    void SpawnEnemy(GameObject _enemy)
    {
        Instantiate(_enemy, spawnPoint.position, spawnPoint.rotation);
        Debug.Log("Spawning enemy " + _enemy.name);
    }

    private bool AllEnemiesKilled()
    {
        return AliveEnemies <= 0;
        //return true;
    }
    public void OnEnemyKilled()
    {
        //FindObjectOfType<Enemy>().KillEvent -= OnEnemyKilled;
        Debug.Log("Enemy killed");
        AliveEnemies -= 1;
    }
}

//enemies death in delegates