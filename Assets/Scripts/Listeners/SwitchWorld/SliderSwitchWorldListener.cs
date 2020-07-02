using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderSwitchWorldListener : SwitchWorldListener
{
    private Slider slider;
    private SliderController sliderController;

    private bool isTickingDown;

    private Color originalColor;

    public override void HandleSwitchWorld(bool inAlternateWorld)
    {
        isTickingDown = inAlternateWorld;
    }

    private void Start()
    {
        slider = GetComponent<Slider>();
        sliderController = GetComponent<SliderController>();

        isTickingDown = false;

        originalColor = slider.transform.GetChild(1).GetChild(0).GetComponent<Image>().color;
    }

    private void Update()
    {
        if(isTickingDown && !sliderController.IsOverheated && slider.value != slider.minValue)
        {
            EnableEffect();
        }
        else if(!isTickingDown && slider.value != slider.maxValue)
        {
            DisableEffect();
        }
    }

    private void EnableEffect()
    {
        slider.value -= 1f * Time.deltaTime;

        if (slider.value == slider.minValue)
        {
            sliderController.IsOverheated = true;
            slider.transform.GetChild(1).GetChild(0).GetComponent<Image>().color = Color.red;
        }
    }

    private void DisableEffect()
    {
        if (sliderController.IsOverheated)
        {
            if (slider.value >= slider.maxValue / 4)
            {
                sliderController.ResetOverheat();
                slider.transform.GetChild(1).GetChild(0).GetComponent<Image>().color = originalColor;
            }
        }

        slider.value += .5f * Time.deltaTime;
    }
}
