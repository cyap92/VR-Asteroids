using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float lifetime = 3f;
    [SerializeField] private float ShotSpeed = .1f;

    private Ray TargetLine = new Ray();
    private bool targetLineSet = false;

    public void SetTargetLine(Ray targetLine)
    {
        TargetLine = targetLine;
        targetLineSet = true;
    }

    private void OnEnable()
    {

        
        StartCoroutine(DestroyAfterSeconds(lifetime));
    }

    private void Update()
    {
        transform.Translate(Vector3.back*  ShotSpeed);
        /*
        if (targetLineSet)
        {
            transform.localPosition = new Vector3(transform.localPosition.x - .1f, transform.localPosition.y, transform.localPosition.z);
        }
        */
    }

    IEnumerator DestroyAfterSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
}
