using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
    public Level[] levels;
    public Enemy enemy;

    Level currentLevel;
    int levelNum;

    int enemiesLeft;
    int enemiesAlive;
    float nextSpawn;

    void Start()
    {
        NextLevel();
    }

    void Update()
    {
        if (enemiesLeft > 0 && Time.time > nextSpawn)
        {
            enemiesLeft--;
            nextSpawn = Time.time + currentLevel.spawnTime;

            Enemy spawnedEnemy = Instantiate(enemy, Vector3.zero, Quaternion.identity) as Enemy;
            spawnedEnemy.onDeath += onEnemyDeath;

        }
    }

    void onEnemyDeath()
    {
        enemiesAlive--;

        if (enemiesAlive == 0)
        {
            NextLevel();
        }
    }

    void NextLevel()
    {
        print("Level "+levelNum);
        levelNum++;
        if (levelNum - 1 < levels.Length)
        {
            currentLevel = levels[levelNum - 1];
        }

        enemiesLeft = currentLevel.enemyCount;
        enemiesAlive = enemiesLeft;
    }

    [System.Serializable]
    public class Level
    {
        public int enemyCount;
        public float spawnTime;
    }
}
