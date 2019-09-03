using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{

    [SerializeField]
    GameObject[] EnemyPrefabs;

    [SerializeField]
    BoxCollider SpawnZone;

    public float MinTimeBetweenSpawns = 0;
    public float MaxTimeBetweenSpawns = 1f;

    private GameManager gameManager;

    public void Start()
    {
        gameManager = GameManager.instance;
        if (gameManager == null)
        {
            Debug.LogError("GameManager not found");
        }
    }

    public void SpawnEnemy()
    {
        //Debug.Log("Spawn Enemy");
        int enemyNum = (int)Mathf.Round(Random.Range(0, EnemyPrefabs.Length - 1));

        GameObject enemyGO = Instantiate(EnemyPrefabs[enemyNum]);
        Enemy enemy = enemyGO.GetComponent<Enemy>();
        float scale = Random.Range(.75f, 2f);
        enemy.transform.localScale = new Vector3(enemy.transform.localScale.x*scale, enemy.transform.localScale.y * scale, enemy.transform.localScale.z * scale);
        enemy.transform.localRotation = Random.rotation;
        Rigidbody enemyRigidBody = enemy.GetComponent<Rigidbody>();
        enemyRigidBody.angularVelocity = new Vector3(Random.Range(-1f,1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        enemy.transform.parent = transform;
        enemy.transform.position = new Vector3(Random.Range(SpawnZone.bounds.min.x, SpawnZone.bounds.max.x), Random.Range(SpawnZone.bounds.min.y, SpawnZone.bounds.max.y), Random.Range(SpawnZone.bounds.min.z, SpawnZone.bounds.max.z));
        enemy.transform.localRotation = transform.localRotation;
        
    }

    public IEnumerator SpawnEnemies(int enemies)
    {
        int count = 0;
        while ((enemies == 0 || count < enemies) && gameManager.isPlaying)
        {
            SpawnEnemy();
            count++;
            float timeBetweenSpawns = Random.Range(MinTimeBetweenSpawns, MaxTimeBetweenSpawns);
            int frames = (int)Mathf.Round(timeBetweenSpawns / Time.deltaTime);

            for (int i = 0; i < frames; i++)
            {
                yield return null;
            }
        }       
    }

    public void DestroyAllEnemies()
    {
        for(int i =0; i <transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
    }
}
