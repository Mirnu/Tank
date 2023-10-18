using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] public List<Transform> enemySpawners;
    [SerializeField] private GameObject enemyPrefab;

    public static EnemySpawner Instance;

    public GameObject currentEnemy;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        Spawn();
    }

    public void Spawn()
    {
        if (enemySpawners.Count > 0) 
        {
            currentEnemy = Instantiate(enemyPrefab, enemySpawners[0]);
            enemySpawners.RemoveAt(0);  
        }
    }
}
