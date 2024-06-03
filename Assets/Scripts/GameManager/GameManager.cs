using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private int score = 0;
    private int health = 10;
    public GameObject[] EnemiesSpawners;

    private void Awake()
    {
        CreateSingleton();
    }

    private void Start()
    {
        StartCoroutine(SpawnEnemiesCooldown(7));
    }

    private void Update()
    {
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
        StartCoroutine(SpawnEnemiesCooldown(10));
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
