using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SwitchWorldListener : MonoBehaviour
{
    private void OnEnable()
    {
        EventManager.OnSwitchWorld += HandleSwitchWorld;
    }

    private void OnDisable()
    {
        EventManager.OnSwitchWorld -= HandleSwitchWorld;
    }

    public abstract void HandleSwitchWorld(bool inAlternateWorld);
}
