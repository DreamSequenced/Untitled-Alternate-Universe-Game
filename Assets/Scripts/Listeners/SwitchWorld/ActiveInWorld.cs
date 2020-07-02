using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveInWorld : SwitchWorldListener
{
    [SerializeField]
    private bool ActiveInNormalWorld;
    [SerializeField]
    private bool ActiveInAlternateWorld;

    public override void HandleSwitchWorld(bool inAlternateWorld)
    {
        if (inAlternateWorld)
        {
            SetComponents(ActiveInAlternateWorld);
        }
        else if (!inAlternateWorld)
        {
            SetComponents(ActiveInNormalWorld);
        }
    }

    private void SetComponents(bool enabled)
    {
        Behaviour[] behaviours = GetComponents<Behaviour>();
        Renderer[] renderers = GetComponents<Renderer>();
        Collider2D[] colliders = GetComponents<Collider2D>();

        foreach(Behaviour behaviour in behaviours)
        {
            if(behaviour != this) behaviour.enabled = enabled;
        }

        foreach (Renderer renderer in renderers)
        {
            renderer.enabled = enabled;
        }

        foreach (Collider2D collider in colliders)
        {
            collider.enabled = enabled;
        }
    }
}
