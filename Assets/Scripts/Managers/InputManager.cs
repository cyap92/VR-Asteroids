using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class InputManager : MonoBehaviour
{
    private GameManager gameManager;

    public void Awake()
    {
        gameManager = GameManager.instance;
        if (gameManager == null)
        {
            Debug.LogError("GameManager not found");
        }
    }

    void Update()
    {
        if (SteamVR_Actions._default.GrabPinch.GetStateUp(SteamVR_Input_Sources.LeftHand))
        {
            //Debug.Log("Grab Pinch Left Up");
        }
        if (SteamVR_Actions._default.GrabPinch.GetStateDown(SteamVR_Input_Sources.LeftHand))
        {
            gameManager.FireLeftGun();
            //Debug.Log("Grab Pinch Left Down");
        }
        if (SteamVR_Actions._default.GrabPinch.GetStateUp(SteamVR_Input_Sources.RightHand))
        {
            //Debug.Log("Grab Pinch Right Up");
        }
        if (SteamVR_Actions._default.GrabPinch.GetStateDown(SteamVR_Input_Sources.RightHand))
        {
            gameManager.FireRightGun();
            //Debug.Log("Grab Pinch Right Down");
        }
    }  
}
