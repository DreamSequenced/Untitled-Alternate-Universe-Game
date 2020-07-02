using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public delegate void SwitchWorld(bool inAlternateWorld);
    public static event SwitchWorld OnSwitchWorld;

    public delegate void Overheat(bool isOverheated);
    public static event Overheat OnOverheated;

    public static bool inAlternateWorld;
    public static bool isOverheated;

    public static EventManager Instance;

    private void Start()
    {
        if(Instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        inAlternateWorld = false;
        isOverheated = false;
    }

    public static void InvokeSwitchWorld(bool inAlternateWorld)
    {
        OnSwitchWorld.Invoke(inAlternateWorld);
    }

    public static void InvokeOverheated(bool isOverheated)
    {
        OnSwitchWorld.Invoke(isOverheated);
    }
}
