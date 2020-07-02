using System.Collections;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class LightFlicker : SwitchWorldListener
{
    [SerializeField]
    private Vector2 flickerLength;
    [SerializeField]
    private Vector2 flickerInterval;

    private bool isFlickering;

    private Coroutine flickerCoroutine;

    public override void HandleSwitchWorld(bool inAlternateWorld)
    {
        isFlickering = inAlternateWorld;
        if (isFlickering)
        {
            flickerCoroutine = StartCoroutine(StartFlickering());
        }
    }

    private IEnumerator StartFlickering()
    {
        while(true)
        {
            yield return new WaitForSeconds(Random.Range(flickerInterval.x, flickerInterval.y));

            GetComponent<Light2D>().enabled = true;

            yield return new WaitForSeconds(Random.Range(flickerLength.x, flickerLength.y));

            GetComponent<Light2D>().enabled = false;
        }
        
    }

    private void Update()
    {
        if (flickerCoroutine != null && !isFlickering)
        {
            StopCoroutine(flickerCoroutine);
            GetComponent<Light2D>().enabled = true;
        }

    }

}
