using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwitchWorldListener : SwitchWorldListener
{
    private bool inAlternateWorld;
    private bool isDone;

    private float transitionProgress;
    [SerializeField]
    [Range(0.05f, 1f)]
    private float transitionSpeed;
    [SerializeField]
    [Range(0.05f, 1f)]
    private float minTransparency;

    private Material material;

    public override void HandleSwitchWorld(bool inAlternateWorld)
    {
        isDone = false;
        this.inAlternateWorld = inAlternateWorld;
    }

    private void Awake()
    {
        material = GetComponent<SpriteRenderer>().material;
        isDone = true;
    }

    private void Update()
    {
        if (!isDone && inAlternateWorld)
        {
            EnableEffect();
        }
        else if(!isDone && !inAlternateWorld)
        {
            DisableEffect();
        }
    }

    private void EnableEffect()
    {
        transitionProgress -= Time.deltaTime * (1f / transitionSpeed);
        material.SetFloat("_Fade", transitionProgress);

        // TO-DO: Figure out why this and sister statemnt in DisableEffect() makes player partially transparent on scene load.
        
        // Only modify transparency to a certain point
        /*if (transitionProgress >= minTransparency) material.SetFloat("_Transparency", transitionProgress);*/
        material.SetFloat("_Transparency", minTransparency);

        if (transitionProgress <= 0f)
        {
            isDone = true;
        }
    }

    private void DisableEffect()
    {
        transitionProgress += Time.deltaTime * (1f / transitionSpeed);
        material.SetFloat("_Fade", transitionProgress);

        /*if (transitionProgress >= minTransparency) material.SetFloat("_Transparency", transitionProgress);*/
        material.SetFloat("_Transparency", 1f);

        if (transitionProgress >= 1f)
        {
            isDone = true;
        }
    }
}
