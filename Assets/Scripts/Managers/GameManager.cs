using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] Gun LeftGun;
    [SerializeField] Gun RightGun;
    [SerializeField] InputManager inputManager;

    public bool isPlaying = true;

    public static GameManager instance;

    public void OnEnable()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }


    public void FireLeftGun()
    {
        if (LeftGun != null)
        {
            LeftGun.Fire();
        }
        else
        {
            Debug.LogError("Left Gun is null");
        }
    }

    public void FireRightGun()
    {
        if (RightGun != null)
        {
            RightGun.Fire();
        }
        else
        {
            Debug.LogError("Right Gun is null");
        }
    }
}
