using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;

public class SwitchWorldEffect : SwitchWorldListener
{
    [SerializeField]
    [Range(0.01f, 1f)]
    private float transitionSpeed = .5f;

    [SerializeField]
    private Image image;

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
        switch(transitionMode)
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
        transitionProgress += Time.deltaTime * (1f / transitionSpeed);
        image.fillAmount = transitionProgress;
        if (transitionProgress >= 1f)
        {
            isDone = true;
            transitionMode = TransitionMode.On;
        }
    }

    private void TransitionToNotOn()
    {
        transitionProgress -= Time.deltaTime * (1f / transitionSpeed);
        image.fillAmount = transitionProgress;
        if (transitionProgress <= 0f)
        {
            isDone = true;
            transitionMode = TransitionMode.NotOn;
        }
    }
}
