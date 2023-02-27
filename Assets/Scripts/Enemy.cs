using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] GameObject explosionPrefab;

    private GameManager gameManager;
    public float minSpeed = 10.0f;
    public float maxSpeed = 20.0f;
    private float speed = 10f; 

    public void Start()
    {
        gameManager = GameManager.instance;
        if (gameManager == null)
        {
            Debug.LogError("GameManager not found");
        }
  
    }

    private void OnEnable()
    {
        speed = Random.Range(minSpeed, maxSpeed);
        //Debug.Log(speed, this);
    }
    void Update()
    {

        // Move our position a step closer to the target.
        float step = speed * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(0,-2,0), step);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Projectile")
        {
            gameManager.ScorePoints(1);
            Explode();
            gameObject.SetActive(false);
        }
        if (other.tag == "Platform")
        {
            gameManager.LoseLife();
            gameObject.SetActive(false);
        }
    }

    private void Explode()
    {
        GameObject explosion = Instantiate(explosionPrefab);
        explosion.transform.position = transform.position;
    }
}
