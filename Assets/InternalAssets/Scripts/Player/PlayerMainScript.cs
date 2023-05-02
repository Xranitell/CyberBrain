using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMainScript : MonoBehaviour
{
    public static PlayerMainScript Instance;
    
    public Camera playerCamera;
    public Transform cameraPosition;

    public PlayerMovement playerMovement;
    public PlayerInteraction playerInteraction;
    public MouseComponent mouseComponent;

    private void Awake()
    {
        Instance = this;
        cameraPosition.position = playerCamera.transform.position;
    }


}
