﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EssentialLoader : MonoBehaviour
{
    public PlayerController playerPrefab;
    public EventManager eventManagerPrefab;
    public HUD hudPrefab;

    private void Start()
    {
        if(PlayerController.Instance == null)
        {
            PlayerController playerInstance = Instantiate(playerPrefab);
            PlayerController.Instance = playerInstance;
        }

        if(EventManager.Instance == null)
        {
            EventManager eventManagerInstance = Instantiate(eventManagerPrefab);
            EventManager.Instance = eventManagerInstance;
        }

        if(HUD.Instance == null)
        {
            HUD hudInstance = Instantiate(hudPrefab);
            HUD.Instance = hudInstance;
        }
    }
}
