using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderController : MonoBehaviour
{
    public bool IsOverheated { get; set; }
    private bool overheatTriggered;
    private bool powerTriggered;

    private void Awake()
    {
        overheatTriggered = false;
        powerTriggered = false;
    }

    void Update()
    {
        if (IsOverheated && !overheatTriggered)
        {
            EventManager.InvokeSwitchWorld(false);
            overheatTriggered = true;
        }
        else if(overheatTriggered)
        {
            return;
        }

        if(Input.GetKeyUp(KeyCode.Q))
        {
            powerTriggered = !powerTriggered;
            EventManager.InvokeSwitchWorld(powerTriggered);
        }

        // Code in case it breaks - hoping the above solution sticks
        /*if (Input.GetKeyDown(KeyCode.Q))
        {
            EventManager.InvokeSwitchWorld(true);
        }

        if (Input.GetKeyUp(KeyCode.Q))
        {
            EventManager.InvokeSwitchWorld(false);
        }*/
    }

    public void ResetOverheat()
    {
        overheatTriggered = false;
        IsOverheated = false;
    }
}
