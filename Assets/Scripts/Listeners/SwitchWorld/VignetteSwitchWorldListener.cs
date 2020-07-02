using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class VignetteSwitchWorldListener : SwitchWorldListener
{
    [SerializeField]
    [Range(0.01f, 1f)]
    private float transitionSpeed = .5f;
    [SerializeField]
    [Range(0f, 1f)]
    private float maxIntensity = 0.4f;
    [SerializeField]
    [Range(0f, 1f)]
    private float maxSmoothness = 0.3f;
    private float initialIntensity = 0f;
    private float initialSmoothness = 0f;

    private Vignette vignette;

    private void Start()
    {
        vignette = (Vignette) GetComponent<Volume>().profile.components[0];

        vignette.intensity.max = maxIntensity;
        vignette.intensity.value = 0f;
        vignette.smoothness.max = maxSmoothness;
        vignette.smoothness.value = 0f;
    }

    private enum TransitionMode { NotOn, TransitionToNotOn, On, TransitionToOn }

    private TransitionMode transitionMode = TransitionMode.NotOn;

    private float transitionProgress;

    public bool isDone { get; private set; }

    public override void HandleSwitchWorld(bool inAlternateWorld)
    {
        isDone = false;
        if (inAlternateWorld)
        {
            transitionMode = TransitionMode.TransitionToOn;
        }
        else
        {
            transitionMode = TransitionMode.TransitionToNotOn;
        }
    }

    private void Update()
    {
        switch (transitionMode)
        {
            case TransitionMode.TransitionToOn:
                TransitionToOn();
                break;
            case TransitionMode.TransitionToNotOn:
                TransitionToNotOn();
                break;
        }
    }

    private void TransitionToOn()
    {
        // Set transition progress
        transitionProgress += Time.deltaTime * (1f / transitionSpeed);
        vignette.intensity.value = transitionProgress;
        vignette.smoothness.value = transitionProgress;

        // Doneness checks
        if (transitionProgress >= .4f)
        {
            isDone = true;
            transitionMode = TransitionMode.On;
        }
    }

    private void TransitionToNotOn()
    {
        // Set transition progress
        transitionProgress -= Time.deltaTime * (1f / transitionSpeed);
        vignette.intensity.value = transitionProgress;
        vignette.smoothness.value = transitionProgress;

        // Doneness checks
        if (transitionProgress <= 0f)
        {
            isDone = true;
            transitionMode = TransitionMode.NotOn;
        }
    }
}
