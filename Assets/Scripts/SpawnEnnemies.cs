using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnnemies : MonoBehaviour
{
    public GameObject[] ennemies;

    public void SpawnEnemy()
    {
        Instantiate(ennemies[Random.Range(0, 2)], gameObject.transform);
    }
}
