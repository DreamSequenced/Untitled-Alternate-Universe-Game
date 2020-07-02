using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderOverheatListener : OverheatListener
{
    public override void HandleOverheat(bool isOverheated)
    {
        GetComponent<SliderController>().IsOverheated = isOverheated;
    }
}
