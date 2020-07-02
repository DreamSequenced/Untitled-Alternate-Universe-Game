using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class OverheatListener : MonoBehaviour
{
    private void OnEnable()
    {
        EventManager.OnOverheated += HandleOverheat;
    }

    private void OnDisable()
    {
        EventManager.OnOverheated -= HandleOverheat;
    }

    public abstract void HandleOverheat(bool isOverheated);
}
