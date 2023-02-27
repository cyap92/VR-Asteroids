using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField]
    Transform barrel;

    [SerializeField]
    GameObject ProjectilePrefab;

    [SerializeField]
    AudioSource audioSource;

    public List<GameObject> pooledProjectiles;
    public int maxProjectiles= 30;

    private void Start()
    {
        pooledProjectiles = new List<GameObject>();
        GameObject tmp;
        for (int i = 0; i < maxProjectiles; i++)
        {
            tmp = Instantiate(ProjectilePrefab);
            tmp.SetActive(false);
            pooledProjectiles.Add(tmp);
        }
    }

    public GameObject GetPooledProjectile()
    {
        for (int i = 0; i < maxProjectiles; i++)
        {
            if (!pooledProjectiles[i].activeInHierarchy)
            {
                return pooledProjectiles[i];
            }
        }
        return null;
    }

    public void Fire()
    {
        GameObject projectileGO = GetPooledProjectile();
        Projectile projectile = projectileGO.GetComponent<Projectile>();
        projectile.transform.parent = barrel;
        projectile.transform.localPosition = Vector3.zero;
        projectile.transform.localRotation = transform.localRotation;
        projectile.transform.parent = null;
        projectile.SetTargetLine(new Ray(projectile.transform.position, projectile.transform.rotation * Vector3.forward));
        audioSource.PlayOneShot(audioSource.clip);
        projectileGO.SetActive(true);
    }
}
