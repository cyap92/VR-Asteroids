using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class InputManager : MonoBehaviour
{
    private GameManager gameManager;
    private bool leftTriggerDown = false;
    private bool rightTriggerDown = false;
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
        //Debug.Log("Left: " + leftTriggerDown + " Right: " + rightTriggerDown);
        if (SteamVR_Actions._default.GrabPinch.GetStateUp(SteamVR_Input_Sources.LeftHand))
        {
            leftTriggerDown = false;
            //Debug.Log("Grab Pinch Left Up");
        }
        if (SteamVR_Actions._default.GrabPinch.GetStateDown(SteamVR_Input_Sources.LeftHand))
        {
            gameManager.FireLeftGun();
            leftTriggerDown = true;
            //Debug.Log("Grab Pinch Left Down");
        }
        if (SteamVR_Actions._default.GrabPinch.GetStateUp(SteamVR_Input_Sources.RightHand))
        {
            rightTriggerDown = false;
            //Debug.Log("Grab Pinch Right Up");
        }
        if (SteamVR_Actions._default.GrabPinch.GetStateDown(SteamVR_Input_Sources.RightHand))
        {
            gameManager.FireRightGun();
            rightTriggerDown = true;
            //Debug.Log("Grab Pinch Right Down");
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
