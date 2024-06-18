using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject[] EnemiesSpawners;

    private int score = 0;
    private int health = 10;
    private GameObject[] targets;
    private bool enemiesWaves = false;

    private void Awake()
    {
        CreateSingleton();
    }

    private void Start()
    {
        targets = GameObject.FindGameObjectsWithTag("Target");
    }

    private void Update()
    {
        targets = GameObject.FindGameObjectsWithTag("Target");
        checkTargetsNumber();
    }

    private void checkTargetsNumber()
    {
        if (targets.Length == 0 && enemiesWaves == false)
        {
            enemiesWaves = true;
            StartCoroutine(SpawnEnemiesCooldown(3));
        }
    }

    private IEnumerator SpawnEnemiesCooldown(int waitingTime)
    {
        yield return new WaitForSeconds(waitingTime);
        SpawnEnemies();
    }

    private void SpawnEnemies()
    {
        foreach (GameObject spawner in EnemiesSpawners)
        {
            spawner.GetComponent<SpawnEnnemies>().SpawnEnemy();
        }
        StartCoroutine(SpawnEnemiesCooldown(5));
    }

    void CreateSingleton()
    {
        if (instance == null)
        {
            instance = this;
        } 
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public int GetScore()
    {
        return score;
    }

    public void IncreaseScore(int value)
    {
        score += value;
    }

    public int GetHealth()
    {
        return health;
    }

    public void DecreaseHealth(int value)
    {
        health -= value;
    }
}
