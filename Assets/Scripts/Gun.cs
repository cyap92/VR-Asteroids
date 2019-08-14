using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField]
    Transform barrel;

    [SerializeField]
    GameObject ProjectilePrefab;

    public void Fire()
    {
        GameObject projectileGO = Instantiate(ProjectilePrefab);
        Projectile projectile = projectileGO.GetComponent<Projectile>();
        projectile.transform.parent = barrel;
        projectile.transform.localPosition = Vector3.zero;
        projectile.transform.localRotation = transform.localRotation;
        projectile.transform.parent = null;
        projectile.SetTargetLine(new Ray(projectile.transform.position, projectile.transform.rotation * Vector3.forward));
    }
}
