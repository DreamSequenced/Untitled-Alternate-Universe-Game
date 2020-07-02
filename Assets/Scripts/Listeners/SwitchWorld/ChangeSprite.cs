using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSprite : SwitchWorldListener
{
    [SerializeField]
    private Sprite normalWorldSprite;
    [SerializeField]
    private Sprite alternateWorldSprite;

    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public override void HandleSwitchWorld(bool inAlternateWorld)
    {
        if (inAlternateWorld)
        {
            if (alternateWorldSprite != null) spriteRenderer.sprite = alternateWorldSprite;
            else spriteRenderer.sprite = null;
        }
        else
        {
            if (normalWorldSprite != null) spriteRenderer.sprite = normalWorldSprite;
            else spriteRenderer.sprite = null;
        }
    }
}
