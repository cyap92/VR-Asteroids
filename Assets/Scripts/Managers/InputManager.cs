using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private GameManager gameManager;
    private bool leftTriggerDown = false;
    private bool rightTriggerDown = false;
    private bool canFireLeft = true;
    private bool canFireRight = true;
    public void Start()
    {
        gameManager = GameManager.instance;
        if (gameManager == null)
        {
            Debug.LogError("GameManager not found");
        }
    }
    
    void Update()
    {
        if (OVRInput.Get(OVRInput.RawButton.LIndexTrigger))
        {
            leftTriggerDown = true;
            if (canFireLeft)
            {
                gameManager.FireLeftGun();             
                canFireLeft = false;
                //Debug.Log("Grab Pinch Left Down");
            }
        }
        if (OVRInput.Get(OVRInput.RawButton.RIndexTrigger))
        {
            rightTriggerDown = true;
            if (canFireRight)
            {
                gameManager.FireRightGun();
                canFireRight = false;
                //Debug.Log("Grab Pinch Right Down");
            }
        }
        if (!OVRInput.Get(OVRInput.RawButton.RIndexTrigger))
        {
            canFireRight = true;
            rightTriggerDown = false;
        }
        if (!OVRInput.Get(OVRInput.RawButton.LIndexTrigger))
        {
            canFireLeft = true;
            leftTriggerDown = false;
        }
        if (!gameManager.isPlaying && rightTriggerDown && leftTriggerDown)
        {
            gameManager.StartGame();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
    
}
