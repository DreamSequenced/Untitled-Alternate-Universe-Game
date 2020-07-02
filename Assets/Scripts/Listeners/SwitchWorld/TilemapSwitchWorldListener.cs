using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapSwitchWorldListener : SwitchWorldListener
{
    public override void HandleSwitchWorld(bool inAlternateWorld)
    {
        if(CompareTag("Overworld"))
        {
            if (inAlternateWorld)
            {
                SetTilemapVisibility(false);
            }
            else
            {
                SetTilemapVisibility(true);
            }
        }
        else if (CompareTag("Underworld"))
        {
            if(!inAlternateWorld)
            {
                SetTilemapVisibility(false);
            }
            else
            {
                SetTilemapVisibility(true);
            }
        }
    }

    private void SetTilemapVisibility(bool enabled)
    {
        TilemapCollider2D collider = GetComponent<TilemapCollider2D>();
        if (collider != null) collider.enabled = enabled;

        GetComponent<TilemapRenderer>().enabled = enabled;
    }
}
