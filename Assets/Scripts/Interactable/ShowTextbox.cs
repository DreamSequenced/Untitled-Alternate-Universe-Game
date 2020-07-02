using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowTextbox : Interactable
{
    [SerializeField]
    private string textToShow;
    [SerializeField]
    private GameObject textBoxPrefab;
    private GameObject instantiatedTextBox;
    [SerializeField]
    [Range(0.05f, 3f)]
    private float detectionDistance = .75f;

    [SerializeField]
    private Material normalMaterial;
    [SerializeField]
    private Material withinRangeMaterial;

    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public override void OnInteract()
    {
        if(instantiatedTextBox == null)
        {
            instantiatedTextBox = Instantiate(textBoxPrefab,
                FindObjectOfType<PlayerController>().transform.GetChild(0).GetChild(0).transform);
            instantiatedTextBox.GetComponentInChildren<Text>().text = textToShow;

        }
        else
        {
            Destroy(instantiatedTextBox);
        }
    }

    private void Update()
    {
        if(!Physics2D.OverlapCircle(transform.position, detectionDistance, LayerMask.GetMask("Player")))
        {
            spriteRenderer.material = normalMaterial;
            Destroy(instantiatedTextBox);
        }

        if (Physics2D.OverlapCircle(transform.position, detectionDistance, LayerMask.GetMask("Player")))
        {
            spriteRenderer.material = withinRangeMaterial;
        }
    }

    private void OnMouseOver()
    {
        if (Physics2D.OverlapCircle(transform.position, detectionDistance, LayerMask.GetMask("Player")))
        {
            if (Input.GetMouseButtonDown(0))
            {
                OnInteract();
            }
        }
    }
}
