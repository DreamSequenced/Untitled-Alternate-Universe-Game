using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorExit : Interactable
{
    [SerializeField]
    private string sceneToTransitionTo;
    [SerializeField]
    private string doorToTransitionTo;
    [SerializeField]
    private bool requiresKey = false;
    [SerializeField]
    private Key requiredKey;

    [SerializeField]
    [Range(0.05f, 3f)]
    private float detectionDistance = 0.75f;

    public override void OnInteract()
    {
        if (!requiresKey)
        {
            PortalManager.Instance.currentDoor = doorToTransitionTo;
            SceneManager.LoadScene(sceneToTransitionTo);
        }
        else if(Inventory.Instance.CheckForKey(requiredKey))
        {
            Debug.Log("We have the keyyy");
            PortalManager.Instance.currentDoor = doorToTransitionTo;
            SceneManager.LoadScene(sceneToTransitionTo);
        }

    }

    private void OnMouseOver()
    {
        if (Physics2D.OverlapCircle(transform.position, detectionDistance, LayerMask.GetMask("Player")))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                OnInteract();
            }
        }
    }
}
