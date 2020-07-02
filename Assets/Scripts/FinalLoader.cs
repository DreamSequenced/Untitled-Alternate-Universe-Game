using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalLoader : MonoBehaviour
{
    private void Start()
    {
        EventManager.InvokeSwitchWorld(false);
    }
}
