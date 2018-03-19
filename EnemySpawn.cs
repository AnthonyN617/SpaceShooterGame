using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour {

    public enum EnemyLevels
    {
        //Easy
        Ladybug,
        //Medium
        Dragonfly,
        //Hard
        Bee
    }

    public enum SpawnTypes
    {
        Normal
    }

    public EnemyLevels enemyLevel = EnemyLevels.Ladybug;




    //------------------------
    //Enemy Prefabs
    //------------------------
    public GameObject LBug;
    public GameObject DFly;
    public GameObject B;

    //Not sure what this line does
    private Dictionary<EnemyLevels, GameObject> Enemies = new Dictionary<EnemyLevels, GameObject>(3);
    
    //------------------------
    //End of enemy prefabs
    //------------------------




    public int totalEnemy = 10;
    private int numEnemy = 0;
    private int spawnedEnemy = 0;

    
    private int SpawnID;

    public bool waveSpawn = false;
    public bool Spawn = true;

    public float waveTimer = 30f;
    public float timeTillWave = 0f;
    public int totalWaves = 5;
    public int numWaves = 0;
    




	// Use this for initialization
	void Start () {
        SpawnID = Random.Range(1, 500);
        Enemies.Add(EnemyLevels.Ladybug, LBug);
        Enemies.Add(EnemyLevels.Dragonfly, DFly);
        Enemies.Add(EnemyLevels.Bee, B);
	}
	
	// Update is called once per frame
	void Update () {
        if (Spawn)
            if (numEnemy < totalEnemy)
            {
                spawnEnemy();
            }

    }

    public void spawnEnemy()
    {
        GameObject Enemy = (GameObject)Instantiate(Enemies[enemyLevel], gameObject.transform.position, Quaternion.identity);
        Enemy.SendMessage("setName", SpawnID);
        numEnemy++;
        spawnedEnemy++;
    }

    public void killEnemy(int sID)
    {
        if (SpawnID == sID)
        {
            numEnemy--;
        }
    }

    public void enableSpawner(int sID)
    {
        if (SpawnID == sID)
        {
            Spawn = true;
        }
    }

    public void disableSpawner(int sID)
    {
        if (SpawnID == sID)
        {
            Spawn = false;
        }
    }

    public void enableTrigger()
    {
        Spawn = true;
    }
}
