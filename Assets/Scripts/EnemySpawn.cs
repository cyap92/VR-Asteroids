using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{

    [SerializeField]
    GameObject EnemyPrefab;

    [SerializeField]
    BoxCollider SpawnZone;

    private GameManager gameManager;

    public void Start()
    {
        gameManager = GameManager.instance;
        if (gameManager == null)
        {
            Debug.LogError("GameManager not found");
        }

        StartCoroutine(SpawnEnemies(0));
    }

    public void SpawnEnemy()
    {
        Debug.Log("Spawn Enemy");
        GameObject enemyGO = Instantiate(EnemyPrefab);
        Enemy enemy = enemyGO.GetComponent<Enemy>();
        enemy.transform.position = new Vector3(Random.Range(SpawnZone.bounds.min.x, SpawnZone.bounds.max.x), Random.Range(SpawnZone.bounds.min.y, SpawnZone.bounds.max.y), Random.Range(SpawnZone.bounds.min.z, SpawnZone.bounds.max.z));
        enemy.transform.localRotation = transform.localRotation;
    }

    IEnumerator SpawnEnemies(int enemies)
    {
        int count = 0;
        while (enemies == 0 || count < enemies)
        {
            SpawnEnemy();
            count++;
            for (int i = 0; i < 100; i++)
            {
                yield return null;
            }
        }       
    }
}
