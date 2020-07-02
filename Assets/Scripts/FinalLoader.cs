using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class FinalLoader : SwitchWorldListener
{
    public static FinalLoader Instance;

    public bool inAlternateWorld;

    public override void HandleSwitchWorld(bool inAlternateWorld)
    {
        this.inAlternateWorld = inAlternateWorld;
    }

    private void Start()
    {
        if (Instance != this)
        {
            Destroy(gameObject);
            // Return as we don't want rest of start to go through
            return;
        }

        DontDestroyOnLoad(gameObject);

        EventManager.InvokeSwitchWorld(false);

        SceneManager.sceneLoaded += OnSceneLoad;
    }

    public void OnSceneLoad(Scene scene, LoadSceneMode mode)
    {
        EventManager.InvokeSwitchWorld(inAlternateWorld);
    }
}
