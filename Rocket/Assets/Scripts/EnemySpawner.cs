using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject EnemyGO;
    public GameObject EnemyMidBoss;
    private bool _spawnBoss;
    public int stat = 1;
    private int _killCounter;
    float maxSpawnRateInSeconds = 5f;

    public int KillCounter { get => _killCounter; set => _killCounter = value; }
    public bool SpawnBoss { get => _spawnBoss; }

    // Start is called before the first frame update
    void Start()
    {
        KillCounter = 1;
        _spawnBoss = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnEnemy()//респавн врага
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));//нижний левый угол
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));//верхний правый угол
        GameObject anEnemy;
       
        if (KillCounter %5 == 0)
        {
            _spawnBoss = true;
            stat = 1;
            KillCounter = 1;
        }
        if (_spawnBoss == true && stat==1)
        {
            
            _spawnBoss = false; stat--; 
            
            anEnemy = (GameObject)Instantiate(EnemyMidBoss);KillCounter = 1;
                   }
        else
        {
            anEnemy = (GameObject)Instantiate(EnemyGO);
        }
        anEnemy.transform.position = new Vector2(Random.Range(min.x, max.x), max.y);
        ScheduleNextEnemySpawn();      
    }

    void ScheduleNextEnemySpawn()//расписание по которому происходит респавн
    {
        
        float spawnInNSeconds;
        if (maxSpawnRateInSeconds > 1f)
        {
            spawnInNSeconds = Random.Range(1f, maxSpawnRateInSeconds);//берем значение между
        }
        else
            spawnInNSeconds = 1f;
        Invoke("SpawnEnemy", spawnInNSeconds);//вызов

    }

    //увеличение сложности игры
    void IncreaseSpawnRate()
    {
        if (maxSpawnRateInSeconds > 1f)
            maxSpawnRateInSeconds--;

        if (maxSpawnRateInSeconds == 1f)
            CancelInvoke("IncreaseSpawnRate");

    }

    public void ScheduleEnemySpawner()
    {
        maxSpawnRateInSeconds = 5f;
        Invoke("SpawnEnemy", maxSpawnRateInSeconds);
        
        //увеличиваем спавн каждый 20 секунд
        InvokeRepeating("IncreaseSpawnRate", 0f, 30f);
      
    }
    public void UnsheduleEnemySpawner()
    {
        CancelInvoke("SpawnEnemy");
        CancelInvoke("IncreaseSpawnRate");
    }
}
