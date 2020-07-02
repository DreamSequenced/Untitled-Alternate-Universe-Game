using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchWorldDistort : SwitchWorldListener
{
    private bool inAlternateWorld;

    private Vector4[] noise;
    [SerializeField]
    [Range(0.0005f, 1f)]
    private float offsetSpeed;

    private Material material;

    public override void HandleSwitchWorld(bool inAlternateWorld)
    {
        this.inAlternateWorld = inAlternateWorld;
    }

    private void Awake()
    {
        material = GetComponent<Image>().material;
        noise = new Vector4[1];
    }

    private void Update()
    {
        if (inAlternateWorld)
        {
            EnableEffect();
        }
    }

    private void EnableEffect()
    {
        Debug.Log(noise[0].x);

        noise[0].x += Time.deltaTime * offsetSpeed;
        material.SetVectorArray("_Noise", noise);
    }
}
